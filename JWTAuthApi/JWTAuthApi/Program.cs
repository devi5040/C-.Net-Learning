using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using JWTAuthApi.Configuration;
using JWTAuthApi.Data;
using JWTAuthApi.Dtos;
using JWTAuthApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Database (use your own connection string if needed)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("JwtAuthDb"));

// Configuration for JWT
var jwtSection = builder.Configuration.GetSection("Jwt");
builder.Services.Configure<JwtOptions>(jwtSection);
var jwtOptions = jwtSection.Get<JwtOptions>() ?? new JwtOptions();
var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey));

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtOptions.Issuer,
            ValidAudience = jwtOptions.Audience,
            IssuerSigningKey = key,
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

// Helper methods
string HashPassword(string password, out byte[] salt)
{
    salt = RandomNumberGenerator.GetBytes(16);
    var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100_000, HashAlgorithmName.SHA256);
    return Convert.ToBase64String(pbkdf2.GetBytes(32));
}

bool VerifyPassword(string password, byte[] storedHash, byte[] storedSalt)
{
    var pbkdf2 = new Rfc2898DeriveBytes(password, storedSalt, 100_000, HashAlgorithmName.SHA256);
    var hash = pbkdf2.GetBytes(32);
    return CryptographicOperations.FixedTimeEquals(hash, storedHash);
}

string GenerateJwtToken(User user)
{
    var jwtOpts = app.Services.GetRequiredService<Microsoft.Extensions.Options.IOptions<JwtOptions>>().Value;
    var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOpts.SecretKey));
    var creds = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

    var claims = new List<Claim>
    {
        new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
        new(JwtRegisteredClaimNames.UniqueName, user.UserName),
        new(ClaimTypes.Role, user.Role)
    };

    var token = new JwtSecurityToken(
        issuer: jwtOpts.Issuer,
        audience: jwtOpts.Audience,
        claims: claims,
        expires: DateTime.UtcNow.AddMinutes(jwtOpts.AccessTokenMinutes),
        signingCredentials: creds);

    return new JwtSecurityTokenHandler().WriteToken(token);
}

RefreshToken GenerateRefreshToken()
{
    var jwtOpts = app.Services.GetRequiredService<Microsoft.Extensions.Options.IOptions<JwtOptions>>().Value;
    var randomBytes = RandomNumberGenerator.GetBytes(64);
    return new RefreshToken
    {
        Token = Convert.ToBase64String(randomBytes),
        ExpiresAt = DateTime.UtcNow.AddDays(jwtOpts.RefreshTokenDays),
        IsRevoked = false
    };
}

// Auth endpoints
app.MapPost("/api/auth/register", async (RegisterRequest request, AppDbContext db) =>
{
    if (await db.Users.AnyAsync(u => u.UserName == request.UserName))
    {
        return Results.BadRequest("Username already exists.");
    }

    if (await db.Users.AnyAsync(u => u.Email == request.Email))
    {
        return Results.BadRequest("Email already exists.");
    }

    var hashString = HashPassword(request.Password, out var salt);

    var user = new User
    {
        UserName = request.UserName,
        Email = request.Email,
        PasswordHash = Convert.FromBase64String(hashString),
        PasswordSalt = salt,
        Role = string.IsNullOrWhiteSpace(request.Role) ? "User" : request.Role
    };

    db.Users.Add(user);
    await db.SaveChangesAsync();

    return Results.Created($"/api/users/{user.Id}", new { user.Id, user.UserName, user.Email, user.Role });
});

app.MapPost("/api/auth/login", async (LoginRequest request, AppDbContext db) =>
{
    var user = await db.Users.Include(u => u.RefreshTokens)
        .SingleOrDefaultAsync(u => u.UserName == request.UserName);

    if (user is null)
    {
        return Results.BadRequest("Invalid credentials.");
    }

    if (!VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt))
    {
        return Results.BadRequest("Invalid credentials.");
    }

    var accessToken = GenerateJwtToken(user);
    var refreshToken = GenerateRefreshToken();
    refreshToken.UserId = user.Id;

    user.RefreshTokens.Add(refreshToken);
    await db.SaveChangesAsync();

    return Results.Ok(new AuthResponse(accessToken, refreshToken.Token));
});

app.MapPost("/api/auth/refresh", async (RefreshRequest request, AppDbContext db) =>
{
    var tokenEntity = await db.RefreshTokens
        .Include(r => r.User)
        .SingleOrDefaultAsync(r => r.Token == request.RefreshToken);

    if (tokenEntity is null || tokenEntity.IsRevoked || tokenEntity.ExpiresAt <= DateTime.UtcNow)
    {
        return Results.BadRequest("Invalid refresh token.");
    }

    var user = tokenEntity.User!;

    // Optionally revoke old token and issue a new one
    tokenEntity.IsRevoked = true;

    var newRefresh = GenerateRefreshToken();
    newRefresh.UserId = user.Id;
    db.RefreshTokens.Add(newRefresh);

    var newAccessToken = GenerateJwtToken(user);
    await db.SaveChangesAsync();

    return Results.Ok(new AuthResponse(newAccessToken, newRefresh.Token));
});

// Example secured endpoints
app.MapGet("/api/user/profile", [Authorize] (ClaimsPrincipal user) =>
{
    var userName = user.Identity?.Name ?? user.FindFirstValue(JwtRegisteredClaimNames.UniqueName);
    var role = user.FindFirstValue(ClaimTypes.Role);
    return Results.Ok(new { UserName = userName, Role = role });
});

app.MapGet("/api/admin/secret", [Authorize(Policy = "AdminOnly")] () =>
    Results.Ok("This is an ADMIN-only endpoint.")
);

app.Run();


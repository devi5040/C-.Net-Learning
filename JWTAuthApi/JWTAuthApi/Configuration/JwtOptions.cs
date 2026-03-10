namespace JWTAuthApi.Configuration;

public class JwtOptions
{
    public string Issuer { get; set; } = "JwtAuthApi";
    public string Audience { get; set; } = "JwtAuthApiClient";
    public string SecretKey { get; set; } = "THIS IS A VERY SECURE DEVELOPMENT KEY, CHANGE IN PRODUCTION";
    public int AccessTokenMinutes { get; set; } = 15;
    public int RefreshTokenDays { get; set; } = 7;
}


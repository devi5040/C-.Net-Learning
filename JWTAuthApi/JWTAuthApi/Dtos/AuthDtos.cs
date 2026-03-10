namespace JWTAuthApi.Dtos;

public record RegisterRequest(string UserName, string Email, string Password, string Role);
public record LoginRequest(string UserName, string Password);
public record AuthResponse(string AccessToken, string RefreshToken);
public record RefreshRequest(string RefreshToken);


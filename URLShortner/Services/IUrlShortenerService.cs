using UrlShortener.DTOs;

namespace UrlShortener.Services;

public interface IUrlShortenerService
{
    Task<ShortUrlResponseDto> CreateShortUrlAsync(CreateShortURLDto dto, string baseUrl);
    Task<string?> ResolveAndTrackAsync(string shortCode, HttpContext httpContext);
    Task<IEnumerable<ShortUrlResponseDto>> GetAllAsync();
    Task<ShortUrlResponseDto?> GetByCodeAsync(string shortCode, string baseUrl);
    Task<bool> DeactivateAsync(string shortCode);
}
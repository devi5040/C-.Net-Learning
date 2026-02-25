using Microsoft.EntityFrameworkCore;
using UrlShortener.Models;
using UrlShortener.Data;
using UrlShortener.DTOs;

namespace UrlShortener.Services;

public class UrlShortenerService : IUrlShortenerService
{
    private readonly AppDbContext _context;
    private const string Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    private const int CodeLength = 7;
    public UrlShortenerService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ShortUrlResponseDto> CreateShortUrlAsync(CreateShortURLDto dto, string baseUrl)
    {
        // Resolve short code custom code or generate new one
        string shortCode = dto.CustomCode ?? await GenerateUniqueCodeAsync();

        // Check if custom code already exists
        if (dto.CustomCode is not null)
        {
            bool exists = await _context.ShortUrls.AnyAsync(s => s.ShortCode == shortCode);
            if (exists)
                throw new InvalidOperationException($"Short code '{shortCode}' is already in use ");
        }
        var shortUrl = new ShortUrl
        {
            OriginalUrl = dto.OriginalUrl,
            ShortCode = shortCode,
            ExpiresAt = dto.ExpiresAt
        };

        _context.ShortUrls.Add(shortUrl);
        await _context.SaveChangesAsync();

        return MapToResponse(shortUrl, baseUrl);
    }


    public async Task<string?> ResolveAndTrackAsync(string shortCode, HttpContext httpContext)
    {
        var shortUrl = await _context.ShortUrls
            .FirstOrDefaultAsync(s => s.ShortCode == shortCode && s.IsActive);
        if (shortUrl is null) return null;

        // Check expiration
        if (shortUrl.ExpiresAt.HasValue && shortUrl.ExpiresAt.Value < DateTime.UtcNow)
        {
            shortUrl.IsActive = false;
            await _context.SaveChangesAsync();
            return null;
        }

        // Record click event
        var click = new ClickEvent
        {
            ShortUrlId = shortUrl.Id,
            IpAddress = httpContext.Connection.RemoteIpAddress?.ToString(),
            UserAgent = httpContext.Request.Headers.UserAgent.ToString(),
            Referrer = httpContext.Request.Headers.Referer.ToString()
        };

        shortUrl.TotalClicks++;

        _context.ClickEvents.Add(click);
        await _context.SaveChangesAsync();

        return shortUrl.OriginalUrl;
    }

    public async Task<IEnumerable<ShortUrlResponseDto>> GetAllAsync()
    {
        var baseUrl = string.Empty;
        return await _context.ShortUrls
        .Select(s => MapToResponse(s, baseUrl)).ToListAsync();
    }

    public async Task<ShortUrlResponseDto?> GetByCodeAsync(string shortCode, string baseUrl)
    {
        var shortUrl = await _context.ShortUrls.FirstOrDefaultAsync(s => s.ShortCode == shortCode);
        return shortUrl is null ? null : MapToResponse(shortUrl, baseUrl);
    }

    public async Task<bool> DeactivateAsync(string shortCode)
    {
        var shortUrl = await _context.ShortUrls.FirstOrDefaultAsync(s => s.ShortCode == shortCode);
        if (shortUrl is null) return false;
        shortUrl.IsActive = false;
        await _context.SaveChangesAsync();
        return true;
    }

    // -------- Private Helpers --------
    private async Task<string> GenerateUniqueCodeAsync()
    {
        string code;
        do
        {
            code = GenerateCode();
        }
        while (await _context.ShortUrls.AnyAsync(s => s.ShortCode == code));

        return code;
    }

    private static string GenerateCode()
    {
        var random = new Random();
        return new string(Enumerable.Range(0, CodeLength).Select(_ => Alphabet[random.Next(Alphabet.Length)]).ToArray());
    }

    private static ShortUrlResponseDto MapToResponse(ShortUrl s, string baseUrl) => new()
    {
        Id = s.Id,
        OriginalUrl = s.OriginalUrl,
        ShortCode = s.ShortCode,
        ShortUrl = string.IsNullOrEmpty(baseUrl) ? s.ShortCode : $"{baseUrl}/{s.ShortCode}",
        CreatedAt = s.CreatedAt,
        ExpiresAt = s.ExpiresAt,
        IsActive = s.IsActive,
        TotalClicks = s.TotalClicks
    };
}
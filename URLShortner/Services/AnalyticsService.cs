using Microsoft.EntityFrameworkCore;
using UrlShortener.Data;
using UrlShortener.DTOs;

namespace UrlShortener.Services;

public class AnalyticsService : IAnalyticsService
{
    private readonly AppDbContext _context;
    public AnalyticsService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ClickAnalyticsDto?> GetAnalyticsAsync(string shortCode, int recentClicksLimit = 10)
    {
        var shortUrl = await _context.ShortUrls.Include(s => s.ClickEvents).FirstOrDefaultAsync(s => s.ShortCode == shortCode);
        if (shortUrl is null) return null;

        // Group clicks by date
        var clicksByDate = shortUrl.ClickEvents.GroupBy(c => c.ClickedAt.ToString("yyyy-MM-dd")).ToDictionary(g => g.Key, g => g.Count());

        // Group clicks by country
        var clicksByCountry = shortUrl.ClickEvents.GroupBy(c => string.IsNullOrEmpty(c.Country) ? "Unknown" : c.Country).ToDictionary(g => g.Key, g => g.Count());

        // Get recent N clicks
        var recentClicks = shortUrl.ClickEvents.OrderByDescending(c => c.ClickedAt).Take(recentClicksLimit).Select(c => new ClickEventDto
        {
            ClickedAt = c.ClickedAt,
            IpAddress = c.IpAddress,
            UserAgent = c.UserAgent,
            Referrer = c.Referrer,
            Country = c.Country,
        }).ToList();

        return new ClickAnalyticsDto
        {
            TotalClicks = shortUrl.TotalClicks,
            OriginalUrl = shortUrl.OriginalUrl,
            ShortCode = shortUrl.ShortCode,
            CreatedAt = shortUrl.CreatedAt,
            ExpiresAt = shortUrl.ExpiresAt,
            RecentClicks = recentClicks,
            ClicksByDate = clicksByDate,
            ClicksByCountry = clicksByCountry
        };
    }
}
using UrlShortener.DTOs;

namespace UrlShortener.Services;

public interface IAnalyticsService
{
    Task<ClickAnalyticsDto?> GetAnalyticsAsync(string shortCode, int recentClicksLimit = 10);
}
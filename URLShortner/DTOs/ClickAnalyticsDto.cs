namespace UrlShortener.DTOs;

public class ClickAnalyticsDto
{
    public string ShortCode { get; set; } = string.Empty;
    public string OriginalUrl { get; set; } = string.Empty;
    public int TotalClicks { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ExpiresAt { get; set; }
    public List<ClickEventDto> ClickEvents { get; set; } = new();
    public Dictionary<string, int> ClicksByCountry { get; set; } = new();
    public Dictionary<string, int> ClicksByDate { get; set; } = new();
}

public class ClickEventDto
{
    public DateTime ClickedAt { get; set; }
    public string? IpAddress { get; set; }
    public string? UserAgent { get; set; }
    public string? Referrer { get; set; }
    public string? Country { get; set; }
}
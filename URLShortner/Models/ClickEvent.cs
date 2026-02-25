namespace UrlShortener.Models;

public class ClickEvent
{
    public int Id { get; set; }
    public int ShortUrlId { get; set; }
    public DateTime ClickedAt { get; set; } = DateTime.UtcNow;
    public string? IpAddress { get; set; }
    public string? UserAgent { get; set; }
    public string? Referrer { get; set; }
    public string? Country { get; set; } // Can be controlled via Ip address later

    // Navigation propery
    public ShortUrl ShortUrl { get; set; } = null!;
}
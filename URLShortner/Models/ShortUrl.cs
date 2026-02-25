namespace UrlShortener.Models;

public class ShortUrl
{
    public int Id { get; set; }
    public string OriginalUrl { get; set; } = string.Empty;
    public string ShortCode { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? ExpiresAt { get; set; }
    public bool IsActive { get; set; } = true;
    public int TotalClicks { get; set; } = 0;

    // Navigation property for related Clicks
    public ICollection<ClickEvent> ClickEvents { get; set; } = new List<ClickEvent>();
}
using System.ComponentModel.DataAnnotations;

namespace UrlShortener.DTOs;

public class CreateShortURLDto
{
    [Required(ErrorMessage = "Original URL is required.")]
    [Url(ErrorMessage = "Please enter a valid URL.")]
    public string OriginalUrl { get; set; } = string.Empty;

    [StringLength(20, MinimumLength = 3, ErrorMessage = "Short code must be between 3 and 20 characters.")]
    [RegularExpression(@"^[a-zA-Z0-9_-]*$", ErrorMessage = "Short code can only contain letters, numbers, underscores, and hyphens.")]
    public string? CustomCode { get; set; }

    public DateTime? ExpiresAt { get; set; }
}
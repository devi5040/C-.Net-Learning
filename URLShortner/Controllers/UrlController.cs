using Microsoft.AspNetCore.Mvc;
using UrlShortener.DTOs;
using UrlShortener.Services;

namespace UrlShortener.Controllers;

[ApiController]
[Route("api/urls")]
public class UrlController : ControllerBase
{
    private readonly IUrlShortenerService _service;

    public UrlController(IUrlShortenerService service)
    {
        _service = service;
    }

    // POST /api/urls
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> Create([FromBody] CreateShortURLDto dto)
    {
        string baseUrl = $"{Request.Scheme}://{Request.Host}";
        var result = await _service.CreateShortUrlAsync(dto, baseUrl);
        return CreatedAtAction(nameof(GetByCode), new { shortCode = result.ShortCode }, result);
    }

    // GET /api/urls
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAll()
    {
        string baseUrl = $"{Request.Scheme}://{Request.Host}";
        var all = await _service.GetAllAsync();

        // Re-attach base URL (service returns code-only shortUrl for list queries)
        var result = all.Select(s => new ShortUrlResponseDto
        {
            Id = s.Id,
            OriginalUrl = s.OriginalUrl,
            ShortCode = s.ShortCode,
            ShortUrl = $"{baseUrl}/{s.ShortCode}",
            CreatedAt = s.CreatedAt,
            ExpiresAt = s.ExpiresAt,
            IsActive = s.IsActive,
            TotalClicks = s.TotalClicks
        });
        return Ok(result);
    }

    [HttpGet("{shortCode}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByCode(string shortCode)
    {
        string baseUrl = $"{Request.Scheme}://{Request.Host}";
        var result = await _service.GetByCodeAsync(shortCode, baseUrl);
        return result is null ? NotFound(new { error = $"Short code {shortCode} not found" }) : Ok(result);
    }

    [HttpDelete("{shortCode}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Deactivate(string shortCode)
    {
        var success = await _service.DeactivateAsync(shortCode);
        return success ? NoContent() : NotFound(new { error = $"Short code {shortCode} not found" });
    }
}

using Microsoft.AspNetCore.Mvc;
using UrlShortener.Services;

namespace UrlShortener.Controllers;

[ApiController]
public class RedirectController : ControllerBase
{
    private readonly IUrlShortenerService _service;

    public RedirectController(IUrlShortenerService service)
    {
        _service = service;
    }

    // GET /{shortCode}  →  302 redirect to original URL
    [HttpGet("/{shortCode}")]
    [ProducesResponseType(StatusCodes.Status302Found)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status410Gone)]
    public async Task<IActionResult> RedirectURL(string shortCode)
    {
        // Guard against hitting swagger/api routes
        if (shortCode.StartsWith("api") || shortCode.StartsWith("swagger"))
            return NotFound();

        var originalUrl = await _service.ResolveAndTrackAsync(shortCode, HttpContext);

        if (originalUrl is null)
            return StatusCode(410, new { error = "This link has expired or does not exist." });

        return Redirect(originalUrl);
    }
}
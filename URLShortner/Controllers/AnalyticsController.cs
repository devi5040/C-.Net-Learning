using Microsoft.AspNetCore.Mvc;
using UrlShortener.Services;

namespace UrlShortener.Controllers;

[ApiController]
[Route("api/analytics")]
public class AnalyticsController : ControllerBase
{
    private readonly IAnalyticsService _analyticsService;

    public AnalyticsController(IAnalyticsService analyticsService)
    {
        _analyticsService = analyticsService;
    }

    // GET api/analytics/abc1234
    [HttpGet("{shortCode}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAnalytics(string shortCode, [FromQuery] int limit = 10)
    {
        var analytics = await _analyticsService.GetAnalyticsAsync(shortCode, limit);
        return analytics is null
            ? NotFound(new { error = $"No analytics found for code '{shortCode}'." })
            : Ok(analytics);
    }
}
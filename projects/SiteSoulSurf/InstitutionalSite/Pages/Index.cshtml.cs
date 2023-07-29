using Microsoft.AspNetCore.Mvc.RazorPages;

using Microsoft.Extensions.Logging;

namespace InstitutionalSite.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        _logger.LogDebug("Test debug");
        _logger.LogError("Test error");
        _logger.LogTrace("Test trace");
        _logger.LogInformation("Test info");
        _logger.LogWarning("Test warn");
        _logger.LogCritical("Test critical");
    }
}

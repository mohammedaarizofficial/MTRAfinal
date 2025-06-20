using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MTRADashboard.Pages;

public class LandTransportModel : PageModel
{
    private readonly ILogger<LandTransportModel> _logger;

    public LandTransportModel(ILogger<LandTransportModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        
    }
}

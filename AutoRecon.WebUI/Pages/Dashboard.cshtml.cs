using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutoRecon.WebUI.Pages
{
    public class DashboardModel(ILogger<DashboardModel> logger) : PageModel
    {
        private readonly ILogger<DashboardModel> _logger = logger;

        public void OnGet()
        {

        }
    }
}

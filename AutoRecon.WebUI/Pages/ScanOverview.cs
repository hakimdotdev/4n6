using AutoRecon.Domain.Entities.Recon;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoRecon.WebUI.Pages
{
    public class ForensicsScanOverviewModel : PageModel
    {
        // private readonly IHubContext<ConsoleOutputHub> _hubContext;

        // public ScanOverviewModel(IHubContext<ConsoleOutputHub> hubContext) => _hubContext = hubContext;

        public List<Target> Targets { get; set; }

        public async Task OnGetAsync()
        {
            // Load list of targets for the scan
            // Targets = await TargetService.GetAllTargetsAsync();
        }
    }
}

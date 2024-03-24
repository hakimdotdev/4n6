using AutoRecon.Domain.Entities.Recon;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutoRecon.WebUI.Pages
{
    public class NewScanModel : PageModel
    {
        public bool AllModules { get; set; }
        public ScanRequest ScanRequest { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            VerifyModulesAndTargets();
        }

        private void VerifyModulesAndTargets()
        {
            _ = ScanRequest.Targets;
            _ = ScanRequest.Modules;
        }
    }
}
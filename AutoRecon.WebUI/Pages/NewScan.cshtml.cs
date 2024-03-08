using AutoRecon.Domain.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutoRecon.WebUI.Pages
{
    public class NewScanModel : PageModel
    {
        public required ScanRequest ScanRequest { get; set; }
        public void OnGet()
        {
        }
        public void OnPost() 
        {
            VerifyModulesAndTargets();
        }

        private void VerifyModulesAndTargets()
        {
            var targets = ScanRequest.Targets;
            var modules = ScanRequest.Modules;


        }
    }
}

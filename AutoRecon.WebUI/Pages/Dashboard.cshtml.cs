using AutoRecon.Domain.Entities.Azure;
using AutoRecon.Domain.Entities.Recon;
using AutoRecon.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutoRecon.WebUI.Pages
{
    public class Dashboard(AutoReconDbContext context) : PageModel
    {
        public List<AzureVm> UserVirtualMachines { get; set; }
        public List<Scan> UserScans { get; set; }

        public List<Blob> UserBlobs { get; set; }
        public int TotalScans { get; set; }
        public int TotalVirtualMachines { get; set; }
        public int TotalBlobs { get; set; }

        public void OnGet()
        {
            //UserVirtualMachines = _context.AzureVms
            //    .Where(vm => vm.CreatedBy != null && vm.CreatedBy.UserName == User.Identity.Name)
            //    .ToList();

            //UserScans = _context.Scans
            //    .Where(scan => scan.CreatedBy != null && scan.CreatedBy.UserName == User.Identity.Name)
            //    .ToList();

            //UserBlobs = _context.Blobs
            //    .Where(blob => blob.CreatedBy != null && blob.CreatedBy.UserName == User.Identity.Name)
            //    .ToList();

            //TotalScans = UserScans.Count;
            //TotalVirtualMachines = UserVirtualMachines.Count;
            //TotalBlobs = UserBlobs.Count;
        }
    }
}
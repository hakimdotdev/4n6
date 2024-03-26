using AutoRecon.Domain.Entities.Azure;
using AutoRecon.Infrastructure;
using AutoRecon.Infrastructure.Data.Context;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutoRecon.WebUI.Pages;

public class Dashboard(AutoReconDbContext context) : PageModel
{
    private readonly AutoReconDbContext _context = context;
    public required List<AzureVm> UserVirtualMachines { get; set; }


    public required List<Blob> UserBlobs { get; set; }

    public int TotalVirtualMachines { get; set; }
    public int TotalBlobs { get; set; }

    public void OnGet()
    {
        UserVirtualMachines =
            [.. _context.AzureVms.Where(vm => vm.CreatedBy != null && vm.CreatedBy.UserName == User.Identity.Name)];


        UserBlobs =
        [
            .. _context.Blobs.Where(blob => blob.CreatedBy != null && blob.CreatedBy.UserName == User.Identity.Name)
        ];


        TotalVirtualMachines = UserVirtualMachines.Count;
        TotalBlobs = UserBlobs.Count;
    }
}
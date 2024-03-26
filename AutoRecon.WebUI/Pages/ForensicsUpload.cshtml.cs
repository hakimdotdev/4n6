using AutoRecon.Application.Interfaces;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutoRecon.WebUI.Pages;

public class ForensicsUpload(IMediator mediator, ICommandFactory commandFactory, IFileUploadService fileUploadService)
    : PageModel
{
    private readonly ICommandFactory _commandFactory = commandFactory;
    private readonly IFileUploadService _fileUploadService = fileUploadService;
    private readonly IMediator _mediator = mediator;
    public bool IsResponse { get; set; }
    public bool IsSuccess { get; set; }
    public object Message { get; set; }

    public async Task<IActionResult> OnPostAsync(IFormFile file, string selectedHostingEnvironment)
    {
        if (file.Length == 0)
        {
            ModelState.AddModelError("File", "No or invalid file");
            return Page();
        }

        var upload = await fileUploadService.UploadFileAsync(file);
        var vmService = _commandFactory.GetVmCreationCommandExecutor(selectedHostingEnvironment,
            Guid.NewGuid() + "-" + file.FileName,
            upload.Path);
        // await mediator.Send(vmService(vmService, file.FileName, result.Path));

        // if (result.Success) return RedirectToPage("/Index");
        // ModelState.AddModelError("File", result.ErrorMessage);
        return Page();
    }
}
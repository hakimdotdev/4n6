using AutoRecon.Domain.Entities;
using AutoRecon.Domain.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mediator;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace AutoRecon.WebUI.Pages
{
    public class ForensicsUpload : PageModel
    {
        private readonly IMediator _mediator;

        public ForensicsUpload(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [BindProperty]
        public IFormFile ForensicImage { get; set; }

        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }

        [TempData]
        public string Message { get; set; }
        [TempData]
        public bool IsSuccess { get; set; }
        [TempData]
        public bool IsResponse { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ForensicImage?.Length > 0)
            {
                if (!IsValidFile(ForensicImage))
                {
                    Message = "Invalid file type or size.";
                    IsSuccess = false;
                    IsResponse = true;
                    return Page();
                }

                var metadata = await ExtractMetadata(ForensicImage);
                // Create metadata entity and upload it

                await _mediator.Send(new UploadForensicImageCommand(ForensicImage));

                Message = "File uploaded successfully.";
                IsSuccess = true;
                IsResponse = true;

                return Page();
            }

            return BadRequest("No file uploaded.");
        }

        private async Task<MetadataInfo> ExtractMetadata(IFormFile file)
        {
            try {
                var filePath = Path.GetTempFileName();
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var shellAppType = Type.GetTypeFromProgID("Shell.Application");

                ArgumentNullException.ThrowIfNull(shellAppType);

                dynamic shellApp = Activator.CreateInstance(shellAppType);

                ArgumentException.ThrowIfNullOrEmpty(shellApp);

                var folder = shellApp.NameSpace(filePath);

                var description = folder.GetDetailsOf(folder.Items().Item(0), 5); // Description

                return new MetadataInfo
                {
                    Description = description
                };
            }
            catch {
                throw;
            }
        }

private bool IsValidFile(IFormFile file)
{
    if (file == null || file.Length == 0)
        return false;

    const long maxFileSize = 1L * 1024L * 1024L * 1024L * 1024L; // 1 TB

    if (file.Length > maxFileSize)
        return false;

    if (!HasValidExtension(file))
        return false;

    if (!HasValidContentType(file))
        return false;

    return true;
}

private bool HasValidExtension(IFormFile file)
{
    var validExtensions = new[] { ".vhdx" };
    var extension = Path.GetExtension(file.FileName).ToLower();
    return validExtensions.Contains(extension);
}

private bool HasValidContentType(IFormFile file)
{
    var validContentTypes = new[] { "application/octet-stream", "application/vnd.ms-excel" };
    var contentType = file.ContentType.ToLower();
    return validContentTypes.Contains(contentType);
}

    }


}
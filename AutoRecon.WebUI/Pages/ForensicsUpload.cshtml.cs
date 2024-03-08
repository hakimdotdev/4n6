using AutoRecon.Application.Commands;
using Mediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;

namespace AutoRecon.WebUI.Pages
{
    public class ForensicsUpload : PageModel
    {
        private readonly IMediator _mediator;

        public ForensicsUpload(IMediator mediator)
        {
            _mediator = mediator;
        }

        [BindProperty]
        public IFormFile ForensicImage { get; set; }

        public UploadInfo UploadInfo { get; set; }

        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsResponse { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ForensicImage != null && ForensicImage.Length > 0)
            {
                var filePath = Path.GetTempFileName();
                await using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ForensicImage.CopyToAsync(stream);
                }

                await _mediator.Send(new CreateAzureVmCommand(Name, filePath)); 

                UploadInfo = new UploadInfo
                {
                    FileName = ForensicImage.FileName,
                    ContentType = ForensicImage.ContentType,
                    Size = ForensicImage.Length
                };

                return Page();
            }

            return BadRequest("No file uploaded.");
        }
    }

    public class UploadInfo
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public long Size { get; set; }
    }
}

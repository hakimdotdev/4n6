using Mediator;
using Microsoft.AspNetCore.Http;

namespace AutoRecon.WebUI.Pages
{
    public class UploadForensicImageCommand(IFormFile file) : IRequest<object>
    {
  
    }
}
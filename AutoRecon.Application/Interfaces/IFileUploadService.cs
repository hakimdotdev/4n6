using AutoRecon.Application.Services;

namespace AutoRecon.Application.Interfaces;

public interface IFileUploadService
{
    Task<FileUploadResult> UploadFileAsync(IFormFile file);
}
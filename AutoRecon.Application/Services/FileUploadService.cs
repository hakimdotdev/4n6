using AutoRecon.Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace AutoRecon.Application.Services;

public class FileUploadService : IFileUploadService
{
    private const string permittedExtension = ".vhdx";

    private readonly Dictionary<string, List<byte[]>> _fileSignature =
        new()
        {
            {
                permittedExtension, [
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE2 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE3 }
                ]
            }
        };


    public async Task<FileUploadResult> UploadFileAsync(IFormFile file)
    {
        try
        {
            // using (var reader = new BinaryReader(uploadedFileData))
            // {
            //     var signatures = _fileSignature[ext];
            //     var headerBytes = reader.ReadBytes(signatures.Max(m => m.Length));
            //
            //     if (!(signatures.Any(signature => 
            //         headerBytes.Take(signature.Length).SequenceEqual(signature))))
            //     {
            //         return false;
            //     };
            // }
            var filePath = "images/" + Guid.NewGuid() + file.FileName;
            await using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return new FileUploadResult { Success = true, Path = filePath };
        }
        catch (Exception ex)
        {
            return new FileUploadResult { Success = false, ErrorMessage = ex.Message };
        }
    }
}
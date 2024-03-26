namespace AutoRecon.Application.Services;

public class FileUploadResult
{
    public bool Success { get; set; }
    public string Path { get; set; }
    public string ErrorMessage { get; set; }
}
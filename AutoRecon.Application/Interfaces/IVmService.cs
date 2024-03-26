namespace AutoRecon.Application.Interfaces;

public interface IVmService
{
    Task CreateVmAsync(string vmName, CloudProvider provider);
    Task UploadForensicImageAsync(string vmName, byte[] image, CloudProvider provider);

    Task StartAsync(string vmName);

    Task StopAsync(string vmName);
}

public enum CloudProvider
{
    Azure,
    AWS,
    VMware
}
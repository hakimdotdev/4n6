using AutoRecon.Application.Interfaces;

namespace AutoRecon.Application.Services.Vm;

public class VmWareVmService : IVmService
{
    public Task CreateVmAsync(string vmName, CloudProvider provider)
    {
        throw new NotImplementedException();
    }

    public Task UploadForensicImageAsync(string vmName, byte[] image, CloudProvider provider)
    {
        throw new NotImplementedException();
    }

    public Task StartAsync(string vmName)
    {
        throw new NotImplementedException();
    }

    public Task StopAsync(string vmName)
    {
        throw new NotImplementedException();
    }
}
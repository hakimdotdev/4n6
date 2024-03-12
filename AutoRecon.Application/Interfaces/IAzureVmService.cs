using Azure.ResourceManager.Compute;

namespace AutoRecon.Application.Interfaces
{
    public interface IAzureVmService
    {
        Task Startsync(string vmName);

        Task StopAsync(string vmName);

        Task CreateAsync(VirtualMachineResource vmParams);

        Task DeleteAsync(VirtualMachineResource vmParams);
    }
}
using AutoRecon.Application.Interfaces;
using Azure.Identity;
using Azure.ResourceManager;

namespace AutoRecon.Application.Services.Vm;

public class AzureVmService : IVmService
{
    private readonly ArmClient _armClient = new(new DefaultAzureCredential());

    //public AzureVmService(ComputeManagementClient computeManagementClient)
    //{
    //    _computeManagementClient = computeManagementClient;
    //}

    async Task IVmService.CreateVmAsync(string vmName, CloudProvider provider)
    {
        var rgName = "myResourceGroup";
        // ResourceGroup rg = await _armClient.DefaultSubscription.GetResourceGroups().GetAsync(rgName);
        // await foreach (VirtualMachine vm in rg.GetVirtualMachines().GetAllAsync())
        //     await vm.StartPowerOff().WaitForCompletionAsync();
    }


    Task IVmService.UploadForensicImageAsync(string vmName, byte[] image, CloudProvider provider)
    {
        throw new NotImplementedException();
    }

    Task IVmService.StartAsync(string vmName)
    {
        throw new NotImplementedException();
    }

    Task IVmService.StopAsync(string vmName)
    {
        throw new NotImplementedException();
    }
}
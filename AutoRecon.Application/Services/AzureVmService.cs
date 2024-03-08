using AutoRecon.Application.Interfaces;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using System.Threading.Tasks;
using static AutoRecon.Application.Commands.CreateAzureVmCommandHandler;

public class AzureVmService : IAzureVmService
{
    private readonly ComputeManagementClient _computeManagementClient;

    //public AzureVmService(ComputeManagementClient computeManagementClient)
    //{
    //    _computeManagementClient = computeManagementClient;
    //}

    public async Task CreateAsync(VirtualMachine vmParams)
    {
        //var vm = new VirtualMachine
        //{
        //    Location = vmParams.Location, // Location of the Azure VM
        //    OsProfile = new OSProfile
        //    {
        //        ComputerName = vmParams.VmName,
        //        AdminUsername = vmParams.AdminUsername,
        //        AdminPassword = vmParams.AdminPassword,
        //        WindowsConfiguration = new WindowsConfiguration
        //        {
        //            ProvisionVMAgent = true,
        //            EnableAutomaticUpdates = true
        //        }
        //    },
        //    HardwareProfile = new HardwareProfile
        //    {
        //        VmSize = vmParams.VmSize // Size of the Azure VM (e.g., Standard_DS1_v2)
        //    },
        //    StorageProfile = new StorageProfile
        //    {
        //        OsDisk = new OSDisk
        //        {
        //            Name = vmParams.OsDiskName,
        //            CreateOption = DiskCreateOptionTypes.FromImage,
        //            ManagedDisk = new ManagedDiskParameters
        //            {
        //                StorageAccountType = StorageAccountTypes.StandardLRS // Choose appropriate storage account type
        //            }
        //        },
        //        DataDisks = new List<DataDisk>
        //        {
        //            new DataDisk
        //            {
        //                Lun = 0,
        //                DiskSizeGB = vmParams.DataDiskSizeGB,
        //                CreateOption = DiskCreateOptionTypes.Empty,
        //                ManagedDisk = new ManagedDiskParameters
        //                {
        //                    StorageAccountType = StorageAccountTypes.StandardLRS // Choose appropriate storage account type
        //                }
        //            }
        //        }
        //    },
        //    NetworkProfile = vmParams.
        //};

        //var operationResponse = await _computeManagementClient.VirtualMachines.CreateOrUpdateAsync(
        //    resourceGroupName: ,
        //    vmName: vmParams.VmName,
        //    parameters: vm);

        // Handle the operation response as needed
    }

    public Task DeleteAsync(VirtualMachine vmParams)
    {
        throw new NotImplementedException();
    }

    public Task Startsync(string vmName)
    {
        throw new NotImplementedException();
    }

    public Task StopAsync(string vmName)
    {
        throw new NotImplementedException();
    }
}

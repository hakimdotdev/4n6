using AutoRecon.Domain.Common;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Compute.Models;

namespace AutoRecon.Infrastructure
{
    public class AzureVmCommandExecutor(string clientId, string clientSecret, string tenantId, string subscriptionId, string resourceGroupName, string vmName) : ICommandExecutor
    {
        //private readonly string _clientId = clientId;
        //private readonly string _clientSecret = clientSecret;
        //private readonly string _tenantId = tenantId;
        //private readonly string _subscriptionId = subscriptionId;
        //private readonly string _resourceGroupName = resourceGroupName;
        //private readonly string _vmName = vmName;
        private const string subscriptionId = "24fb23e3-6ba3-41f0-9b6e-e41131d5d61e";

        private const string resourceGroupName = "crptestar98131";
        private const string vmName = "vm3036";

        public async Task ExecAsync(string command, string[] args, CancellationToken cancellationToken = default)
        {
            ArmClient armClient = new(new DefaultAzureCredential());
            _ = await armClient.GetDefaultSubscriptionAsync(cancellationToken);

            RunCommandInput input = new("RunPowerShellScript");

            // authenticate client

            ResourceIdentifier virtualMachineResourceId = VirtualMachineResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, vmName);
            VirtualMachineResource virtualMachine = armClient.GetVirtualMachineResource(virtualMachineResourceId);

            await virtualMachine.RunCommandAsync(WaitUntil.Completed, input, cancellationToken);
        }

        public async Task<(string, string)> ExecBufferedAsync(string command, string[] args, CancellationToken cancellationToken = default)
        {
            ArmClient armClient = new(new DefaultAzureCredential());
            _ = await armClient.GetDefaultSubscriptionAsync(cancellationToken);

            RunCommandInput input = new("RunPowerShellScript");

            // authenticate client

            ResourceIdentifier virtualMachineResourceId = VirtualMachineResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, vmName);
            VirtualMachineResource virtualMachine = armClient.GetVirtualMachineResource(virtualMachineResourceId);
            _ = await virtualMachine.RunCommandAsync(WaitUntil.Completed, input, cancellationToken);

            return ("a", "b");
        }
    }
}
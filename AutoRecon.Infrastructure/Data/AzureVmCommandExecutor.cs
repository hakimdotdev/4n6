using AutoRecon.Domain.Common;
using CliWrap;
using CliWrap.Buffered;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Rest.Azure.Authentication;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AutoRecon.Infrastructure
{
    public class AzureVmCommandExecutor(string clientId, string clientSecret, string tenantId, string subscriptionId, string resourceGroupName, string vmName) : ICommandExecutor
    {
        private readonly string _clientId = clientId;
        private readonly string _clientSecret = clientSecret;
        private readonly string _tenantId = tenantId;
        private readonly string _subscriptionId = subscriptionId;
        private readonly string _resourceGroupName = resourceGroupName;
        private readonly string _vmName = vmName;

        public async Task ExecAsync(string command, string[] args, CancellationToken cancellationToken = default)
        {
            var serviceCredentials = ApplicationTokenProvider.LoginSilentAsync(_tenantId, _clientId, _clientSecret).Result;

            var computeManagementClient = new ComputeManagementClient(serviceCredentials)
            {
                SubscriptionId = _subscriptionId
            };

            var runCommandParams = new RunCommandInput
            {
                CommandId = "RunPowerShellScript",
                Script = [command]
            };

            await computeManagementClient.VirtualMachines.RunCommandAsync(_resourceGroupName, _vmName, runCommandParams, cancellationToken: cancellationToken);
        }

        public async Task<(string, string)> ExecBufferedAsync(string command, string[] args, CancellationToken cancellationToken = default)
        {
            var serviceCredentials = ApplicationTokenProvider.LoginSilentAsync(_tenantId, _clientId, _clientSecret).Result;

            var computeManagementClient = new ComputeManagementClient(serviceCredentials)
            {
                SubscriptionId = _subscriptionId
            };

            var runCommandParams = new RunCommandInput
            {
                CommandId = "RunPowerShellScript",
                Script = [command]
            };

            var runCommandResult = await computeManagementClient.VirtualMachines.RunCommandAsync(_resourceGroupName, _vmName, runCommandParams, cancellationToken: cancellationToken);
            return (runCommandResult.Value[0].Message, runCommandResult.Value[0].DisplayStatus);
        }
    }
}

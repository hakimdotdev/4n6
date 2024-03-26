using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Compute.Models;
using Mediator;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AutoRecon.Application.Commands.AzureVm;

public class CreateAzureVmCommand(string virtualMachineName, string vhdFilePath) : IRequest<Unit>
{
    public string VirtualMachineName { get; } = virtualMachineName;
    public string VhdFilePath { get; } = vhdFilePath;
}

public class CreateAzureVmCommandHandler : IRequestHandler<CreateAzureVmCommand, Unit>
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<CreateAzureVmCommandHandler> _logger;
    private readonly IMediator _mediator;

    public CreateAzureVmCommandHandler(IMediator mediator, IConfiguration configuration,
        ILogger<CreateAzureVmCommandHandler> logger)
    {
        _mediator = mediator;
        _configuration = configuration;
        _logger = logger;
    }

    public async ValueTask<Unit> Handle(CreateAzureVmCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var clientId = _configuration["Azure:ClientId"];
            var clientSecret = _configuration["Azure:ClientSecret"];
            var tenantId = _configuration["Azure:TenantId"];
            var subscriptionId = _configuration["Azure:SubscriptionId"];
            var resourceGroupName = _configuration["Azure:ResourceGroupName"];

            var credentials = new ClientSecretCredential(tenantId, clientId, clientSecret);
            var armClient = new ArmClient(credentials);
            var subscription = await armClient.GetDefaultSubscriptionAsync();
            var resourceGroup = await subscription.GetResourceGroups().GetAsync(resourceGroupName);
            var vmCollection = resourceGroup.Value.GetVirtualMachines();
            var vmName = request.VirtualMachineName;

            var vhdBlobUri = await _mediator.Send(new CreateAzureBlobCommand(vmName, request.VhdFilePath),
                cancellationToken);

            var osType = await DetermineOperatingSystemType(vhdBlobUri, cancellationToken);

            var vmData = new VirtualMachineData(resourceGroup.Value.Data.Location)
            {
                HardwareProfile = new VirtualMachineHardwareProfile { VmSize = VirtualMachineSizeType.StandardF2 },
                OSProfile = new VirtualMachineOSProfile
                {
                    AdminUsername = "adminUser",
                    ComputerName = vmName
                },
                NetworkProfile = new VirtualMachineNetworkProfile
                {
                    NetworkInterfaces =
                    {
                        new VirtualMachineNetworkInterfaceReference
                        {
                            Id = new ResourceIdentifier(
                                $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkInterfaces/<nicName>"),
                            Primary = true
                        }
                    }
                },
                StorageProfile = new VirtualMachineStorageProfile
                {
                    OSDisk = new VirtualMachineOSDisk(DiskCreateOptionType.FromImage)
                    {
                        OSType = SupportedOperatingSystemType.Windows,
                        Name = Guid.NewGuid().ToString(),
                        VhdUri = new Uri(vhdBlobUri),
                        Caching = CachingType.ReadWrite
                    }
                }
            };

            var vmOperation =
                await vmCollection.CreateOrUpdateAsync(WaitUntil.Completed, vmName, vmData, cancellationToken);

            _logger.LogInformation("Azure virtual machine creation initiated.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating Azure VM");
            throw;
        }

        return Unit.Value;
    }

    private async Task<SupportedOperatingSystemType> DetermineOperatingSystemType(string vhdBlobUri,
        CancellationToken cancellationToken)
    {
        // Add logic to determine the operating system type based on the VHDX file
        // For example, you can inspect the VHDX file or its metadata
        return SupportedOperatingSystemType.Windows; // Placeholder implementation
    }
}
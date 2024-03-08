using Microsoft.Azure.Management.Compute;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Rest.Azure.Authentication;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Azure.Management.Compute.Models;
using AutoRecon.Application.Interfaces;
using Mediator;

namespace AutoRecon.Application.Commands
{
    public class CreateAzureVmCommand(string vmName, string vhdFilePath) : IRequest<Unit>
    {
        public string VmName { get; } = vmName;
        public string VhdFilePath { get; } = vhdFilePath;
    }

    public class CreateAzureVmCommandHandler(IConfiguration configuration, IAzureVmService azureVmService, ILogger<CreateAzureVmCommandHandler> logger) : IRequestHandler<CreateAzureVmCommand, Unit>
    {
        private readonly IConfiguration _configuration = configuration;
        private readonly IAzureVmService _azureVmService = azureVmService;
        private readonly ILogger<CreateAzureVmCommandHandler> _logger = logger;

        public async ValueTask<Unit> Handle(CreateAzureVmCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var clientId = _configuration["Azure:ClientId"];
                var clientSecret = _configuration["Azure:ClientSecret"];
                var tenantId = _configuration["Azure:TenantId"];
                var subscriptionId = _configuration["Azure:SubscriptionId"];
                var resourceGroupName = _configuration["Azure:ResourceGroupName"];
                var containerName = _configuration["Azure:BlobStorageContainerName"];

                var serviceCredentials = await ApplicationTokenProvider.LoginSilentAsync(tenantId, clientId, clientSecret);
                var computeManagementClient = new ComputeManagementClient(serviceCredentials)
                {
                    SubscriptionId = subscriptionId
                };

                var blobServiceClient = new BlobServiceClient(_configuration["Azure:BlobStorageConnectionString"]);
                var blobContainerClient = blobServiceClient.GetBlobContainerClient(containerName);
                await blobContainerClient.CreateIfNotExistsAsync(cancellationToken: cancellationToken);

                var blobClient = blobContainerClient.GetBlobClient(Path.GetFileName(request.VhdFilePath));
                await blobClient.UploadAsync(request.VhdFilePath, true, cancellationToken);

                var vhdUri = blobClient.Uri.ToString();

                var vmParams = new VirtualMachine();

                await _azureVmService.CreateAsync(vmParams);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating Azure VM");
                throw;
            }

            return Unit.Value;
        }



        public class VirtualMachineParams
        {
            public string ResourceGroupName { get; set; }
            public string VmName { get; set; }
            public string VhdUri { get; set; }
        }
    }
}

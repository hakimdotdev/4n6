using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using AutoRecon.Application.Interfaces;
using Mediator;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager;
using Azure.Core;

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

                //ArmClient armClient = new(DefaultAu);

                var blobServiceClient = new BlobServiceClient(_configuration["Azure:BlobStorageConnectionString"]);
                var blobContainerClient = blobServiceClient.GetBlobContainerClient(containerName);
                await blobContainerClient.CreateIfNotExistsAsync(cancellationToken: cancellationToken);

                var blobClient = blobContainerClient.GetBlobClient(Path.GetFileName(request.VhdFilePath));
                var blobResponse = await blobClient.UploadAsync(request.VhdFilePath, true, cancellationToken);

                _logger.LogInformation("Successfully uploaded to blob storage. {r}", blobResponse);
                var vhdUri = blobClient.Uri.ToString();

                // TODO: Handeln der Location, Reminder für Forensik in Bezug GDPR DSGVO in Readme
                //var vmParams = new VirtualMachineData(AzureLocation.);
                //VirtualMachineResource resource = new() { }
                //await _azureVmService.CreateAsync(vmParams);
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
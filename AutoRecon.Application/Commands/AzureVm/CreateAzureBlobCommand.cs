using AutoRecon.Application.Interfaces;
using Azure.Storage.Blobs;
using Mediator;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AutoRecon.Application.Commands.AzureVm;

public class CreateAzureBlobCommand(string vmName, string vhdFilePath) : IRequest<string>
{
    public string VmName { get; } = vmName;
    public string VhdFilePath { get; } = vhdFilePath;
}

public class CreateAzureBlobCommandHandler(
    IConfiguration configuration,
    IVmService azureVmService,
    ILogger<CreateAzureBlobCommandHandler> logger) : IRequestHandler<CreateAzureBlobCommand, string>
{
    private readonly IVmService _azureVmService = azureVmService;
    private readonly IConfiguration _configuration = configuration;
    private readonly ILogger<CreateAzureBlobCommandHandler> _logger = logger;

    public async ValueTask<string> Handle(CreateAzureBlobCommand request, CancellationToken cancellationToken)
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

            return blobClient.Uri.ToString();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating Azure VM");
            throw;
        }
    }

    public class VirtualMachineParams
    {
        public string ResourceGroupName { get; set; }
        public string VmName { get; set; }
        public string VhdUri { get; set; }
    }
}
using AutoRecon.Domain.Common;

namespace AutoRecon.Domain.Entities.Azure;

public sealed class Blob(
    string name,
    string contentType,
    long size,
    string url,
    string blobId) : BaseAuditableEntity
{
    public required string Name { get; init; } = name;
    public string ContentType { get; init; } = contentType;
    public long Size { get; init; } = size;
    public string Url { get; init; } = url;
    public string BlobId { get; init; } = blobId;

    public IList<AzureVm> AzureVms { get; init; } = new List<AzureVm>();
}
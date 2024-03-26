using AutoRecon.Domain.Common;

namespace AutoRecon.Domain.Entities.Azure;

public sealed class AzureVm(string resourceGroupName, Blob blob, string name, string location, Guid vmId)
    : BaseAuditableEntity
{
    public required string ResourceGroupName { get; init; } = resourceGroupName;
    public Blob Blob { get; init; } = blob;
    public required string Name { get; init; } = name;
    public required string Location { get; init; } = location;
    public Guid VmId { get; init; } = vmId;
}
using AutoRecon.Domain.Common;

namespace AutoRecon.Domain.Entities.Forensics;

public class ForensicImage : BaseAuditableEntity
{
    public required string Description { get; set; }
    public required string FileName { get; set; }
    public required MetadataInfo Metadata { get; set; }
}

public class MetadataInfo : BaseAuditableEntity
{
    //FIXME:
    public required string Description { get; set; }
}
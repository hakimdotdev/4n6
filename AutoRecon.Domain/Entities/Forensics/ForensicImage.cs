using AutoRecon.Domain.Common;

namespace AutoRecon.Domain.Entities
{
    public class ForensicImage : BaseAuditableEntity
    {
        public string Description { get; set; }
        public string FileName { get; set; }
        public required MetadataInfo Metadata { get; set; }
    }
    public class MetadataInfo
    {
        public string Description { get; set; }
    }
}
using AutoRecon.Domain.Common;

namespace AutoRecon.Domain.Entities
{
    public class ForensicImage : BaseAuditableEntity
    {
        public string Description { get; set; }
        public string FileName { get; set; }
    }
}
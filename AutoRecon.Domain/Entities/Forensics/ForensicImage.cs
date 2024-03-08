using AutoRecon.Domain.Common;

namespace AutoRecon.Domain.Entities
{
    public class ForensicImage : BaseAuditableEntity
    {
        public int Id { get; set; }
        public string FileName { get; set; }
    }
}

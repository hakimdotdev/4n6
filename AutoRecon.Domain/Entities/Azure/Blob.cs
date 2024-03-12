using AutoRecon.Domain.Common;

namespace AutoRecon.Domain.Entities.Azure
{
    public class Blob : BaseAuditableEntity
    {
        public string Name { get; set; }
        public virtual ICollection<AzureVm> AzureVms { get; set; }
    }
}
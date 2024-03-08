using AutoRecon.Domain.Common;

namespace AutoRecon.Domain.Entities.Azure
{
    public class AzureVm : BaseAuditableEntity
    {
        public string ResourceGroupName { get; set; }
        public virtual Blob Blob { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public Guid VmId { get; set; }
    }
}

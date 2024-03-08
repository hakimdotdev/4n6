namespace AutoRecon.Domain.Common;

public abstract class BaseAuditableEntity : BaseEntity
{
    public DateTime Created { get; set; } = DateTime.UtcNow;

    public Guid? CreatedBy { get; set; }

    public DateTime LastModified { get; set; } = DateTime.UtcNow;

    public Guid? LastModifiedBy { get; set; }
}

using AutoRecon.Domain.Entities;

namespace AutoRecon.Domain.Common;

public abstract class BaseAuditableEntity : BaseEntity
{
    public DateTime Created { get; set; } = DateTime.UtcNow;

    public User? CreatedBy { get; set; }

    public DateTime LastModified { get; set; } = DateTime.UtcNow;

    public User? LastModifiedBy { get; set; }
}
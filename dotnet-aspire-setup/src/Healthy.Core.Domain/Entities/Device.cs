namespace Healthy.Core.Domain.Entities;

public sealed class Device
{
    public Guid Id { get; set; }
    
    public DateTimeOffset CreatedAtUtc { get; set; }

    public DateTimeOffset UpdatedAtUtc { get; set; }
    
    public DateTimeOffset? UserAssignedAtUtc { get; set; }
    
    public Guid? UserId { get; set; }
}

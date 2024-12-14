namespace Healthy.Core.Domain.Entities;

public sealed class HealthTelemetry
{
    public Guid Id { get; set; }
    
    public DateTimeOffset TimestampAtUtc { get; set; }
    
    public Guid DeviceId { get; set; }
    
    public Guid? UserId { get; set; }
    
    public int? HeartRate { get; set; }
    
    public int? BloodOxygenLevel { get; set; }
    
    public int? BloodPressureSystolic { get; set; }

    public int? BloodPressureDiastolic { get; set; }
    
    public string? ActivityLevel { get; set; }
}

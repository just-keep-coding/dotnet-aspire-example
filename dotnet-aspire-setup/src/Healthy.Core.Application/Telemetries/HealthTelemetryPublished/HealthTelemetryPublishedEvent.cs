namespace Healthy.Core.Application.Telemetries.HealthTelemetryPublished;

public sealed record HealthTelemetryPublishedEvent(
    Guid DeviceId,
    DateTimeOffset TimestampUtc,
    int HeartRate,
    int? BloodOxygenLevel,
    int? BloodPressureSystolic,
    int? BloodPressureDiastolic,
    string? ActivityLevel
);

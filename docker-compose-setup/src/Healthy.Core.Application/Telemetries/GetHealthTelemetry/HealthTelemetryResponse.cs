namespace Core.Application.Telemetries.GetHealthTelemetry;

public sealed record HealthTelemetryResponse(
    Guid Id,
    Guid DeviceId,
    Guid? UserId,
    DateTimeOffset TimestampAtUtc,
    int? HeartRate,
    int? BloodOxygenLevel,
    int? BloodPressureSystolic,
    int? BloodPressureDiastolic,
    string? ActivityLevel
);

namespace Healthy.Presentation.DevicesApi.Telemetry.PublishHealthTelemetry;

public sealed record PublishHealthTelemetryRequest(
    DateTimeOffset TimestampUtc,
    int HeartRate,
    int? BloodOxygenLevel,
    int? BloodPressureSystolic,
    int? BloodPressureDiastolic,
    string? ActivityLevel
);

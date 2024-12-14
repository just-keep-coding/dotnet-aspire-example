using Healthy.Core.Domain.Abstractions;
using Healthy.Core.Domain.Entities;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Healthy.Core.Application.Telemetries.HealthTelemetryPublished;

public class HealthTelemetryPublishedEventConsumer(
    ILogger<HealthTelemetryPublishedEventConsumer> logger,
    IUnitOfWork unitOfWork,
    IDeviceRepository deviceRepository,
    IHealthTelemetryRepository healthTelemetryRepository)
    : IConsumer<HealthTelemetryPublishedEvent>
{
    public async Task Consume(ConsumeContext<HealthTelemetryPublishedEvent> context)
    {
        logger.LogInformation(
            "Health telemetry event received for {DeviceId}",
            context.Message.DeviceId);

        var device = await deviceRepository.GetByDeviceIdAsync(
            context.Message.DeviceId,
            context.CancellationToken);

        if (device is null)
        {
            logger.LogWarning(
                "Device with id {DeviceId} not found",
                context.Message.DeviceId);

            return;
        }
        
        var healthTelemetry = new HealthTelemetry
        {
            UserId = device.UserId,
            DeviceId = context.Message.DeviceId,
            TimestampAtUtc = context.Message.TimestampUtc,
            HeartRate = context.Message.HeartRate,
            BloodOxygenLevel = context.Message.BloodOxygenLevel,
            BloodPressureSystolic = context.Message.BloodPressureSystolic,
            BloodPressureDiastolic = context.Message.BloodPressureDiastolic,
            ActivityLevel = context.Message.ActivityLevel
        };
        
        healthTelemetryRepository.Save(healthTelemetry);
        
        await unitOfWork.SaveChangesAsync(context.CancellationToken);
        
        logger.LogInformation(
            "Health telemetry event saved for {DeviceId}",
            context.Message.DeviceId);
    }
}

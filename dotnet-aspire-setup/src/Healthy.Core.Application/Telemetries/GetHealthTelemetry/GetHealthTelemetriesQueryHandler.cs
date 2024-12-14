using Healthy.Core.Domain.Abstractions;
using Healthy.CrossCuttingConcerns;
using MediatR;

namespace Healthy.Core.Application.Telemetries.GetHealthTelemetry;

public class GetHealthTelemetriesQueryHandler(IHealthTelemetryRepository repository)
    : IRequestHandler<GetHealthTelemetriesQuery, Result<GetHealthTelemetriesResponse>>
{
    public async Task<Result<GetHealthTelemetriesResponse>> Handle(
        GetHealthTelemetriesQuery query,
        CancellationToken cancellationToken)
    {
        var entities = await repository.ListByDeviceIdAsync(
            query.DeviceId,
            cancellationToken);

        var responses = entities
            .Select(entity => new HealthTelemetryResponse(
                entity.Id,
                entity.DeviceId,
                entity.UserId,
                entity.TimestampAtUtc,
                entity.HeartRate,
                entity.BloodOxygenLevel,
                entity.BloodPressureSystolic,
                entity.BloodPressureDiastolic,
                entity.ActivityLevel))
            .ToList();
        
        return Result.Success(new GetHealthTelemetriesResponse(responses));
    }
}

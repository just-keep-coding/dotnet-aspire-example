using Healthy.Core.Domain.Entities;

namespace Healthy.Core.Domain.Abstractions;

public interface IHealthTelemetryRepository
{
    void Save(HealthTelemetry healthTelemetry);
    
    Task<List<HealthTelemetry>> ListByDeviceIdAsync(
        Guid deviceId,
        CancellationToken cancellationToken);
}

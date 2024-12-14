using Healthy.Core.Domain.Abstractions;
using Healthy.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Healthy.Infrastructure.Database.Repositories;

public class HealthTelemetryRepository(AppDbContext dbContext) : IHealthTelemetryRepository
{
    public void Save(HealthTelemetry healthTelemetry)
    {
        dbContext.Set<HealthTelemetry>()
            .Add(healthTelemetry);
    }

    public Task<List<HealthTelemetry>> ListByDeviceIdAsync(
        Guid deviceId,
        CancellationToken cancellationToken)
    {
        return dbContext.Set<HealthTelemetry>()
            .AsNoTracking()
            .Where(x => x.DeviceId == deviceId)
            .ToListAsync(cancellationToken);
    }
}

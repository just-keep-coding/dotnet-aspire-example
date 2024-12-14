using Healthy.Core.Domain.Abstractions;
using Healthy.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Healthy.Infrastructure.Database.Repositories;

public class DeviceRepository(AppDbContext dbContext) : IDeviceRepository
{
    public void Add(Device device)
    {
        dbContext.Set<Device>().Add(device);
    }

    public Task<List<Device>> ListByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        return dbContext.Set<Device>()
            .Where(p => p.UserId == userId)
            .ToListAsync(cancellationToken);
    }

    public Task<Device?> GetByDeviceIdAsync(Guid deviceId, CancellationToken cancellationToken)
    {
        return dbContext.Set<Device>()
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == deviceId, cancellationToken);
    }
}

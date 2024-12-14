using Healthy.Core.Domain.Entities;

namespace Healthy.Core.Domain.Abstractions;

public interface IDeviceRepository
{
    void Add(Device device);
    
    Task<List<Device>> ListByUserIdAsync(Guid userId, CancellationToken cancellationToken);
    
    Task<Device?> GetByDeviceIdAsync(Guid deviceId, CancellationToken cancellationToken);
}

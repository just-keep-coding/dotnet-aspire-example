using Healthy.Core.Domain.Abstractions;
using Healthy.Core.Domain.Entities;
using Healthy.CrossCuttingConcerns;
using MediatR;

namespace Healthy.Core.Application.Devices.CreateDevice;

public class CreateDeviceCommandHandler(
    IUnitOfWork unitOfWork,
    IDeviceRepository deviceRepository
)
    : IRequestHandler<CreateDeviceCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateDeviceCommand command, CancellationToken cancellationToken)
    {
        var utcNow = DateTimeOffset.UtcNow;

        var device = new Device
        {
            UserId = command.UserId,
            CreatedAtUtc = utcNow,
            UpdatedAtUtc = utcNow,
            UserAssignedAtUtc = utcNow
        };

        deviceRepository.Add(device);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success(device.Id);
    }
}

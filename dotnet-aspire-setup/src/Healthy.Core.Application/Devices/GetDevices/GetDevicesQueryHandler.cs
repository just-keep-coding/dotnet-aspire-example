using Healthy.Core.Domain.Abstractions;
using Healthy.CrossCuttingConcerns;
using MediatR;

namespace Healthy.Core.Application.Devices.GetDevices;

public class GetDevicesQueryHandler(IDeviceRepository repository)
    : IRequestHandler<GetDevicesQuery, Result<GetDevicesResponse>>
{
    public async Task<Result<GetDevicesResponse>> Handle(GetDevicesQuery query, CancellationToken cancellationToken)
    {
        var entities = await repository.ListByUserIdAsync(
            query.UserId,
            cancellationToken);

        var responses = entities
            .Select(entity => new DeviceResponse(
                entity.Id,
                entity.UserId,
                entity.CreatedAtUtc,
                entity.UpdatedAtUtc,
                entity.UserAssignedAtUtc))
            .ToList();
        
        return Result.Success(new GetDevicesResponse(responses));
    }
}

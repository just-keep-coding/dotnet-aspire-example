using CrossCuttingConcerns;
using MediatR;

namespace Core.Application.Devices.GetDevices;

public sealed record GetDevicesQuery(
    Guid UserId
) : IRequest<Result<GetDevicesResponse>>;

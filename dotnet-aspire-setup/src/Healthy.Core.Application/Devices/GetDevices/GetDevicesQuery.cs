using Healthy.CrossCuttingConcerns;
using MediatR;

namespace Healthy.Core.Application.Devices.GetDevices;

public sealed record GetDevicesQuery(
    Guid UserId
) : IRequest<Result<GetDevicesResponse>>;

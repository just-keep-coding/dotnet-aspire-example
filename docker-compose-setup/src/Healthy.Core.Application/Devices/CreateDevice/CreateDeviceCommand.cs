using CrossCuttingConcerns;
using MediatR;

namespace Core.Application.Devices.CreateDevice;

public sealed record CreateDeviceCommand(
    Guid UserId
) : IRequest<Result<Guid>>;

using Healthy.CrossCuttingConcerns;
using MediatR;

namespace Healthy.Core.Application.Devices.CreateDevice;

public sealed record CreateDeviceCommand(
    Guid UserId
) : IRequest<Result<Guid>>;

using CrossCuttingConcerns;
using MediatR;

namespace Core.Application.Telemetries.GetHealthTelemetry;

public sealed record GetHealthTelemetriesQuery(
    Guid DeviceId
) : IRequest<Result<GetHealthTelemetriesResponse>>;

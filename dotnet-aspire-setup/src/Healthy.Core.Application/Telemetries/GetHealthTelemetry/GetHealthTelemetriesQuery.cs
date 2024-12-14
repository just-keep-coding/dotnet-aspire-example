using Healthy.CrossCuttingConcerns;
using MediatR;

namespace Healthy.Core.Application.Telemetries.GetHealthTelemetry;

public sealed record GetHealthTelemetriesQuery(
    Guid DeviceId
) : IRequest<Result<GetHealthTelemetriesResponse>>;

using Carter;
using Healthy.Core.Application.Telemetries.GetHealthTelemetry;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Healthy.Presentation.UsersApi.Telemetry.GetHealthTelemetry;

public class GetHealthTelemetryEndpoint : CarterModule
{
    public GetHealthTelemetryEndpoint() : base("telemetry")
    {
        WithTags("Telemetry");
    }
    
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet(string.Empty, HandleAsync)
            .Produces<GetHealthTelemetriesResponse>()
            .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);
    }
    
    private static async Task<IResult> HandleAsync(
        [FromQuery] Guid deviceId,
        [FromServices] ISender sender,
        CancellationToken cancellationToken)
    {
        var query = new GetHealthTelemetriesQuery(deviceId);
        
        var result = await sender.Send(query, cancellationToken);

        if (result.IsSuccess)
        {
            return TypedResults.Ok(result.Value);
        }

        return TypedResults.Problem(new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Detail = result.Message
        });
    }
}

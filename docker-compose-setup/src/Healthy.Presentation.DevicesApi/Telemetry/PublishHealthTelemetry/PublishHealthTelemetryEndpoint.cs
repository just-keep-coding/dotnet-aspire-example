using Carter;
using Core.Application.Telemetries.HealthTelemetryPublished;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Healthy.DevicesApi.Telemetry.PublishHealthTelemetry;

public class PublishHealthTelemetryEndpoint : CarterModule
{
    public PublishHealthTelemetryEndpoint() : base("telemetries")
    {
        WithTags("Telemetries");
    }
    
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost(string.Empty, HandleAsync)
            .Produces(StatusCodes.Status200OK)
            .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);
    }

    private static async Task<IResult> HandleAsync(
        [FromHeader(Name = "device-id")] Guid deviceId,
        [FromBody] PublishHealthTelemetryRequest request,
        [FromServices] IPublishEndpoint endpoint,
        CancellationToken cancellationToken)
    {
        var healthTelemetryPublishedEvent = new HealthTelemetryPublishedEvent(
            deviceId,
            request.TimestampUtc,
            request.HeartRate,
            request.BloodOxygenLevel,
            request.BloodPressureSystolic,
            request.BloodPressureDiastolic,
            request.ActivityLevel);
        
        await endpoint.Publish(healthTelemetryPublishedEvent, cancellationToken);
        
        return TypedResults.Ok();
    }
}

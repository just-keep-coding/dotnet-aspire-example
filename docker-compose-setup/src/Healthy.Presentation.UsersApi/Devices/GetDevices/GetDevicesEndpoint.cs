using Carter;
using Core.Application.Devices.GetDevices;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Healthy.UsersApi.Devices.GetDevices;

public class GetDevicesEndpoint : CarterModule
{
    public GetDevicesEndpoint() : base("devices")
    {
        WithTags("Devices");
    }
    
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet(string.Empty, HandleAsync)
            .Produces<GetDevicesResponse>()
            .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);
    }
    
    private static async Task<IResult> HandleAsync(
        [FromQuery] Guid userId,
        [FromServices] ISender sender,
        CancellationToken cancellationToken)
    {
        var query = new GetDevicesQuery(userId);
        
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

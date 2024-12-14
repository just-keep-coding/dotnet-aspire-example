using Carter;
using Core.Application.Devices.CreateDevice;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Healthy.UsersApi.Devices.CreateDevice;

public class CreateDeviceEndpoint : CarterModule
{
    public CreateDeviceEndpoint() : base("devices")
    {
        WithTags("Devices");
    }
    
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost(string.Empty, HandleAsync)
            .Produces<CreateDeviceEndpoint>()
            .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);
    }
    
    private static async Task<IResult> HandleAsync(
        [FromBody] CreateDeviceRequest request,
        [FromServices] ISender sender,
        CancellationToken cancellationToken)
    {
        var command = new CreateDeviceCommand(request.UserId);
        
        var result = await sender.Send(command, cancellationToken);

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

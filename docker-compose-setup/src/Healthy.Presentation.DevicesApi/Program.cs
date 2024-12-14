using Carter;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter();

builder.Services.AddMassTransit(busConfigurator =>
{
    busConfigurator.SetKebabCaseEndpointNameFormatter();

    busConfigurator.UsingRabbitMq((context, configurator) =>
    {
        configurator.Host(builder.Configuration.GetConnectionString("RabbitMq"));

        configurator.ConfigureEndpoints(context);
    });
});

builder.Services.AddProblemDetails();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseExceptionHandler();
app.UseStatusCodePages();
app.MapOpenApi();
app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "v1"));
app.MapCarter();

app.Run();

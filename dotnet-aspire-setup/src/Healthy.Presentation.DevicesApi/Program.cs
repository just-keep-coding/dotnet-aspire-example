using Carter;
using Healthy.Presentation.ServiceDefaults;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddCarter();

builder.Services.AddMassTransit(busConfigurator =>
{
    busConfigurator.SetKebabCaseEndpointNameFormatter();

    busConfigurator.UsingRabbitMq((context, configurator) =>
    {
        configurator.Host(builder.Configuration.GetConnectionString("healthy-rabbit-mq"));

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
app.MapDefaultEndpoints();

app.Run();

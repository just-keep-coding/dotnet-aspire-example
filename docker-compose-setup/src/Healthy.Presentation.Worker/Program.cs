using Core.Application;
using Core.Application.Telemetries.HealthTelemetryPublished;
using Infrastructure.Database;
using MassTransit;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddDatabaseInfrastructure();
builder.Services.AddApplication();

builder.Services.AddMassTransit(busConfigurator =>
{
    busConfigurator.SetKebabCaseEndpointNameFormatter();

    busConfigurator.AddConsumer<HealthTelemetryPublishedEventConsumer>();
    
    busConfigurator.UsingRabbitMq((context, configurator) =>
    {
        configurator.Host(builder.Configuration.GetConnectionString("RabbitMq"));

        configurator.ConfigureEndpoints(context);
    });
});

var host = builder.Build();

using (var scope = host.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated();
}

host.Run();

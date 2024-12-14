using Healthy.Core.Application;
using Healthy.Core.Application.Telemetries.HealthTelemetryPublished;
using Healthy.Infrastructure.Database;
using Healthy.Presentation.ServiceDefaults;
using MassTransit;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddDatabaseInfrastructure();
builder.Services.AddApplication();

builder.Services.AddMassTransit(busConfigurator =>
{
    busConfigurator.SetKebabCaseEndpointNameFormatter();

    busConfigurator.AddConsumer<HealthTelemetryPublishedEventConsumer>();
    
    busConfigurator.UsingRabbitMq((context, configurator) =>
    {
        configurator.Host(builder.Configuration.GetConnectionString("healthy-rabbit-mq"));

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

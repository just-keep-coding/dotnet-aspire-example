using Healthy.Core.Domain.Abstractions;
using Infrastructure.Database.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Database;

public static class ServiceCollectionExtensions
{
    public static void AddDatabaseInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>();
        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<AppDbContext>());
        services.AddScoped<IDeviceRepository, DeviceRepository>();
        services.AddScoped<IHealthTelemetryRepository, HealthTelemetryRepository>();
    }
}

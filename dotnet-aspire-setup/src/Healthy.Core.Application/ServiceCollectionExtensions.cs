using Microsoft.Extensions.DependencyInjection;

namespace Healthy.Core.Application;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(ServiceCollectionExtensions).Assembly;
        
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(assembly);
        });
    }
}

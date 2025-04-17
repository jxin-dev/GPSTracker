using GPSTracker.Application.Mappings;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace GPSTracker.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
            
            TypeAdapterConfig.GlobalSettings.Scan(typeof(MapsterConfig).Assembly);
            services.AddMapster();

            return services;
        }
    }
}

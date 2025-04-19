using GPSTracker.Application.Common.Interfaces;
﻿using GPSTracker.Domain.Repositories;
using GPSTracker.Infrastructure.Persistence;
using GPSTracker.Infrastructure.Persistence.Repositories;
using GPSTracker.Infrastructure.Security.Jwt;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GPSTracker.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GpsTrackerDbContext>(options =>
                options.UseInMemoryDatabase("TestDb"));

            services.AddScoped<IUserRepository, UserRepository>();
            // Security Services
            services.AddSingleton<IJwtTokenService, JwtTokenService>();
            return services;
        }
    }
}

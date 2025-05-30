﻿using GPSTracker.Application.Common.Interfaces;
using GPSTracker.Domain.Entities;
using GPSTracker.Domain.Repositories;
using GPSTracker.Infrastructure.Persistence;
using GPSTracker.Infrastructure.Persistence.Repositories;
using GPSTracker.Infrastructure.Security.Jwt;
using GPSTracker.Infrastructure.Security.Password;
using Microsoft.AspNetCore.Identity;
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
            services.AddScoped<IDeviceRepository, DeviceRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();



            // Security Services
            services.AddSingleton<IJwtTokenService, JwtTokenService>();
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddScoped<IPasswordService, PasswordService>();
            
            return services;
        }
    }
}

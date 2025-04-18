﻿using GPSTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GPSTracker.Infrastructure.Persistence
{
    public class GpsTrackerDbContext : DbContext
    {
        public GpsTrackerDbContext(DbContextOptions<GpsTrackerDbContext> options) 
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Location> Locations { get; set; }

    }
}

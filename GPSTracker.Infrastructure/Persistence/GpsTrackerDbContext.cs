using Microsoft.EntityFrameworkCore;

namespace GPSTracker.Infrastructure.Persistence
{
    public class GpsTrackerDbContext : DbContext
    {
        public GpsTrackerDbContext(DbContextOptions<GpsTrackerDbContext> options) 
            : base(options) { }
        
    }
}

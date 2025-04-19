using GPSTracker.Contracts.Pagination;
using GPSTracker.Domain.Entities;
using GPSTracker.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GPSTracker.Infrastructure.Persistence.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly GpsTrackerDbContext _dbContext;

        public LocationRepository(GpsTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Location> CreateAsync(Location location)
        {
            await _dbContext.Locations.AddAsync(location);
            await _dbContext.SaveChangesAsync();
            return location;
        }

        public async Task<PagedResult<Location>> GetPagedAsync(PaginationParams pagination, CancellationToken cancellationToken)
        {
            var query = _dbContext.Locations.AsNoTracking();
            var totalCount = await query.CountAsync(cancellationToken);

            var devices = await query.OrderByDescending(u => u.Timestamp)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync(cancellationToken);

            return new PagedResult<Location>
            {
                Items = devices,
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }
    }
}

using GPSTracker.Contracts.Pagination;
using GPSTracker.Domain.Entities;
using GPSTracker.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GPSTracker.Infrastructure.Persistence.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly GpsTrackerDbContext _dbContext;
        public DeviceRepository(GpsTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Device> CreateAsync(Device device)
        {
            await _dbContext.Devices.AddAsync(device);
            await _dbContext.SaveChangesAsync();
            return device;
        }

        public async Task<PagedResult<Device>> GetPagedAsync(PaginationParams pagination, CancellationToken cancellationToken)
        {
            var query = _dbContext.Devices.AsNoTracking();
            var totalCount = await query.CountAsync(cancellationToken);

            var devices = await query.OrderBy(u => u.RegisteredAt)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync(cancellationToken);

            return new PagedResult<Device>
            {
                Items = devices,
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }
    }
}

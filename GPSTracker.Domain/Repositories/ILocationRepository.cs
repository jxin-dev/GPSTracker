using GPSTracker.Contracts.Pagination;
using GPSTracker.Domain.Entities;

namespace GPSTracker.Domain.Repositories
{
    public interface ILocationRepository
    {
        Task<Location> CreateAsync(Location location);
        Task<PagedResult<Location>> GetPagedAsync(PaginationParams pagination, CancellationToken cancellationToken);
    }
}

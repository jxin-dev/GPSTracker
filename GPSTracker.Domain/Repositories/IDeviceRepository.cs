using GPSTracker.Contracts.Pagination;
using GPSTracker.Domain.Entities;

namespace GPSTracker.Domain.Repositories
{
    public interface IDeviceRepository
    {
        Task<Device> CreateAsync(Device device);
        //Task<Device> BindDeviceAsync(Device device);

        Task<PagedResult<Device>> GetPagedAsync(PaginationParams pagination, CancellationToken cancellationToken);
    }
}

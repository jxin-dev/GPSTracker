﻿using GPSTracker.Contracts.Pagination;
using GPSTracker.Domain.Entities;

namespace GPSTracker.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User user);
        Task<PagedResult<User>> GetPagedAsync(PaginationParams pagination, CancellationToken cancellationToken);
    }
}

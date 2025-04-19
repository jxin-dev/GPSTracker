using GPSTracker.Contracts.Pagination;
using GPSTracker.Contracts.Responses;
using GPSTracker.Domain.Entities;
using GPSTracker.Domain.Repositories;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace GPSTracker.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly GpsTrackerDbContext _dbContext;
        public UserRepository(GpsTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> CreateAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetByIdAsync(Guid userId)
        {
            var user = await _dbContext.Users
                .Where(user => user.Id == userId).FirstOrDefaultAsync();
            return user;
        }

        public async Task<User?> GetByUsernameOrEmailAsync(string username)
        {
            var user = await _dbContext.Users
                .Where(user => user.Username == username || user.Email == username)
                .FirstOrDefaultAsync();
            return user;
        }

        public async Task<PagedResult<User>> GetPagedAsync(PaginationParams pagination, CancellationToken cancellationToken)
        {
            var query = _dbContext.Users.AsNoTracking();
            var totalCount = await query.CountAsync(cancellationToken);

            var users = await query.OrderBy(u => u.CreatedAt)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync(cancellationToken);

            return new PagedResult<User>
            {
                Items = users,
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }
    }
}

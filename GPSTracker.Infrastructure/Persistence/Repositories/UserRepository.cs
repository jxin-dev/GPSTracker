using GPSTracker.Domain.Entities;
using GPSTracker.Domain.Repositories;

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
    }
}

using GPSTracker.Domain.Entities;

namespace GPSTracker.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User user);
    }
}

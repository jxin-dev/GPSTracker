using GPSTracker.Domain.Entities;

namespace GPSTracker.Application.Common.Interfaces
{
    public interface IPasswordService
    {
        string HashPassword(User user, string password);
        bool VerifyPassword(User user, string hashedPassword, string providedPassword);

    }
}

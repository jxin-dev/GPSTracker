namespace GPSTracker.Application.Common.Interfaces
{
    public interface IJwtTokenService
    {
        string AccessToken(Guid userId, string username, string email);
    }
}

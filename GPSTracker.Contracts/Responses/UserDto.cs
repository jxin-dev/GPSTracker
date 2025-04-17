namespace GPSTracker.Contracts.Responses
{
    public record UserDto(Guid Id, string Username, string Email, DateTime CreatedAt);
}

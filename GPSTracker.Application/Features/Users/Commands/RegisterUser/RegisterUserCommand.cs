using GPSTracker.Contracts.Responses;
using MediatR;

namespace GPSTracker.Application.Features.Users.Commands.RegisterUser
{
    public record RegisterUserCommand(string Username, string Email, string Password) : IRequest<UserDto>;
}

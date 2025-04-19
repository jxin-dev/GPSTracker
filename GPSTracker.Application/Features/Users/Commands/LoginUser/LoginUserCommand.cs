using MediatR;

namespace GPSTracker.Application.Features.Users.Commands.LoginUser
{
    public record LoginUserCommand(string Username, string Password) : IRequest<string>;
}

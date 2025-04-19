using GPSTracker.Application.Features.Users.Commands.LoginUser;
using GPSTracker.Application.Features.Users.Commands.RegisterUser;
using GPSTracker.Contracts.Requests;
using GPSTracker.WebApi.Abstractions;
using Mapster;
using MediatR;

namespace GPSTracker.WebApi.Endpoints
{
    public class AuthEndpoint : IEndpoint
    {
        public void MapEndpoints(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/auth/");

            group.MapPost("/register", async (ISender sender, RegisterUserRequest request) =>
            {
                var command = request.Adapt<RegisterUserCommand>();
                var result = await sender.Send(command);
                return Results.Ok(result);
            });
            group.MapPost("/login", async (ISender sender, LoginUserRequest request) =>
            {
                var command = request.Adapt<LoginUserCommand>();
                var result = await sender.Send(command);
                return Results.Ok(result);
            });
        }
    }
}

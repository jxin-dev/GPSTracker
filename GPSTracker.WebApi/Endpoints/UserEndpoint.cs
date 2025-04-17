using GPSTracker.Application.Features.Users.Queries.GetUsers;
using GPSTracker.Contracts.Pagination;
using GPSTracker.Contracts.Requests;
using GPSTracker.WebApi.Abstractions;
using MediatR;

namespace GPSTracker.WebApi.Endpoints
{
    public class UserEndpoint : IEndpoint
    {
        public void MapEndpoints(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/users");

            group.MapGet("/", async (ISender sender, int pageNumber = 1, int pageSize = 10) =>
            {
                var query = new GetUserQuery(
                    new PaginationParams { PageNumber = pageNumber, PageSize = pageSize});
                var result = await sender.Send(query);
                return Results.Ok(result);
            });
        }
    }
}

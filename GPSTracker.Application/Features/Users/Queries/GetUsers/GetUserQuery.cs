using GPSTracker.Contracts.Pagination;
using GPSTracker.Contracts.Responses;
using MediatR;

namespace GPSTracker.Application.Features.Users.Queries.GetUsers
{
    public record GetUserQuery(PaginationParams Pagination) : IRequest<PagedResult<UserDto>>;
}

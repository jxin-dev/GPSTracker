using GPSTracker.Contracts.Pagination;
using GPSTracker.Contracts.Responses;
using GPSTracker.Domain.Entities;
using GPSTracker.Domain.Repositories;
using Mapster;
using MapsterMapper;
using MediatR;

namespace GPSTracker.Application.Features.Users.Queries.GetUsers
{
    public class GetUserHandler : IRequestHandler<GetUserQuery, PagedResult<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<UserDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            PagedResult<User> result = await _userRepository.GetPagedAsync(request.Pagination, cancellationToken);
            return _mapper.Map<PagedResult<UserDto>>(result);
        }
    }
}

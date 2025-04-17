using GPSTracker.Contracts.Responses;
using GPSTracker.Domain.Entities;
using GPSTracker.Domain.Repositories;
using MapsterMapper;
using MediatR;

namespace GPSTracker.Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public RegisterUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var newUser = User.Create(request.Username, request.Email, request.Password);
            await _userRepository.CreateAsync(newUser);
            return _mapper.Map<UserDto>(newUser);
        }
    }
}

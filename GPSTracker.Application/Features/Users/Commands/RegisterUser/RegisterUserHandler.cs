using GPSTracker.Application.Common.Interfaces;
using GPSTracker.Contracts.Responses;
using GPSTracker.Domain.Entities;
using GPSTracker.Domain.Repositories;
using MapsterMapper;
using MediatR;

namespace GPSTracker.Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;
        private readonly IMapper _mapper;

        public RegisterUserHandler(IUserRepository userRepository, IPasswordService passwordService, IMapper mapper)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var newUser = User.Create(request.Username, request.Email);
            newUser.SetPassword(_passwordService.HashPassword(newUser, request.Password));
            await _userRepository.CreateAsync(newUser);
            return _mapper.Map<UserDto>(newUser);
        }
    }
}

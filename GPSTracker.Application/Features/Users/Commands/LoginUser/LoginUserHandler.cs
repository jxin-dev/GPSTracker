using GPSTracker.Application.Common.Interfaces;
using GPSTracker.Domain.Repositories;
using MediatR;

namespace GPSTracker.Application.Features.Users.Commands.LoginUser
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IPasswordService _passwordService;

        public LoginUserHandler(IUserRepository userRepository, IJwtTokenService jwtTokenService, IPasswordService passwordService)
        {
            _userRepository = userRepository;
            _jwtTokenService = jwtTokenService;
            _passwordService = passwordService;
        }

        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUsernameOrEmailAsync(request.Username);
            if (user is null)
            {
                throw new Exception("User not found.");
            }
            
            bool isValidPassword = _passwordService.VerifyPassword(user, user.PasswordHash, request.Password);
            if (!isValidPassword)
            {
                throw new Exception("Invalid Password.");
            }
            return _jwtTokenService.AccessToken(user.Id, user.Username, user.Email);
        }
    }
}

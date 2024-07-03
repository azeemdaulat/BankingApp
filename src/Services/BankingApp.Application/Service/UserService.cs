using BankingApp.Application.Contracts.Infrastructure;
using BankingApp.Application.Contracts.Persistence;
using BankingApp.Application.Dtos;
using BankingApp.Application.Response;
using BankingApp.Domain.Entities;
using MediatR;

namespace BankingApp.Application.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _tokenGenerator;
        private readonly IMediator _mediator;

        public UserService(IUserRepository userRepository, IJwtTokenGenerator tokenGenerator, IMediator mediator)
        {
            _userRepository = userRepository;
            _tokenGenerator = tokenGenerator;
            _mediator = mediator;
        }

        public async Task<AuthenticateResponse> AuthenticateAsync(string username, string password)
        {
            var user = await _userRepository.GetByUsernameAsync(username);
            if (user == null || !VerifyPassword(user.PasswordHash, password))
            {
                throw new UnauthorizedAccessException("Invalid credentials");
            }

            var token = _tokenGenerator.GenerateToken(user);
            var refreshToken = _tokenGenerator.GenerateRefreshToken();
            user.RefreshTokens.Add(refreshToken);
            await _userRepository.UpdateAsync(user);

            return new AuthenticateResponse(user.Username, token, refreshToken.Token);
        }

        public async Task<AuthenticateResponse> RefreshTokenAsync(string token)
        {
            var user = await _userRepository.GetByRefreshTokenAsync(token);
            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid token");
            }

            var refreshToken = user.RefreshTokens.Single(x => x.Token == token);
            if (!refreshToken.IsActive)
            {
                throw new UnauthorizedAccessException("Invalid token");
            }

            var newRefreshToken = _tokenGenerator.GenerateRefreshToken();
            refreshToken.Revoked = DateTime.UtcNow;
            user.RefreshTokens.Add(newRefreshToken);
            await _userRepository.UpdateAsync(user);

            var newJwtToken = _tokenGenerator.GenerateToken(user);

            return new AuthenticateResponse(user.Username, newJwtToken, newRefreshToken.Token);
        }

        public async Task<bool> RevokeTokenAsync(string token)
        {
            var user = await _userRepository.GetByRefreshTokenAsync(token);
            if (user == null) return false;

            var refreshToken = user.RefreshTokens.Single(x => x.Token == token);
            if (!refreshToken.IsActive) return false;

            refreshToken.Revoked = DateTime.UtcNow;
            await _userRepository.UpdateAsync(user);

            return true;
        }

        public async Task<UserDto> GetUserDetailsAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.ContactDetails.Email,
                PhoneNumber = user.ContactDetails.PhoneNumber,
                Address = user.ContactDetails.Address
            };
        }

        public async Task<UserDto> RegisterAsync(UserDto userDto)
        {
            var user = new User
            {
                Username = userDto.Username,
                PasswordHash = HashPassword(userDto.PasswordHash), // Assuming Password property exists in UserDto
                ContactDetails = new ContactDetails
                {
                    Email = userDto.Email,
                    PhoneNumber = userDto.PhoneNumber,
                    Address = userDto.Address
                }
            };

            await _userRepository.AddAsync(user);

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.ContactDetails.Email,
                PhoneNumber = user.ContactDetails.PhoneNumber,
                Address = user.ContactDetails.Address
            };
        }

        private string HashPassword(string password)
        {
            // Implement a secure password hashing mechanism here
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private bool VerifyPassword(string hash, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}

using BankingApp.Application.Dtos;
using BankingApp.Application.Response;

namespace BankingApp.Application.Service
{
    public interface IUserService 
    {
        Task<AuthenticateResponse> AuthenticateAsync(string username, string password);
        Task<UserDto> RegisterAsync(UserDto userDto);
        Task<UserDto> GetUserDetailsAsync(int userId);
        Task<AuthenticateResponse> RefreshTokenAsync(string token);
        Task<bool> RevokeTokenAsync(string token);
    }
}

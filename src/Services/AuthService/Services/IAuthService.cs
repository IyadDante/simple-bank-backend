using BankingApp.Shared.DTOs.Auth;

namespace AuthService.Services
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterUserDto registerUserDto);
    }
}

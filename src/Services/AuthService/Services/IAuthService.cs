using BankingApp.Shared.DTOs;

namespace AuthService.Services
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterUserDto registerUserDto);
        Task<string?> LoginAsync(LoginUserDto loginUserDto); // <-- Add this line
    }
}

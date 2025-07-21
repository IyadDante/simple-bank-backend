using BankingApp.Shared.DTOs;

namespace AuthService.Interfaces
{
    public interface IAuthService
    {
        Task<UserDto?> RegisterAsync(string username, string email, string password);
        Task<UserDto?> LoginAsync(string email, string password);
    }
}

using AuthService.Interfaces;
using AuthService.Models;
using BankingApp.Shared.DTOs;

namespace AuthService.Services
{
    public class AuthService : IAuthService
    {
        private readonly List<User> _users = new(); // Simulating in-memory DB

        public async Task<UserDto?> RegisterAsync(string username, string email, string password)
        {
            if (_users.Any(u => u.Email == email)) return null;

            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = username,
                Email = email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password)
            };

            _users.Add(user);

            return await Task.FromResult(new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role
            });
        }

        public async Task<UserDto?> LoginAsync(string email, string password)
        {
            var user = _users.FirstOrDefault(u => u.Email == email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash)) return null;

            return await Task.FromResult(new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role
            });
        }
    }
}

using AuthService.Data;
using AuthService.Models;
using AuthService.Services;
using BankingApp.Shared.DTOs.Auth;
using Microsoft.AspNetCore.Identity;

namespace AuthService.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthService(ApplicationDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<string> RegisterAsync(RegisterUserDto registerUserDto)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Email == registerUserDto.Email);
            if (existingUser != null)
            {
                return "User already exists.";
            }

            var user = new User
            {
                Email = registerUserDto.Email,
                Username = registerUserDto.Username,
                PasswordHash = ""
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, registerUserDto.Password);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return "User registered successfully.";
        }
    }
}

using AuthService.Entities;
using BankingApp.Shared.DTOs;
using Microsoft.AspNetCore.Identity;

namespace AuthService.Services
{
    public class AuthService : IAuthService
    {
        private static readonly List<User> _users = new();

        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly JwtTokenGenerator _jwtTokenGenerator;

        public AuthService(IPasswordHasher<User> passwordHasher, JwtTokenGenerator jwtTokenGenerator)
        {
            _passwordHasher = passwordHasher;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<string> RegisterAsync(RegisterUserDto dto)
        {
            var existingUser = _users.FirstOrDefault(u => u.Email == dto.Email);
            if (existingUser != null)
                return "User already exists.";

            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Role = "User"
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password);

            _users.Add(user);

            return await Task.FromResult("User registered successfully.");
        }

        public async Task<string?> LoginAsync(LoginUserDto dto)
        {
            var user = _users.FirstOrDefault(u => u.Email == dto.Email);
            if (user == null)
                return null;

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if (result == PasswordVerificationResult.Failed)
                return null;

            var token = _jwtTokenGenerator.GenerateToken(user);
            return await Task.FromResult(token);
        }
    }
}

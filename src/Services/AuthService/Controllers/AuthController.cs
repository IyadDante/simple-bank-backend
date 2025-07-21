using Microsoft.AspNetCore.Mvc;
using AuthService.Interfaces;
using BankingApp.Shared.DTOs;

namespace AuthService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(string username, string email, string password)
        {
            var result = await _authService.RegisterAsync(username, email, password);
            if (result == null) return BadRequest("Email already in use.");

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(string email, string password)
        {
            var result = await _authService.LoginAsync(email, password);
            if (result == null) return Unauthorized("Invalid credentials.");

            return Ok(result);
        }
    }
}

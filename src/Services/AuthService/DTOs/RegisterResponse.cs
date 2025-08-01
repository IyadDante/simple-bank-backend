namespace AuthService.DTOs;

public class RegisterResponse
{
    public string UserId { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Token { get; set; } = default!;
}

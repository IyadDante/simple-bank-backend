namespace AuthService.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public string Role { get; set; } = "User"; // Can be "User", "Admin", etc.

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

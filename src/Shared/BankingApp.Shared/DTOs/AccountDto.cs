namespace BankingApp.Shared.DTOs
{
    public class AccountDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string AccountNumber { get; set; } = default!;
        public decimal Balance { get; set; }
        public string Currency { get; set; } = "CAD";
    }
}

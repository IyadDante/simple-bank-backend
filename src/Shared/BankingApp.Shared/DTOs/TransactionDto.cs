namespace BankingApp.Shared.DTOs
{
    public class TransactionDto
    {
        public Guid Id { get; set; }
        public Guid FromAccountId { get; set; }
        public Guid ToAccountId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Timestamp { get; set; }
        public string Type { get; set; } = default!; // e.g., "Transfer", "Deposit", etc.
    }
}

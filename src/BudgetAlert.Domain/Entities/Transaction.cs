namespace BudgetAlert.Domain.Entities
{
    public class Transaction
    {
        public Guid Id { get; private set; }
        public Guid BudgetId { get; private set; }
        public decimal Amount { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public DateTime OccurredAt { get; private set; }

        public static Transaction Create(Guid budgetId, decimal amount, string description, DateTime occurredAt)
        {
            return new Transaction
            {
                Id = Guid.NewGuid(),
                BudgetId = budgetId,
                Amount = amount,
                Description = description,
                OccurredAt = occurredAt
            };
        }
    }
}
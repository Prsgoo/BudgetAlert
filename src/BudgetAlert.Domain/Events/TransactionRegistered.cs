namespace BudgetAlert.Domain.Events
{
    public record TransactionRegistered(
        Guid EventId,
        DateTime OccurredAt,
        Guid BudgetId,
        Guid TransactionId,
        decimal Amount,
        decimal CurrentSpend,
        decimal BudgetLimit
    ) : IDomainEvent;
}
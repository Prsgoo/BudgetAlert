namespace BudgetAlert.Domain.Events
{
    public record AlertTriggered(
        Guid EventId,
        DateTime OccurredAt,
        Guid BudgetId,
        Guid AlertRuleId,
        decimal ThresholdPercentage,
        decimal SpendAtTrigger,
        decimal BudgetLimit
    ) : IDomainEvent;
}
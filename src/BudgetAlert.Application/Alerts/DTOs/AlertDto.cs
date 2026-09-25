namespace BudgetAlert.Application.Alerts.DTOs
{
    public record AlertDto(
        Guid Id,
        Guid BudgetId,
        Guid AlertRuleId,
        decimal ThresholdPercentage,
        decimal SpendAtTrigger,
        decimal BudgetLimit,
        DateTime TriggeredAt
    );
}
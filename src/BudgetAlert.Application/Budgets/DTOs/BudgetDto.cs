namespace BudgetAlert.Application.Budgets.DTOs
{
    public record BudgetDto(
        Guid Id,
        string Name,
        decimal Limit,
        string Currency,
        decimal CurrentSpend,
        decimal SpendPercentage,
        DateTime CreatedAt,
        IReadOnlyList<TransactionDto> RecentTransactions
    );
}
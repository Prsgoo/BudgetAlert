namespace BudgetAlert.Application.Budgets.DTOs
{
    public record TransactionDto(Guid Id, decimal Amount, string Description, DateTime OccurredAt);
}
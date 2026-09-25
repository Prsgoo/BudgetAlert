namespace BudgetAlert.Domain.Repositories
{
    // BudgetAlert.Domain/Repositories/IUnitOfWork.cs
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken ct = default);
    }
}
using BudgetAlert.Domain.Events;

namespace BudgetAlert.Application.Contracts
{
    public interface IEventBus
    {
        Task PublishAsync<T>(T @event, CancellationToken cancellationToken = default) where T : IDomainEvent;
    }
}
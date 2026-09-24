using BudgetAlert.Domain.Events;

namespace BudgetAlert.Domain
{
    public class AggregateRoot
    {
        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.ToList();

        #region Private Fields
        private IList<IDomainEvent> _domainEvents { get; } = [];
        #endregion

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public IReadOnlyList<IDomainEvent> PopDomainEvents()
        {
            var events = _domainEvents.ToList();
            _domainEvents.Clear();
            return events;
        }
    }
}
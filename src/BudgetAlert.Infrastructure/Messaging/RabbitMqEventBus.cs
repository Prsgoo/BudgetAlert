using BudgetAlert.Application.Contracts;
using BudgetAlert.Domain.Events;

namespace BudgetAlert.Infrastructure.Messaging
{
    public class RabbitMqEventBus : IEventBus, IDisposable
    {
        // On startup: declare a fanout or topic exchange
        // PublishAsync<T>:
        //   - routing key = typeof(T).Name.ToLowerInvariant() (e.g. "transactionregistered")
        //   - body = JsonSerializer.SerializeToUtf8Bytes(event)
        //   - IBasicProperties: ContentType = "application/json", DeliveryMode = 2 (persistent)
        //   - BasicPublish to the exchange
        public Task PublishAsync<T>(T @event, CancellationToken cancellationToken = default) where T : IDomainEvent
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
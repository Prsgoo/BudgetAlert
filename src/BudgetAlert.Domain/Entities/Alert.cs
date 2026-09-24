namespace BudgetAlert.Domain.Entities
{
    public class Alert
    {
        public Guid Id { get; private set; }
        public Guid BudgetId { get; private set; }
        public Guid AlertRuleId { get; private set; }
        public decimal SpendAtTrigger { get; private set; }
        public DateTime TriggeredAt { get; private set; }
    }
}
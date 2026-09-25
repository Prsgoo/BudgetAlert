namespace BudgetAlert.Domain.Entities
{
    public class Alert
    {
        public Guid Id { get; private set; }
        public Guid BudgetId { get; private set; }
        public Guid AlertRuleId { get; private set; }
        public decimal SpendAtTrigger { get; private set; }
        public DateTime TriggeredAt { get; private set; }
        public decimal ThresholdPercentage { get; private set; }  // e.g. 80.0 = 80%
        public decimal BudgetLimit { get; private set; }

        public static Alert Create(Guid budgetId, Guid alertRuleId, decimal spendAtTrigger, decimal thresholdPercentage, decimal budgetLimit)
        {
            return new Alert
            {
                Id = Guid.NewGuid(),
                BudgetId = budgetId,
                AlertRuleId = alertRuleId,
                SpendAtTrigger = spendAtTrigger,
                TriggeredAt = DateTime.UtcNow,
                ThresholdPercentage = thresholdPercentage,
                BudgetLimit = budgetLimit
            };
        }
    }
}
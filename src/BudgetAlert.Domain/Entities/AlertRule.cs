namespace BudgetAlert.Domain.Entities
{
    public class AlertRule
    {
        public Guid Id { get; private set; }
        public Guid BudgetId { get; private set; }
        public decimal ThresholdPercentage { get; private set; }  // e.g. 80.0 = 80%
        public bool IsActive { get; private set; }
    }
}
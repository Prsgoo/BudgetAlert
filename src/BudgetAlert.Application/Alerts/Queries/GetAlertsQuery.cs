using BudgetAlert.Application.Alerts.DTOs;
using BudgetAlert.Domain.Repositories;
using MediatR;

namespace BudgetAlert.Application.Alerts.Queries
{
    public record GetAlertsQuery(Guid? BudgetId = null) : IRequest<IReadOnlyList<AlertDto>>;

    public class GetAlertsQueryHandler(IAlertRepository alertRepository) : IRequestHandler<GetAlertsQuery, IReadOnlyList<AlertDto>>
    {
        public async Task<IReadOnlyList<AlertDto>> Handle(GetAlertsQuery request, CancellationToken cancellationToken)
        {
            var alerts = await alertRepository.GetAsync(request.BudgetId, cancellationToken);
            return alerts
                .OrderByDescending(a => a.TriggeredAt)
                .Select(a => new AlertDto(
                    a.Id,
                    a.BudgetId,
                    a.AlertRuleId,
                    a.ThresholdPercentage,
                    a.SpendAtTrigger,
                    a.BudgetLimit,
                    a.TriggeredAt
                ))
                .ToList();
        }
    }
}
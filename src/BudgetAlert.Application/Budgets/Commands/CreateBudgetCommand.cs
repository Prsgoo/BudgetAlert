using BudgetAlert.Domain.Entities;
using BudgetAlert.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace BudgetAlert.Application.Budgets.Commands
{
    public record CreateBudgetCommand(string Name, decimal Limit, string Currency) : IRequest<Guid>;

    public class CreateBudgetCommandValidator : AbstractValidator<CreateBudgetCommand>
    {
        public CreateBudgetCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Limit).GreaterThan(0);
            RuleFor(x => x.Currency).NotEmpty().Length(3);
        }
    }

    public class CreateBudgetCommandHandler(IBudgetRepository _budgetRepository, IUnitOfWork _unitOfWork) : IRequestHandler<CreateBudgetCommand, Guid>
    {
        public async Task<Guid> Handle(CreateBudgetCommand request, CancellationToken cancellationToken)
        {
            var budget = Budget.Create(request.Name, request.Limit, request.Currency);
            _budgetRepository.Add(budget);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return budget.Id;
        }
    }
}
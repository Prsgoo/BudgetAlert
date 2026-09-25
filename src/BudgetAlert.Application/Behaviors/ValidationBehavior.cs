using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace BudgetAlert.Application.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {
        // If no validators registered → pass through
        // If validators exist → run all, collect failures, throw if any
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(!validators.Any()) return await next(cancellationToken);

            var failures = new List<ValidationFailure>();

            foreach(var validator in validators)
            {
                var validationResult = await validator.ValidateAsync(request, cancellationToken);
                failures.AddRange(validationResult.Errors);
            }
            if(failures.Count != 0) throw new ValidationException(failures);
            return await next(cancellationToken);
        }
    }
}
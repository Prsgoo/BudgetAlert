using BudgetAlert.Application.Behaviors;
using FluentValidation;
using MediatR;

namespace BudgetAlert.Application.Tests.Behaviors;

public class ValidationBehaviorTests
{
    private record TestRequest(string Name, int Value) : IRequest<string>;

    private class NameValidator : AbstractValidator<TestRequest>
    {
        public NameValidator() => RuleFor(x => x.Name).NotEmpty();
    }

    private class ValueValidator : AbstractValidator<TestRequest>
    {
        public ValueValidator() => RuleFor(x => x.Value).GreaterThan(0);
    }

    [Fact]
    public async Task Handle_WhenNoValidators_CallsNext()
    {
        var behavior = new ValidationBehavior<TestRequest, string>([]);
        var nextCalled = false;
        RequestHandlerDelegate<string> next = _ => { nextCalled = true; return Task.FromResult("ok"); };

        await behavior.Handle(new TestRequest("test", 1), next, CancellationToken.None);

        Assert.True(nextCalled);
    }

    [Fact]
    public async Task Handle_WhenValidationPasses_ReturnsNextResult()
    {
        var behavior = new ValidationBehavior<TestRequest, string>([new NameValidator()]);
        RequestHandlerDelegate<string> next = _ => Task.FromResult("result");

        var result = await behavior.Handle(new TestRequest("valid", 1), next, CancellationToken.None);

        Assert.Equal("result", result);
    }

    [Fact]
    public async Task Handle_WhenValidationFails_ThrowsValidationException()
    {
        var behavior = new ValidationBehavior<TestRequest, string>([new NameValidator()]);
        RequestHandlerDelegate<string> next = _ => Task.FromResult("result");

        await Assert.ThrowsAsync<ValidationException>(() =>
            behavior.Handle(new TestRequest("", 1), next, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_CollectsFailuresFromAllValidators()
    {
        // Two validators, each targeting a different field - both should fail
        var behavior = new ValidationBehavior<TestRequest, string>([new NameValidator(), new ValueValidator()]);
        RequestHandlerDelegate<string> next = _ => Task.FromResult("result");

        var ex = await Assert.ThrowsAsync<ValidationException>(() =>
            behavior.Handle(new TestRequest("", 0), next, CancellationToken.None));

        Assert.Equal(2, ex.Errors.Count());
    }
}

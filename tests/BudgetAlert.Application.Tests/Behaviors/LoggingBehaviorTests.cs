using BudgetAlert.Application.Behaviors;
using MediatR;
using Microsoft.Extensions.Logging.Abstractions;

namespace BudgetAlert.Application.Tests.Behaviors;

public class LoggingBehaviorTests
{
    private record TestRequest(string Value) : IRequest<string>;

    [Fact]
    public async Task Handle_WhenNextSucceeds_ReturnsResponse()
    {
        var behavior = new LoggingBehavior<TestRequest, string>(NullLogger<LoggingBehavior<TestRequest, string>>.Instance);
        RequestHandlerDelegate<string> next = _ => Task.FromResult("response");

        var result = await behavior.Handle(new TestRequest("test"), next, CancellationToken.None);

        Assert.Equal("response", result);
    }

    [Fact]
    public async Task Handle_WhenNextThrows_RethrowsException()
    {
        var behavior = new LoggingBehavior<TestRequest, string>(NullLogger<LoggingBehavior<TestRequest, string>>.Instance);
        RequestHandlerDelegate<string> next = _ => throw new InvalidOperationException("boom");

        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            behavior.Handle(new TestRequest("test"), next, CancellationToken.None));
    }
}

using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;
using ProductManager.Application._Common.Interfaces;

namespace ProductManager.Application._Common.Services;

public class CommandDispatcher : ICommandDispatcher
{
    private readonly IServiceProvider _provider;

    public CommandDispatcher(IServiceProvider provider)
    {
        _provider = provider;
    }

    public async Task<TResult> DispatchAsync<TCommand, TResult>(TCommand command) where TCommand : ICommand<TResult>
    {

        var validators = _provider.GetServices<IValidator<TCommand>>();
        var validationFailures = new List<ValidationFailure>();

        foreach (var validator in validators)
        {
            var result = await validator.ValidateAsync(command);
            if (!result.IsValid)
                validationFailures.AddRange(result.Errors);
        }

        if (validationFailures.Count > 0)
            throw new ValidationException(validationFailures);
        

        var handler = _provider.GetRequiredService<ICommandHandler<TCommand, TResult>>();
        return await handler.HandleAsync(command);
    }
}
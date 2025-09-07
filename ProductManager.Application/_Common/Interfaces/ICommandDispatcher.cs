namespace ProductManager.Application._Common.Interfaces;

public interface ICommandDispatcher
{
    Task<TResult> DispatchAsync<TCommand, TResult>(TCommand command)
            where TCommand : ICommand<TResult>;
}
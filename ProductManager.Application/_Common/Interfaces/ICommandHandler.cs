namespace ProductManager.Application._Common.Interfaces;

public interface ICommandHandler<TCommand, TResult> where TCommand : ICommand<TResult>
{
    Task<TResult> HandleAsync(
        TCommand command, 
        CancellationToken cancellationToken = default);
}
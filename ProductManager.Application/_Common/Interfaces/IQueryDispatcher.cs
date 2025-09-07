namespace ProductManager.Application._Common.Interfaces;

public interface IQueryDispatcher
{
    Task<TQueryResult> DispatchAsync<TQuery, TQueryResult>(
        TQuery query,
        CancellationToken cancellation = default) where TQuery : IQuery<TQueryResult>;
}
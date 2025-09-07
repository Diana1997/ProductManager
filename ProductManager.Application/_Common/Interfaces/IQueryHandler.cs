namespace ProductManager.Application._Common.Interfaces;

public interface IQueryHandler<in TQuery, TQueryResult>
{
    Task<TQueryResult> HandleAsync(TQuery query, CancellationToken cancellation = default);
}
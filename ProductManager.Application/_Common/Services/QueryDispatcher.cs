using Microsoft.Extensions.DependencyInjection;
using ProductManager.Application._Common.Interfaces;

namespace ProductManager.Application._Common.Services;

public class QueryDispatcher(IServiceProvider serviceProvider) : IQueryDispatcher
{
    public Task<TQueryResult> DispatchAsync<TQuery, TQueryResult>(
        TQuery query, 
        CancellationToken cancellation = default) where TQuery : IQuery<TQueryResult>
    {
        var handler = serviceProvider.GetRequiredService<IQueryHandler<TQuery, TQueryResult>>();
        return handler.HandleAsync(query, cancellation);
    }
}
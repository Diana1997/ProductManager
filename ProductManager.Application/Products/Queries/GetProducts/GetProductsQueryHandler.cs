using Microsoft.EntityFrameworkCore;
using ProductManager.Application._Common.Interfaces;
using ProductManager.Application._Common.Responses;
using ProductManager.Infrastructure.Persistence;

namespace ProductManager.Application.Products.Queries.GetProducts;

public class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, List<ProductResponse>>
{
    private readonly AppDbContext _context;

    public GetProductsQueryHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProductResponse>> HandleAsync(GetProductsQuery query, CancellationToken cancellation = default)
    {
        var products = await _context.Products
            .AsNoTracking()
            .Select(x => new ProductResponse
            {
                Id = x.Id,
                Name = x.Name,
                CreationTime = x.CreationTime
            })
            .ToListAsync(cancellation);

        return products;
    }
}
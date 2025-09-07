using ProductManager.Application._Common.Interfaces;
using ProductManager.Domain.Entities;
using ProductManager.Infrastructure.Persistence;

namespace ProductManager.Application.Products.Commands.Create;

public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, int>
{
    private readonly AppDbContext _context;

    public CreateProductCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> HandleAsync(CreateProductCommand command, CancellationToken cancellationToken = default)
    {
        var product = new Product
        {
            Name = command.Name,
            CreationTime = DateTime.UtcNow
        };
        await _context.Products.AddAsync(product, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return product.Id;
    }
}
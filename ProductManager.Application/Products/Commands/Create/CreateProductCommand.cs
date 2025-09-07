using ProductManager.Application._Common.Interfaces;

namespace ProductManager.Application.Products.Commands.Create;

public class CreateProductCommand : ICommand<int>
{
    public string Name { get; set; }
}
using Microsoft.AspNetCore.Mvc;
using ProductManager.Application._Common.Interfaces;
using ProductManager.Application._Common.Responses;
using ProductManager.Application.Products.Commands.Create;
using ProductManager.Application.Products.Queries.GetProducts;

namespace ProductManager.WebApi.Controllers;

public class ProductsController  : ApiBaseController
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public ProductsController(
        ICommandDispatcher commandDispatcher, 
        IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateProductCommand command)
    {
        var response = await _commandDispatcher
            .DispatchAsync<CreateProductCommand, int>(command);
        return Ok(response);
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var response = await _queryDispatcher
            .DispatchAsync<GetProductsQuery, List<ProductResponse>>(new GetProductsQuery());
        return Ok(response);
    }
}
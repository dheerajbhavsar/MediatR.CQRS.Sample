using MediatR.CQRS.Sample.Commands;
using MediatR.CQRS.Sample.Models;
using MediatR.CQRS.Sample.Notifications;
using MediatR.CQRS.Sample.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace MediatR.CQRS.Sample.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IPublisher _publisher;

    public ProductsController(ISender sender, IPublisher publisher)
    {
        _sender = sender;
        _publisher = publisher;
    }

    [HttpGet(Name = "GetAllProducts")]
    public async Task<ActionResult<IEnumerable<Product>>> GetAsync()
    {
        var products = await _sender.Send(new GetProductsQuery());
        return Ok(products);
    }

    [HttpGet("{id:int}", Name = "GetProductById")]
    public async Task<ActionResult<Product>> GetAsync(int id)
    {
        var product = await _sender.Send(new GetProductQuery(id));

        return product is null ? 
            NotFound() : Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult> PostAsync(Product product)
    {
        var productEntity = await _sender.Send(new GetProductQuery(product.Id));

        if (productEntity is not null)
        {
            return BadRequest($"Product with Id: {product.Id} already exists.");
        }

        var productToReturn = await _sender.Send(new AddProductCommand(product));

        await _publisher.Publish(new ProductAddedNotification(productToReturn));

        return CreatedAtRoute("GetProductById",
            new { id = productToReturn.Id },
            productToReturn);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        var product = await _sender.Send(new GetProductQuery(id));

        if (product is null)
        {
            return NotFound();
        }

        _ = await _sender.Send(new DeleteProductCommand(id));

        return NoContent();
    }
}

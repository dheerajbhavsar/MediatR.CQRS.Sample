using Microsoft.AspNetCore.Mvc;

namespace MediatR.CQRS.Sample.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ISender _sender;

    public ProductsController(ISender sender) => _sender = sender;
}

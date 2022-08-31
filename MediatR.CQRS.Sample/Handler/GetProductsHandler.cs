using MediatR.CQRS.Sample.Data;
using MediatR.CQRS.Sample.Models;
using MediatR.CQRS.Sample.Queries;

namespace MediatR.CQRS.Sample.Handler;

public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
{
    private readonly IProductsRepository _productsRepository;

    public GetProductsHandler(IProductsRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }

    public async Task<IEnumerable<Product>> Handle(GetProductsQuery request,
        CancellationToken cancellationToken)
    {
        return await _productsRepository.GetAllProductsAsync();
    }
}

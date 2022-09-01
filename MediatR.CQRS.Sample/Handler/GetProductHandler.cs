using MediatR.CQRS.Sample.Data;
using MediatR.CQRS.Sample.Models;
using MediatR.CQRS.Sample.Queries;

namespace MediatR.CQRS.Sample.Handler;

public class GetProductHandler : IRequestHandler<GetProductQuery, Product?>
{
    private readonly IProductsRepository _productsRepository;

    public GetProductHandler(IProductsRepository productsRepository) =>
        _productsRepository = productsRepository;


    public async Task<Product?> Handle(GetProductQuery request,
        CancellationToken cancellationToken)
    {
        return await _productsRepository
            .GetProductByIdAsync(request.Id);
    }
}

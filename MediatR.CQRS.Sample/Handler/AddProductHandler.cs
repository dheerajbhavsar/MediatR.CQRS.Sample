using MediatR.CQRS.Sample.Commands;
using MediatR.CQRS.Sample.Data;
using MediatR.CQRS.Sample.Models;

namespace MediatR.CQRS.Sample.Handler;

public class AddProductHandler : IRequestHandler<AddProductCommand, Product>
{
    private readonly IProductsRepository _repository;

    public AddProductHandler(IProductsRepository repository) => 
        _repository = repository;

    public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        await _repository.AddProductAsync(request.Product);
        return request.Product;
    }
}

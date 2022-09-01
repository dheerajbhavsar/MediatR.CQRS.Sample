using MediatR.CQRS.Sample.Commands;
using MediatR.CQRS.Sample.Data;

namespace MediatR.CQRS.Sample.Handler;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IProductsRepository _repository;

    public DeleteProductHandler(IProductsRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteProductCommand request,
        CancellationToken cancellationToken)
    {
        return await _repository.DeleteProductAsync(request.Id);
    }
}

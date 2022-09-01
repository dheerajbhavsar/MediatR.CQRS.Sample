using MediatR.CQRS.Sample.Data;
using MediatR.CQRS.Sample.Models;
using MediatR.CQRS.Sample.Notifications;

namespace MediatR.CQRS.Sample.Handler;

public class CacheInvalidationHandler : INotificationHandler<ProductAddedNotification>
{
    private readonly IProductsRepository _repository;

    public CacheInvalidationHandler(IProductsRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
    {
        await _repository.EventOccurred(notification.Product, "Cache Invalidated");
    }
}

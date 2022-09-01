using MediatR.CQRS.Sample.Models;

namespace MediatR.CQRS.Sample.Notifications;

public record ProductAddedNotification(Product Product) : INotification;

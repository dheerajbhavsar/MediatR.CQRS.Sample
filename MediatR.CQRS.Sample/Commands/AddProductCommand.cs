using MediatR.CQRS.Sample.Models;

namespace MediatR.CQRS.Sample.Commands;

public record AddProductCommand(Product Product) : IRequest<Product>;
using MediatR.CQRS.Sample.Models;

namespace MediatR.CQRS.Sample.Queries;

public record GetProductsQuery : IRequest<IEnumerable<Product>>;
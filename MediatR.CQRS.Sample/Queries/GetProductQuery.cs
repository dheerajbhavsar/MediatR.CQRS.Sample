using MediatR.CQRS.Sample.Models;

namespace MediatR.CQRS.Sample.Queries;

public record GetProductQuery(int Id) : IRequest<Product>;

namespace MediatR.CQRS.Sample.Commands;

public record DeleteProductCommand(int Id) : IRequest<bool>;

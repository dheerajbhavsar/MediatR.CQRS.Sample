using MediatR.CQRS.Sample.Models;

namespace MediatR.CQRS.Sample.Data;

public interface IProductsRepository
{
    Task AddProductAsync(Product product);
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<Product?> GetProductByIdAsync(int id);
}

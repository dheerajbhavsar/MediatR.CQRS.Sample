using MediatR.CQRS.Sample.Models;

namespace MediatR.CQRS.Sample.Data;

public class ProductsRepository : IProductsRepository
{
    private static List<Product>? _products;

	public ProductsRepository()
	{
		_products = new List<Product>
		{
			new Product { Id = 1, Name = "Test product 1" },
            new Product { Id = 2, Name = "Test product 2" },
            new Product { Id = 3, Name = "Test product 3" },
            new Product { Id = 4, Name = "Test product 4" },
            new Product { Id = 5, Name = "Test product 5" }
        };
	}

    public async Task AddProductAsync(Product product)
    {
        _products?.Add(product);
        await Task.CompletedTask;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return _products != null ?
            await Task.FromResult(_products) :
            Enumerable.Empty<Product>();
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        await Task.CompletedTask;
        return _products?.FirstOrDefault(p => p.Id == id);
    }
}

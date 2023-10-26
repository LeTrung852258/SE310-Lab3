using Core.Models;

namespace Core.Repositories
{
    public interface IProductRepo
    {
        Task<IList<Product>> GetProductsAsync();

        Task<Product?> GetProductAsync(int id);

        Task CreateProductAsync(Product product);

        Task UpdateProductAsync(Product product);

        Task DeleteProductAsync(int id);
    }
}

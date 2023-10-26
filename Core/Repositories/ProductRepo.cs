using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories
{
    public class ProductRepo : IProductRepo
    {
        private readonly AppDbContext _dbContext;

        public ProductRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateProductAsync(Product product)
        {
            _dbContext.Add(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            Product? product = await _dbContext.Products.FirstOrDefaultAsync(i => i.Id == id);
            if (product == null)
            {
                throw new ApplicationException("Not found");
            }
            _dbContext.Remove(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Product?> GetProductAsync(int id)
        {
            return await _dbContext.Products.Include(i => i.Category)
                                            .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IList<Product>> GetProductsAsync()
        {
            return await _dbContext.Products.Include(i => i.Category)
                                            .ToListAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            try
            {
                _dbContext.Update(product);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new ApplicationException();
            }
        }
    }
}

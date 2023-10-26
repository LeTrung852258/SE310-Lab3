﻿using Core.Models;

namespace Core.Repositories
{
    public interface IProductRepo
    {
        Task<IList<Product>> GetProductsAsync();

        Task<Product?> GetProductAsync(int id);

        Task<Product> CreateProductAsync(Product product);

        Task<Product> UpdateProductAsync(Product product);

        Task DeleteProductAsync(int id);
    }
}

using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly AppDbContext _dbContext;

        public CategoryRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<Category>> GetCategoriesAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }
    }
}

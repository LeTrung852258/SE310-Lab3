using Core.Models;

namespace Core.Repositories
{
    public interface ICategoryRepo
    {
        Task<IList<Category>> GetCategoriesAsync();
    }
}

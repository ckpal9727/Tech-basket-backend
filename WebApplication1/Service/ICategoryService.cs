
using WebApplication1.Entities;

namespace WebApplication1.Services
{
    public interface ICategoryService
    {
        public Task<Category> AddCategory(Category category);
        public Task<Category> UpdateCategory(Category category);
        public Task<Category> GetCategory(int CategoryId);
        public Task<IEnumerable<Category>> GetAllCategories();
    }
}

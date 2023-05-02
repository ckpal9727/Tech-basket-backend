
using Microsoft.EntityFrameworkCore;
using Practice.API.DbContexts;

using WebApplication1.Entities;

namespace WebApplication1.Services

{
    public class CategoryService : ICategoryService
    {
        private readonly InfoContext infoContext;

        public CategoryService(InfoContext infoContext)
        {
            this.infoContext = infoContext;
        }

        public async Task<Category> AddCategory(Category category)
        {
            await infoContext.Categories.AddAsync(category);
            await infoContext.SaveChangesAsync();
            return category;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
           return await infoContext.Categories.ToListAsync();

        }

        public async Task<Category> GetCategory(int CategoryId)
        {
           return  await infoContext.Categories.FirstOrDefaultAsync(c=>c.CategoryId == CategoryId);
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            infoContext.Categories.Update(category);
            await infoContext.SaveChangesAsync();
            return category;
        }
    }
}

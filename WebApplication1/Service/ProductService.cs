using Microsoft.EntityFrameworkCore;
using Practice.API.DbContexts;
using Practice.API.Services;
using WebApplication1.Entities;

namespace WebApplication1.Services
{
    public class ProductService : IProductService
    {
        private readonly InfoContext infoContext;

        public ProductService(InfoContext infoContext)
        {
            this.infoContext = infoContext;
        }
        public async Task<Product> AddProduct(Product product)
        {
            await infoContext.Products.AddAsync(product);
            await infoContext.SaveChangesAsync();
            return product;
        }

      

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var data= await infoContext.Products.ToListAsync();
            return data;
        }

        public async Task<Product> GetSingleProduct(int productId)
        {
            return await infoContext.Products.FirstOrDefaultAsync(c => c.ProductId == productId);
        }

        public async Task<Product> UpdateProduct(Product product)
        {
             infoContext.Products.Update(product);
            await infoContext.SaveChangesAsync();
            return product;
        }
		public void Delete(int productId)
		{
            var product =  infoContext.Products.FirstOrDefault(p => p.ProductId == productId);
			infoContext.Products.Remove(product);
			 infoContext.SaveChangesAsync();
			
		}
		public async Task<Product> GetProduct(int productId)
		{
            var product =await infoContext.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
			
			
			return product;
		}

	}
}

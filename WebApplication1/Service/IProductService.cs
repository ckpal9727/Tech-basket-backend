using WebApplication1.Entities;
using WebApplication1.Profiles;

namespace Practice.API.Services
{
    public interface IProductService
    {
        public Task<IEnumerable<Product>> GetAllProducts();

        
        public Task<Product> GetSingleProduct(int productId);

        public Task<Product> AddProduct(Product product);
        public void Delete(int productId);

		public Task<Product> UpdateProduct(Product product);
        public  Task<Product> GetProduct(int productId);

	}
}

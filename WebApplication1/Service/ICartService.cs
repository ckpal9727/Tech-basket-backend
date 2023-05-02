
using WebApplication1.Entities;

namespace WebApplication1.Services
{
    public interface ICartService
    {
        public Task<IEnumerable<Cart>> GetAllCart();
        public Task<Cart> GetCartById(int cartId);
        public Task<Cart> AddCart(Cart cart,int UserId);
        public Task<Cart> UpdateCart(Cart cart);

        public Task<bool> DeleteCart(int cartId);
    }
}

using Microsoft.EntityFrameworkCore;
using Practice.API.DbContexts;

using WebApplication1.Entities;
using WebApplication1.Services;

namespace WebApplication1.Service
{
	public class CartServices : ICartService
	{
		private readonly InfoContext infoContext;
		

		public CartServices(InfoContext infoContext)
		{
			this.infoContext = infoContext ?? throw new ArgumentNullException(nameof(infoContext));			
		}
		public async Task<Cart> AddCart(Cart cart,int UserId)
		{
			cart.IsOrderPlaced = false;
			cart.UserId = UserId;
			var product = await infoContext.Products.Where(p => p.ProductId == cart.ProductId).FirstOrDefaultAsync();
			cart.Total = product.Price * cart.productQuantity;
			await infoContext.Carts.AddAsync(cart);
			await infoContext.SaveChangesAsync();
			return cart;
		}

		public async Task<bool> DeleteCart(int cartId)
		{
			var existCart = await infoContext.Carts.Where(c => c.CartId == cartId).FirstOrDefaultAsync();
			var result = infoContext.Carts.Remove(existCart);
			if (result != null)
			{
				return true;
			}
			return false;
		}

		public async Task<IEnumerable<Cart>> GetAllCart()
		{
			return await infoContext.Carts.ToListAsync();
		}

		public async Task<Cart> GetCartById(int cartId)
		{
			return await infoContext.Carts.FirstOrDefaultAsync(c => c.CartId == cartId);
		}

		public async Task<Cart> UpdateCart(Cart cart)
		{
			cart.IsOrderPlaced = false;
			
			var product = await infoContext.Products.Where(p => p.ProductId == cart.ProductId).FirstOrDefaultAsync();
			cart.Total = product.Price * cart.productQuantity;
			infoContext.Carts.Update(cart);
			await infoContext.SaveChangesAsync();
			return cart;
		}
	}
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Practice.API.DbContexts;
using Practice.API.Enums;
using Practice.API.Services;
using WebApplication1.Entities;
using WebApplication1.Model;
using WebApplication1.Profiles;
using WebApplication1.Services;

namespace WebApplication1.Service
{
	public class OrderService : IOrderService
	{
		private readonly InfoContext infoContext;
		private readonly IMapper mapper;
		public OrderService(InfoContext infoContext, IMapper mapper)
		{
			this.infoContext = infoContext ?? throw new ArgumentNullException(nameof(infoContext));
			this.mapper = mapper;
		}
		public async Task<OrderViewModel> AddOrder(Order order, int userId)
		{

			Guid guid = Guid.NewGuid();

			order.UserId = userId;
			order.OrderDate = DateTime.Now;
			order.OrderStatus = OrderStatus.Pending;
			order.Products = new List<Product>();
			var cartItems = await infoContext.Carts.Where(c => c.UserId == userId && c.IsOrderPlaced == false).ToListAsync();
			foreach(var cartItem in cartItems)
			{

				var product = await infoContext.Products.Where(p => p.ProductId == cartItem.ProductId).FirstOrDefaultAsync();
				product.Quantity = cartItem.productQuantity;
				order.Products.Add(product);
				order.OrderUniqueId=guid.ToString();
				var orderItem = new OrderItem();
				orderItem.ProductName= product.ProductName;
				orderItem.ProductId= product.ProductId;
				orderItem.ProductDescription= product.ProductDescription;
				orderItem.Quantity = cartItem.productQuantity;
				orderItem.Price = product.Price;
				orderItem.CategoryId = product.CategoryId;
				orderItem.Image=product.Image;				
				orderItem.OrderUniqueId = guid.ToString();
				await infoContext.OrderItems.AddAsync(orderItem);
				await infoContext.SaveChangesAsync();
				order.TotalAmount += product.Quantity * product.Price;
			}
					
			await infoContext.Orders.AddAsync(order);
			await infoContext.SaveChangesAsync();
			return mapper.Map<OrderViewModel>(order);


		}

		public async Task<ICollection<OrderViewModel>> GetAllOrder()
		{
			var orderViewModels = new List<OrderViewModel>();
			var orders = await infoContext.Orders.ToListAsync();
			foreach (var order in orders)
			{
				orderViewModels.Add(await GetOrder( order.OrderId));
			}
			return orderViewModels;
			
		}

		public async Task<ICollection<OrderViewModel>> GetAllOrder(int userId)
		{
			return mapper.Map<ICollection<OrderViewModel>>(await infoContext.Orders.Where(o => o.UserId == userId).ToListAsync());


		}

		public async Task<OrderViewModel> GetOrder(int orderId)
		{
			var orderViewModel = new OrderViewModel();
			var order = await infoContext.Orders.Where(o =>  o.OrderId==orderId ).FirstOrDefaultAsync();
			var orderItems= await infoContext.OrderItems.Where(i=>i.OrderUniqueId==order.OrderUniqueId).ToListAsync();
			orderViewModel.Products = new List<Product>();
			foreach(var item in orderItems)
			{
				var product = await infoContext.Products.Where(p => p.ProductId == item.ProductId).FirstOrDefaultAsync();
				product.Quantity = item.Quantity;
				orderViewModel.Products.Add(product);
				orderViewModel.OrderDate = order.OrderDate;
				orderViewModel.OrderStatus=order.OrderStatus;
				orderViewModel.OrderId = order.OrderId;
				orderViewModel.UserId = order.UserId;
				orderViewModel.orderUniqueId= order.OrderUniqueId;
				orderViewModel.TotalAmount = order.TotalAmount;
			}
			var orderdata = orderViewModel;
			return orderViewModel;
		}

		public async Task<Order> UpdateOrder(Order order)
		{
			infoContext.Orders.Update(order);
			await infoContext.SaveChangesAsync();
			return order;
		}
	}
}


using WebApplication1.Entities;
using WebApplication1.Model;

namespace WebApplication1.Services
{
    public interface IOrderService
    {
        public Task<ICollection<OrderViewModel>> GetAllOrder();
        public Task<ICollection<OrderViewModel>> GetAllOrder(int userId);
        public Task<OrderViewModel> GetOrder( int orderId);
        public Task<OrderViewModel> AddOrder(Order order,int userId);
        public Task<Order> UpdateOrder(Order order);
        

	}
}

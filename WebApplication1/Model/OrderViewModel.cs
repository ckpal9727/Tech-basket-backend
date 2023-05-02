using Practice.API.Enums;
using WebApplication1.Entities;

namespace WebApplication1.Model
{
	public class OrderViewModel
	{
		public int OrderId { get; set; }
		public int UserId { get; set; }
		public ICollection<Product> Products { get; set; }
		public string orderUniqueId { get; set; }
		public DateTime OrderDate { get; set; }
		public OrderStatus OrderStatus { get; set; }
		public int TotalAmount { get; set; }

	}
}

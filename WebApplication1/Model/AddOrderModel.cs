using WebApplication1.Entities;
using Practice.API.Enums;

namespace WebApplication1.Model
{
    public class AddOrderModel
    {
		public int TotalAmount { get; set; }

		public DateTime OrderDate { get; set; }
		public OrderStatus OrderStatus { get; set; }

	}
}

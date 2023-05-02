using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Entities
{
	public class OrderItem
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int OrderItemId { get; set; }

		public string OrderUniqueId { get; set; }
		public int ProductId { get; set; }
		
		public string ProductName { get; set; }
		public string ProductDescription { get; set; }

		public int CategoryId { get; set; }
		public int Price { get; set; }
		
		public int Quantity { get; set; }

		public string Image { get; set; }


	}
}

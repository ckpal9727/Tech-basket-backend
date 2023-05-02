using System.ComponentModel.DataAnnotations;

namespace Practice.API.Model
{
	public class ProductViewModel
	{
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public string ProductDescription { get; set; }

		public int CategoryId { get; set; }

		
		public int Price { get; set; }
	
		public int Quantity { get; set; }
		public string Image { get; set; }
	}
}

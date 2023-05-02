using WebApplication1.Entities;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.API.Model
{
    public class AddCartModel
    {

		public int ProductId { get; set; }
		public int productQuantity { get; set; }


	}

}

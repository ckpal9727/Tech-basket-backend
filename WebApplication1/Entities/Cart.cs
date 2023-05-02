using Practice.API.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities
{
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartId { get; set; }

        public int ProductId { get; set; }
        public int productQuantity { get; set; }
        public virtual Product Product { get; set; }
        public decimal Total { get; set; }
        public int UserId { get; set; }
        public virtual Users User { get; set; }
        public bool IsOrderPlaced { get; set; } = false;





    }
}

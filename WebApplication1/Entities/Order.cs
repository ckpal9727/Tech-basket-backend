using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Practice.API.Enums;

namespace WebApplication1.Entities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public string OrderUniqueId { get; set; }
        public int UserId { get; set; }
        public virtual Users User { get; set; }
        public int TotalAmount { get; set; }

        public List<Product> Products { get; set; } 
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }

    }
}

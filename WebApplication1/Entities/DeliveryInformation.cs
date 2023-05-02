using Practice.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities
{
    public class DeliveryInformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeliveryId { get; set; }

        public DeliveryStatus DeliveryStatus { get; set; }
        [Required]
        public string Address { get; set; }
        public int UserId { get; set; }
        public virtual Users User { get; set; }
    }
}

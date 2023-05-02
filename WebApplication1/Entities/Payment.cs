using Practice.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentId { get; set; }
        public int UserId { get; set; }
        public virtual Users User { get; set; }
        public int amount { get; set; }
        public DateTime PaymentDate { get; set; }
        [Required]
        public string PaymentMethod { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }
}

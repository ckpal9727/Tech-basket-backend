using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using Practice.API.Enums;

namespace WebApplication1.Entities
{
    public class Users
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        [MaxLength(35)]
        public string Email { get; set; }
        public string Gender { get; set; }
        public string CreatedAt { get; set; } = DateTime.Now.ToString();
        public string UpdatedAt { get; set; } = DateTime.Now.ToString();
		[Required]

        public string Password { get; set; }
        [Required]
        [MaxLength(10)]
        [MinLength(10)]
        public string Mobile { get; set; }
        public UserRoles userRoles { get; set; }



    }
}

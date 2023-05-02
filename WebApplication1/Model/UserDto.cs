using Practice.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practice.API.Model
{
    public class UserDto
    {
        

      

		
			public int UserId { get; set; }
			
			public string FirstName { get; set; }
			public string LastName { get; set; }
		
			public string Email { get; set; }
			public string Gender { get; set; }
			public string CreatedAt { get; set; } = DateTime.Now.ToString();
			public string UpdatedAt { get; set; } = DateTime.Now.ToString();
			

			public string Password { get; set; }
			
			public string Mobile { get; set; }
			public UserRoles userRoles { get; set; }



		}
	}




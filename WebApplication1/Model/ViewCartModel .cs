using WebApplication1.Entities;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model
{
    public class ViewCartModel
    {
        
        public int UserId { get; set; }

       public int ProductId { get; set;}
       public int Quantity { get; set;}
      
    }

}

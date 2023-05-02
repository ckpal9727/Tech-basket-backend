using AutoMapper;
using WebApplication1.Entities;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model
{
    public class ProductAddModel
    {


        public string ProductName { get; set; }
        public string ProductDescription { get; set; }

        public int CategoryId { get; set; }


        
        [Required]
        public int Price { get; set; }
        [Required]
        public int Quantity { get; set; }
       
        public string Image { get; set; }
       
    }
}

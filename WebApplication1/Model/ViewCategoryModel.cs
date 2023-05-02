using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Practice.API.Model
{
    public class ViewCategoryModel
    {
      
        public int CategoryId { get; set; }
        
        public string CategoriesName { get; set; }
        public string Description { get; set; }
    }
}

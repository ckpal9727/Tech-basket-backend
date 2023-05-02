using System.ComponentModel.DataAnnotations;

namespace Practice.API.Model
{
    public class AddCategoryModel
    {
        [Required]
        public string CategoriesName { get; set; }
        [MaxLength(300)]
        public string Description { get; set; }
    }
}

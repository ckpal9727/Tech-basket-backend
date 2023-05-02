using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using Practice.API.Model;
using WebApplication1.Services;
using WebApplication1.Entities;
using WebApplication1.Profiles;


namespace WebApplication1.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController:ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ICategoryService categoryService;

        public CategoryController(IMapper mapper,ICategoryService categoryService)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }
        [HttpPost]
        public async Task<ActionResult<Category>> AddCategory(AddCategoryModel category)
        {
            if (category != null)
            {
                var addeCategory=await categoryService.AddCategory(mapper.Map<Category>(category));
                if(addeCategory != null)
                {
                    return Ok(addeCategory);
                }
                return Ok("Not Added");
            }
            return null;
        }
        [HttpPut("categoryId")]

        public async Task<ActionResult<Category>> UpdateCategory(AddCategoryModel addCategoryModel,int categoryId)
        {
            var existCategory = await categoryService.GetCategory(categoryId);
            if (existCategory != null)
            {
                return Ok(await categoryService.UpdateCategory(mapper.Map(addCategoryModel,existCategory)));
            }
            return null;
        }
        [HttpGet("categoryId")]
        public async Task<ActionResult<Category>> GetCategory( int categoryId)
        {           
            if (categoryId != null)
            {
                return Ok(await categoryService.GetCategory(categoryId));
            }
            return null;
        }

        [HttpGet("allCategory")]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllcategories()
        {
            return Ok(await categoryService.GetAllCategories());
        }



    }
}

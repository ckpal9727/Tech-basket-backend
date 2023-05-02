using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entities;
using Practice.API.Model;
using Practice.API.Services;
using WebApplication1.Model;

namespace Practice.API.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController:ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IProductService productService;

        public ProductController(IMapper mapper, IProductService productService)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.productService = productService ?? throw new ArgumentNullException(nameof(productService));
            
        }
        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(ProductAddModel productAddModel)
        {
            if (productAddModel != null)
            {
                var addedProduct = await productService.AddProduct(mapper.Map<Product>(productAddModel));
                if (addedProduct != null)
                {
                    return Ok(addedProduct);
                }
                return Ok("Not Added");
            }
            return null;
        }
        [HttpPut("categoryId")]

        public async Task<ActionResult<Product>> UpdateProduct(ProductAddModel productAddModel, int productId)
        {
            var existProduct = await productService.GetSingleProduct(productId);
            if (existProduct != null)
            {
                return Ok(await productService.UpdateProduct(mapper.Map(productAddModel, existProduct)));
            }
            return null;
        }
        [HttpGet("categoryId")]
        public async Task<ActionResult<Product>> GetCategory(int productId)
        {
            if (productId != null)
            {
                return Ok(await productService.GetSingleProduct(productId));
            }
            return null;
        }

        [HttpGet("allCategory")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            return Ok(await productService.GetAllProducts());
        }



    }
}

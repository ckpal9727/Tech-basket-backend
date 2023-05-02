using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.API.Model;
using WebApplication1.Entities;
using WebApplication1.Services;

namespace Practice.API.Controllers
{
    [Route("api/{userId}/cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ICartService cartService;

        public CartController(IMapper mapper, ICartService cartService)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.cartService = cartService ?? throw new ArgumentNullException(nameof(cartService));
        }

        [HttpGet("allCart")]
        public async Task<ActionResult<IEnumerable<Cart>>> GetAllCart()
        {
                return Ok(await cartService.GetAllCart());
        }
        [HttpGet]
        public async Task<ActionResult<Cart>> GetSingleCart(int cartId)
        {
            if (cartId != null)
            {
                return Ok(await cartService.GetCartById(cartId));
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult<Cart>> AddCart(AddCartModel addCartModel,int userId)
        {
            if (addCartModel != null)
            {
                var addedCart = await cartService.AddCart(mapper.Map<Cart>(addCartModel),userId);
                if(addedCart!= null)
                {
                    return Ok(addedCart);
                }
                return BadRequest("Not Added Cart");
            }
            return BadRequest("Not Added Cart");
        }
        [HttpPut]
        public async Task<ActionResult<Cart>> UpdateCart(AddCartModel addCartModel,int cartId)
        {
            var existCart=await cartService.GetCartById(cartId);
            if(existCart!= null)
            {
                var updatedCart=await cartService.UpdateCart(mapper.Map(addCartModel,existCart));
                if(updatedCart!= null)
                {
                    return Ok(updatedCart);
                }
                return BadRequest("Not Updated");
            }
            return BadRequest("Not Updated");
        }


    }
}

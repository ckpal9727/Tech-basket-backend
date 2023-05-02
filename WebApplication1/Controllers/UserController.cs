using AutoMapper;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Practice.API.Model;
using Practice.API.Services;


namespace Practice.API.Controllers
{
    [Route("api/user")]
    [Authorize]
    [ApiController]

    public class UserController:ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserController(IUserService userService,IMapper mapper)
        {
            this.userService = userService ?? throw new ArgumentNullException(nameof(userService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
     
        [HttpGet("getUser")]

        public async Task<UserDto> GetSingleUser([FromQuery] string email)
        {
            var Data = await userService.GetSingleUser(email);
            return mapper.Map<UserDto>(Data);
           
        }       
       
        [HttpGet("getfakedata")]
        public async Task<IActionResult> GetData()
        {
            return Ok("data");
        }

    }
}

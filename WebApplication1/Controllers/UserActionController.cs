using Microsoft.AspNetCore.Mvc;
using Practice.API.Model;
using Practice.API.Services;

namespace Practice.API.Controllers
{
    [Route("user/action")]
    [ApiController]
    public class UserActionController:ControllerBase
    {
        private readonly IUserService userService;

        public UserActionController(IUserService userService)
        {
            this.userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }
        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateNewUser(UserDto userDto)
        {

            await userService.CreateUser(userDto);
            await userService.SaveChangesAsync();
            return userDto;
        }
        [HttpPost("login")]
        public async Task<string> Login(UserLoginDto userLoginDto)
        {
            return await userService.LoginUser(userLoginDto.Email, userLoginDto.Password);
        }
    }
}

using WebApplication1.Entities;
using Practice.API.Model;
using Practice.API.Profiles;

namespace Practice.API.Services
{
    public interface IUserService
    {
        Task<UserDto> GetSingleUser(string username);
        Task CreateUser(UserDto userDto);
        Task<string> LoginUser(string email,string password);
        Task<bool> SaveChangesAsync();
         public Task<IEnumerable<Users>> GetAllUsers();
    }
}

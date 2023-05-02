using AutoMapper;
using WebApplication1.Entities;

namespace Practice.API.Profiles
{
    public class User:Profile
    {
        public User()
        {
            CreateMap<Model.UserDto, Users>();
            CreateMap<Users, Model.UserDto>();
        }
    }
}

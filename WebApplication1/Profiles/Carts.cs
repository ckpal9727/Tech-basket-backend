using AutoMapper;
using WebApplication1.Entities;
using Practice.API.Model;
using WebApplication1.API.Model;

namespace WebApplication1.Profiles
{
    public class Carts:Profile
    {
        public Carts()
        {
            CreateMap<Cart,AddCartModel>().ReverseMap();
            CreateMap<Cart,UpdateCartModel>().ReverseMap();
        }
    }
}

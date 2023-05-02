using AutoMapper;
using WebApplication1.Entities;
using Practice.API.Model;
using WebApplication1.Model;

namespace WebApplication1.Profiles
{
    public class Products:Profile
    {
        public Products()
        {
            CreateMap<ProductAddModel,Product>().ReverseMap();
            CreateMap<ProductViewModel,Product>().ReverseMap();
        }
    }
}

using AutoMapper;
using Practice.API.Model;
using WebApplication1.Entities;
using WebApplication1.Model;

namespace WebApplication1.Profiles
{
    public class Categories:Profile
    {
        public Categories()
        {
            CreateMap<AddCategoryModel,Category>().ReverseMap();
        }
    }
}

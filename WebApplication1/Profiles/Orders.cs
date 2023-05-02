using AutoMapper;
using WebApplication1.Entities;
using WebApplication1.Model;

namespace WebApplication1.Profiles
{
    public class Orders:Profile
    {
        public Orders()
        {
            CreateMap<Order,AddOrderModel>().ReverseMap();
            CreateMap<Order,OrderViewModel>().ReverseMap();
        }
    }
}

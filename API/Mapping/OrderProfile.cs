using API.Application.ViewModels;
using API.Application.ViewModels.Orders;
using AutoMapper;
using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.OrderAggregate;

namespace API.Mapping
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderViewModel>();
        }
    }
}

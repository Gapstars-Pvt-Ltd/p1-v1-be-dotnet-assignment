using API.Application.ViewModels;
using API.Application.ViewModels.Orders;
using AutoMapper;
using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.OrderAggregate;
using System.Collections.Generic;

namespace API.Mapping
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderViewModel>()
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.Items));

           
            CreateMap<OrderItem, OrderItemViewModel>();

           

        }
    }
}

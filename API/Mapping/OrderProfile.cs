using API.Application.ViewModels;
using API.Application.ViewModels.Orders;
using AutoMapper;
using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.OrderAggregate;
using System.Collections.Generic;
using System.Linq;

namespace API.Mapping
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            // create Map for mapping order to order view model 
            CreateMap<Order, OrderViewModel>()
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.Items)).ReverseMap();

           //create map for Order Item convert to orderItemVieModel
            CreateMap<OrderItem, OrderItemViewModel>().ReverseMap();

          

        }
    }

  
}

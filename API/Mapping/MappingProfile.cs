using System.Diagnostics;
using API.Application.Dto;
using API.Application.ViewModels;
using AutoMapper;
using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.FlightAggregate;
using OrderItem = Domain.Aggregates.OrderAggregate.OrderItem;

namespace API.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Airport, AirportViewModel>();
        CreateMap<Flight, FlightViewModel>();

        CreateMap<OrderItem, OrderDto>().ReverseMap();
    }
}
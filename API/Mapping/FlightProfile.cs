using API.Application.ViewModels;
using API.Application.ViewModels.Flights;
using API.Application.ViewModels.Orders.View;
using AutoMapper;
using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.FlightAggregate;

namespace API.Mapping
{
    public class FlightProfile : Profile
    {
        public FlightProfile() {

            CreateMap<AvailableFlightsDomainViewModel, AvailableFlightsViewModel>().ReverseMap();

            CreateMap<Flight,FlightViewModel>().ForMember(dest => dest.Rates, opt => opt.MapFrom(src => src.Rates)).ReverseMap();

            CreateMap<FlightRate, FlightRateViewModel>().ReverseMap();
        }
    }
}

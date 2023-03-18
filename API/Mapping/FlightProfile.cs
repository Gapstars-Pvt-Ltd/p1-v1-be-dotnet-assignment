using API.Application.ViewModels;
using API.Application.ViewModels.Flights;
using AutoMapper;
using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.FlightAggregate;

namespace API.Mapping
{
    public class FlightProfile : Profile
    {
        public FlightProfile() {

            CreateMap<AvailableFlightsDomainViewModel, AvailableFlightsViewModel>().ReverseMap();
        }
    }
}

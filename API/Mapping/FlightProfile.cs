using API.ApiResponses;
using API.Application.ViewModels;
using AutoMapper;
using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.FlightAggregate;
using System.Linq;

namespace API.Mapping
{
    public class FlightProfile : Profile
    {
        public FlightProfile()
        {
            CreateMap<Flight, FlightResponse>()
                .ConstructUsing(x => new FlightResponse(
                    x.OriginAirport.Code,
                    x.DestinationAirport.Code,
                    x.Departure,
                    x.Arrival,
                    x.Rates.Select(p => p.Price.Value).DefaultIfEmpty().Min()
                ));
        }
    }
}

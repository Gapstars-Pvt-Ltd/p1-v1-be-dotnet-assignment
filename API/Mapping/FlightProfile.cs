using API.ApiResponses;
using AutoMapper;
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
                    x.DestinationAirportId.ToString(),
                    x.OriginAirportId.ToString(),
                    x.Departure,
                    x.Arrival,
                    x.Rates.Select(p => p.Price.Value).Min()
                ));
        }
    }
}

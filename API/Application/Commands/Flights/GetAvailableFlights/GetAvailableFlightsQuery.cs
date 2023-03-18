using API.Application.ViewModels.Flights;
using Domain.Aggregates.FlightAggregate;
using MediatR;
using System.Collections.Generic;

namespace API.Application.Commands.Flights.GetAvailableFlights
{
    public class GetAvailableFlightsQuery : IRequest<List<AvailableFlightsDomainViewModel>>
    {
        public string AirPortCode { get; set; }
    }
}

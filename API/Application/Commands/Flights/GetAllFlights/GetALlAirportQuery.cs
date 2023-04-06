using API.ApiResponses;
using Domain.Aggregates.FlightAggregate;
using MediatR;
using System.Collections.Generic;

namespace API.Application.Commands.Flights.GetAllFlights
{
    public class GetALlAirportQuery : IRequest<List<Flight>>
    {

    }
}

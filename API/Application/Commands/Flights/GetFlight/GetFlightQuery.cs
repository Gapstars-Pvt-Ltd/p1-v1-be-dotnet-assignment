using Domain.Aggregates.FlightAggregate;
using MediatR;
using System;
using System.Collections.Generic;

namespace API.Application.Commands.Flights.GetFlight
{
    public class GetFlightQuery : IRequest<Flight>
    {
       public Guid Id { get; set; }
    }
}

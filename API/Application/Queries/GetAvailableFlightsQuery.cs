using API.ApiResponses;
using MediatR;
using System;
using System.Collections.Generic;

namespace API.Application.Queries
{
    public class GetAvailableFlightsQuery : IRequest<List<FlightResponse>>
    {
        public Guid DestinationAirportId { get; private set; } 

        public GetAvailableFlightsQuery(Guid destinationAirportId)
        {
            DestinationAirportId = destinationAirportId;
        }
    }
}

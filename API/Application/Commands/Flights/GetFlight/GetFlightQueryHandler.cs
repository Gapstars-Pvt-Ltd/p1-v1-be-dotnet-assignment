using API.Application.Commands.Flights.GetAvailableFlights;
using Domain.Aggregates.FlightAggregate;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Commands.Flights.GetFlight
{
    public class GetFlightQueryHandler : IRequestHandler<GetFlightQuery, Flight>
    {
        private readonly IFlightRepository _flightRepository;

        public GetFlightQueryHandler(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public async Task<Flight> Handle(GetFlightQuery request, CancellationToken cancellationToken)
        {
            return await _flightRepository.GetAsync(request.Id);
        }
    }
}

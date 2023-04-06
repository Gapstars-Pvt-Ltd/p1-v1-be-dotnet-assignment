using API.ApiResponses;
using API.Application.Commands.Flights.GetAvailableFlights;
using Domain.Aggregates.FlightAggregate;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Commands.Flights.GetAllFlights
{
    public class GetALlAirportQueryHandler : IRequestHandler<GetALlAirportQuery, List<Flight>>
    {
        private IFlightRepository _flightRepository { get; set; }

        public GetALlAirportQueryHandler(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public async Task<List<Flight>> Handle(GetALlAirportQuery request, CancellationToken cancellationToken)
        {
            return await  _flightRepository.GetAll();

        }
    }
}

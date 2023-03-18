using Domain.Aggregates.FlightAggregate;
using MediatR;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Commands.Flights.GetAvailableFlights
{
    public class GetAvailableFlightsQueryHandler : IRequestHandler<GetAvailableFlightsQuery, List<AvailableFlightsDomainViewModel>>
    {
        private IFlightRepository _flightRepository { get; set; }

        public GetAvailableFlightsQueryHandler(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public Task<List<AvailableFlightsDomainViewModel>> Handle(GetAvailableFlightsQuery request, CancellationToken cancellationToken)
        {

            return _flightRepository.Search(request.AirPortCode);

        }
    }
}

using Application.ViewModels;
using Domain.Aggregates.FlightAggregate;
using Domain.SeedWork;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Query
{
    public class GetAvailableFlightsQueryHandler : IRequestHandler<GetAvailableFlightsQuery, List<AvailableFlightsViewModel>>
    {
        private readonly IFlightRepository _flightRepository;

        public GetAvailableFlightsQueryHandler(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }
        public Task<List<AvailableFlightsViewModel>> Handle(GetAvailableFlightsQuery request, CancellationToken cancellationToken)
        {
            var airport = _flightRepository.GetAllAvailableFlightsAsync(request.AirPortCode);
            return airport;
        }
    }
}

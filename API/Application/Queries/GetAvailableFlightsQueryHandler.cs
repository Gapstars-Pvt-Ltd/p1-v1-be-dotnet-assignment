using API.Application.Commands;
using Domain.Aggregates.AirportAggregate;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using API.ApiResponses;
using System.Collections.Generic;
using Domain.Aggregates.FlightAggregate;
using AutoMapper;
using System;

namespace API.Application.Queries
{
    public class GetAvailableFlightsQueryHandler : IRequestHandler<GetAvailableFlightsQuery, List<FlightResponse>>
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IMapper _mapper;

        public GetAvailableFlightsQueryHandler(IFlightRepository flightRepository, IMapper mapper)
        {
            _flightRepository = flightRepository;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<FlightResponse>> Handle(GetAvailableFlightsQuery request, CancellationToken cancellationToken)
        {
            List<Flight> flights = await _flightRepository.GetAvailableFlights(request.DestinationAirportId);
            return _mapper.Map<List<FlightResponse>>(flights);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Aggregates.FlightAggregate
{
    public interface IFlightRepository
    {
        Flight Add(Flight flight);

        void Update(Flight flight);

        Task<Flight> GetAsync(Guid flightId);

        Task<List<Flight>> GetAvailableFlightsAsync(Guid destinationAirportId, CancellationToken cancellationToken);
    }
}
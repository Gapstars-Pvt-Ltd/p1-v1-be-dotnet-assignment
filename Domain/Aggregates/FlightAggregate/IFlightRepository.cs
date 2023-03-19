using Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Aggregates.FlightAggregate
{
    public interface IFlightRepository : ITransientService
    {
        Flight Add(Flight flight);

        void Update(Flight flight);

        Task<Flight> GetAsync(Guid flightId);

        Task<List<Flight>> GetAll();

        Task<List<AvailableFlightsDomainViewModel>> Search(string AirportCode);


    }
}
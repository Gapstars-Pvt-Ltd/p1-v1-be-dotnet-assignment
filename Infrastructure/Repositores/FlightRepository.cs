using Domain.Aggregates.FlightAggregate;
using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositores
{
    public class FlightRepository : IFlightRepository
    {
        private readonly FlightsContext _context;

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public FlightRepository(FlightsContext context)
        {
            _context = context;
        }

        public Flight Add(Flight flight)
        {
            return _context.Flights.Add(flight).Entity;
        }

        public void Update(Flight flight)
        {
            _context.Flights.Update(flight);
        }

        public async Task<Flight> GetAsync(Guid flightId)
        {
            return await _context.Flights.Include("Rates").FirstOrDefaultAsync(o => o.Id == flightId);
        }

        public async Task<List<Flight>> GetAvailableFlights(Guid destinationAirportId)
        {
            //return await _context.Flights.Where(o => o.DestinationAirportId == destinationAirportId).ToListAsync();
            return await _context.Flights.ToListAsync(); 
        }
    }
}

using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.FlightAggregate;
using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

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

        public Flight Add(Flight _flight)
        {
            return _context.Flights.Add(_flight).Entity;
        }

        public async Task<Flight> GetAsync(Guid flightId)
        {
            return await _context.Flights.Include(x=>x.Rates).FirstOrDefaultAsync(o => o.Id == flightId); 
        }

        public void Update(Flight _flight)
        {
            _context.Flights.Update(_flight);
        }

        public async Task<List<AvailableFlightsDomainViewModel>> Search(string AirportCode)
        {

            var airport = await _context.Airports.SingleOrDefaultAsync(x => x.Code == AirportCode);
            if (airport == null)
            {
                throw new Exception("Cannot Find Airport Realted To Given Code");
            }

            var flights = await _context.Flights
                .Include(x => x.Rates)
                .Where(x => x.DestinationAirportId == airport.Id && x.Rates.Any(rate => rate.Available > 0))
                .ToListAsync();

            var availableFlights = flights.Select(flight => new AvailableFlightsDomainViewModel
            {
                Arrival = flight.Arrival,
                Departure = flight.Departure,
                ArrivalAirportCode = AirportCode,
                DepartureAirportCode = _context.Airports
                                      .Where(x => x.Id == flight.OriginAirportId).SingleOrDefault().Code,
                LowestPrice = flight.Rates
                        .Where(rate => rate.Available > 0)
                        .Select(rate => rate.Price.Value)
                        .Min()
            })
                .ToList();

            return availableFlights;
        }

        public async Task<List<Flight>> GetAll()
        {
          return  await  _context.Flights.ToListAsync();
        }
    }
}

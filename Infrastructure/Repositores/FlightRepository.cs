
using Application.ViewModels;
using Domain.Aggregates.FlightAggregate;
using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            throw new NotImplementedException();
        }

        public async Task<Flight> GetAsync(Guid flightId)
        {
            return await _context.Flights.FirstOrDefaultAsync(f => f.Id == flightId);
        }

        public async Task<List<Flight>> GetAllAsync()
        {
            return await _context.Flights.ToListAsync();
        }

        public async Task<List<AvailableFlightsViewModel>> GetAllAvailableFlightsAsync(string airportCode)
        {
            var availableFlights = await (from flight in _context.Flights
                                     join dap in _context.Airports on flight.DestinationAirportId equals dap.Id
                                     join oap in _context.Airports on flight.OriginAirportId equals oap.Id
                                     where dap.Code == airportCode
                                     && flight.Rates.Any(rate => rate.Available > 0)
                                     select new AvailableFlightsViewModel
                                     {
                                         DepartureAirportCode = oap.Code,
                                         ArrivalAirportCode = dap.Code,
                                         DepartureDateTime = flight.Departure,
                                         ArrivalDateTime = flight.Arrival,
                                         LowestPrice = flight.Rates.Where(rate => rate.Available > 0)
                                                                        .Select(rate => rate.Price.Value)
                                                                        .Min()
                                     }).ToListAsync();
            return availableFlights;
        }

        public void Update(Flight flight)
        {
            throw new NotImplementedException();
        }
    }
}

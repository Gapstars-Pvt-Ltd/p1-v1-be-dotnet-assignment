using System;
using System.Threading.Tasks;
using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate;
using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositores
{
    public class OrderRepository : IOrderRepository
    {
        private readonly FlightsContext _context;
        
        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public OrderRepository(FlightsContext context)
        {
            _context = context;
        }
        
        public Order Add(Order order)
        {
            return _context.Orders.Add(order).Entity;
        }

        public void Update(Order order)
        {
            _context.Orders.Update(order);
        }

        public async Task<Order> GetAsync(Guid orderId)
        {
            return await _context.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task<FlightRate> GetFlightByIdAsync(Guid Id)
        {
            return await _context.FlightRates.FirstOrDefaultAsync(f => f.Id == Id);
        }

        public void UpdateFlightRate(FlightRate flightRate) {
            _context.FlightRates.Update(flightRate);
        }
    }
}
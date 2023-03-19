using Domain.Aggregates.OrderAggregate;
using Domain.Events;
using Domain.Exceptions;
using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositores
{
    public class OrderRepository : IOrderRepository
    {
        private readonly FlightsContext _context;

        public OrderRepository(FlightsContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public Order Add(Order order)
        {
           foreach(var item in order.Items)
            {
                var flightRate = _context.FlightRates.Where(x => x.Id == item.FlightRateId).SingleOrDefault();
                item.Price = Convert.ToDouble(flightRate.Price.Value);
                if (flightRate == null)
                {
                    //todo - implement global exception handing method
                    throw new FlightDomainException($"Flight rate Not Found with given ID");
                }
                
                if(  flightRate.IsOnStock(item.Qty) == false)
                {
                    //todo - implement global exception handing method
                    throw new FlightDomainException($"{flightRate.Name} is Not Enough Qty To Purchase. Only {flightRate.Available} Avaible");
                }
                
            }
            return  _context.Orders.Add(order).Entity;
        }

        public async Task<Order> GetAsync(Guid orderId)
        {
           return await _context.Orders.Include(x=>x.Items).Where(x=>x.Id == orderId).SingleOrDefaultAsync();
        }

        public void Update(Order order)
        {
            throw new NotImplementedException();
        }
    }
}

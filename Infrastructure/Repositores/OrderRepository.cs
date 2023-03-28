using Domain.Aggregates.OrderAggregate;
using Domain.Events;
using Domain.Exceptions;
using Domain.SeedWork;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
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

        /// <summary>
        /// add order 
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <exception cref="FlightDomainException"></exception>
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
            order.OrderNo = GetNextOrderRefNo();
           
            return  _context.Orders.Add(order).Entity;
        }

        /// <summary>
        /// confrim order and raize qty change domain event 
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Order> ConfirmAsync(Guid orderId)
        {
            var CurrentOrder = await _context.Orders.Include(x=>x.Items).Where(x=>x.Id == orderId).SingleOrDefaultAsync();

            var Flight = await _context.Flights.Include(x=>x.Rates).Where(x=>x.Id == CurrentOrder.FlightId).SingleOrDefaultAsync();
            if (CurrentOrder == null)
            {
                throw new Exception("Not Found Exception");
            }
            if (CurrentOrder != null) 
            {
                foreach(var item in CurrentOrder.Items)
                {
                    // triger domain event of changes the avaible qty 
                    if (CurrentOrder.Status == "Pending")
                    {
                        Flight.MutateRateAvailability(item.FlightRateId, -1 * item.Qty);
                    }
                  
                }

               // CurrentOrder.Status = "Confirm";
                CurrentOrder.ConfimOrder();
                
                _context.Orders.Update(CurrentOrder);

                await _context.SaveChangesAsync();
            }
            return CurrentOrder;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders.Include(x=>x.Items).ToListAsync();
        }

        public async Task<List<Order>> GetAllAsyncByCustomer(Guid customerId)
        {
            return await _context.Orders.Include(x => x.Items).Where(x=>x.CustomerId == customerId).ToListAsync();
        }

        public async Task<Order> GetAsync(Guid orderId)
        {
           return await _context.Orders.Include(x=>x.Items).Where(x=>x.Id == orderId).SingleOrDefaultAsync();
        }

        public  async Task<Order> Update(Order order)
        {
           
            _context.Orders.Update(order);

             await _context.SaveChangesAsync();

            return order;
        }


        public void RemoveOrderItem(List<OrderItem> items)
        {
            _context.OrderItems.RemoveRange(items);
        }

        //todo : move business logic to separate service class 
        private string GetNextOrderRefNo()
        {
            try
            {
                var Refno = Convert.ToString(DateTime.Now.Ticks);
                return Refno;
              
            }catch(Exception)
            {
                return "" ;
            }
           
        }

       
    }
}

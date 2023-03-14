using Domain.Aggregates.OrderAggregate;
using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
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

        public Order GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Order Add(Order order)
        {
            return _context.Orders.Add(order).Entity;
        }

        public void Update(Order booking)
        {
            _context.Orders.Update(booking);
        }

        public OrderItems GetOrderItemById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void AddOrderItem(OrderItems orderItem)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrderItem(OrderItems orderItem)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> GetOrder(Guid orderId)
        {
            return await _context.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
        }
    }
}

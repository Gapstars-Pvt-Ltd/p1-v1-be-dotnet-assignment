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

        public IUnitOfWork UnitOfWork => _context;

        public OrderRepository(FlightsContext context)
        {
            _context = context;
        }

        public async Task<Order> GetById(Guid id)
        {
            return _context.Orders.FirstOrDefault(o => o.Id == id);
        }

        public async Task<Order> Add(Order order)
        {
            return _context.Orders.Add(order).Entity;
        }

        public void Update(Order booking)
        {
            _context.Orders.Update(booking);
        }

        public async Task<OrderItem> GetOrderItemById(Guid id)
        {
            return _context.OrderItems.FirstOrDefault(o => o.Id == id);
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            _context.OrderItems.Add(orderItem);
        }

        public void UpdateOrderItem(OrderItem orderItem)
        {
            _context.OrderItems.Update(orderItem);
        }

        public async Task<Order> GetOrder(Guid orderId)
        {
            return await _context.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task<Order> GetOrderByOrderIdAndCustomerId(Guid orderId, Guid customerId)
        {
            return await _context.Orders.Where(o => o.Id == orderId && o.PassengerId == customerId).FirstOrDefaultAsync();
        }
    }
}

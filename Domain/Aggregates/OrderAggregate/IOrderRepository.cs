using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.OrderAggregate
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> GetById(Guid id);
        Task<Order> GetOrderByOrderIdAndCustomerId(Guid orderId, Guid customerId);
        Task<Order> Add(Order order);
        void Update(Order order);
        
        Task<OrderItem> GetOrderItemById(Guid id);
        void AddOrderItem(OrderItem orderItem);
        void UpdateOrderItem(OrderItem orderItem);
    }
}

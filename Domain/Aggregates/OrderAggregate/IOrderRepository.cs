using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.OrderAggregate
{
    public interface IOrderRepository
    {
        Order GetById(Guid id);
        Order Add(Order order);
        void Update(Order order);
        
        OrderItems GetOrderItemById(Guid id);
        void AddOrderItem(OrderItems orderItem);
        void UpdateOrderItem(OrderItems orderItem);
    }
}

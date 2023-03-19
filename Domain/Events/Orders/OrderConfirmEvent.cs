using Domain.Aggregates.OrderAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events.Orders
{
    public class OrderConfirmEvent :INotification
    {
        public Order Order { get; private set; }

        public OrderConfirmEvent(Order order)
        {
            Order = order;
            Console.WriteLine($"Order status Has been Change to Confrim {order.OrderNo}");
        }
    }
}

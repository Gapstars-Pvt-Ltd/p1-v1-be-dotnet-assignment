using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    public class OrderConfirmedEvent : INotification
    {
        public Order Order { get; private set; }
        public Guid CustomerId { get; private set; } // TODO Improvement : introduce Customer
                                                     // entitiy and pass it in instead of the
                                                     // cutomerid

        public OrderConfirmedEvent(Order order, Guid customerId) // TODO Improvement : introduce
                                                                 // Customer entitiy and pass
                                                                 // it in instead of the cutomerid
        {
            Order = order;
            CustomerId = customerId;
        }
    }
}

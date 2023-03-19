using Domain.Common;
using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.OrderAggregate
{
    public class OrderItem : Entity, IAggregateRoot
    {
        public Guid FlightRateId { get; set; }
        public double Price { get;  set; }

        public int Qty { get; set; }

        public OrderItem() { }

        public OrderItem(Guid flightRateId, double price, int qty):this()
        {
            flightRateId = flightRateId;
            Price = price;
            Qty = qty;
        }
    }
}

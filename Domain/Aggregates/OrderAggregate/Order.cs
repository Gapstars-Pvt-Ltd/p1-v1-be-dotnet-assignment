using Domain.Exceptions;
using Domain.SeedWork;
using System;
using System.Runtime.CompilerServices;

namespace Domain.Aggregates.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {

        public Order(Guid flightRateId ,string name, int quantity,decimal price, DateTimeOffset orderDate, DateTimeOffset? orderConfirmedDate = null, bool isConfirmed = false) : this()
        {
            Id = new Guid();
            FlightRateId= flightRateId;
            Name = name;
            Quantity = quantity;
            Price = price;
            OrderDate = orderDate;
            OrderConfirmedDate = orderConfirmedDate;
            this.isConfirmed = isConfirmed;
        }
        public Order()
        {
        }
        public Guid FlightRateId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public DateTimeOffset? OrderConfirmedDate { get; set; }
        public bool isConfirmed { get; set; }

    }
}
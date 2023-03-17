using Domain.Exceptions;
using Domain.SeedWork;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Aggregates.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        public Guid FlightId { get; private set; }

        public string Name { get; private set; }

        public Guid CustomerId { get; private set; }

        public int SeatCount { get; private set; }

        public OrderState State { get; private set; }

        public Order()
        {
        }

        public Order(Guid flightId, string name, Guid customerId, int seatCount) : this()
        {
            FlightId = flightId;
            Name = name;
            CustomerId = customerId;
            SeatCount = seatCount;
        }
    }

    public enum OrderState 
    {
        Draft,
        Confirmed
    }
}

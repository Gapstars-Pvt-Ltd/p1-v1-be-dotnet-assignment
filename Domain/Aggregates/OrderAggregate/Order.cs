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

        public Order()
        {
        }
    }
}

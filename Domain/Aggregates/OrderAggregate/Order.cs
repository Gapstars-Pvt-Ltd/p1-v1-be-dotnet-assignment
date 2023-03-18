using Domain.Aggregates.FlightAggregate;
using Domain.Exceptions;
using Domain.SeedWork;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Aggregates.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        public Guid FlightId { get; private set; }

        public Guid FlightRateId { get; private set; }

        public Guid CustomerId { get; private set; }

        public int SeatCount { get; private set; }

        public OrderState State { get; private set; }

        public Order()
        {
        }

        public Order(Guid flightId, Guid flightRateId, Guid customerId, int seatCount) : this()
        {
            FlightId = flightId;
            FlightRateId = flightRateId;
            CustomerId = customerId;
            SeatCount = seatCount;
        }

        public void ConfirmOrder() 
        {
            State = OrderState.Confirmed; 
        }
    }

    public enum OrderState 
    {
        Draft,
        Confirmed
    }
}

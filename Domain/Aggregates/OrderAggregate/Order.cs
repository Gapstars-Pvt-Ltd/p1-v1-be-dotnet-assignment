﻿using Domain.Aggregates.FlightAggregate;
using Domain.Events;
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
            if (seatCount <= 0)
            {
                throw new OrderDomainException("The order should contain at least one passenger booking.");
            }

            FlightId = flightId;
            FlightRateId = flightRateId;
            CustomerId = customerId;
            SeatCount = seatCount;
        }

        public void UpdateSeatCount(int newSeatCount)
        {
            if (!IsFrozen())
            {
                SeatCount = newSeatCount;
            }
        }

        public void ConfirmOrder() 
        {
            if (!IsFrozen()) 
            {
                State = OrderState.Confirmed;

                AddDomainEvent(new OrderConfirmedEvent(this, CustomerId));
            }            
        }

        private bool IsFrozen() 
        {
            return this.State == OrderState.Confirmed;
        }
    }

    public enum OrderState 
    {
        Draft,
        Confirmed
    }
}

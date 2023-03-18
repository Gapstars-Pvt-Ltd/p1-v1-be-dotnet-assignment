using System;
using Domain.Aggregates.PassengerAggregate;
using MediatR;

namespace Domain.Events;

public class PassengerInfoUpdateEvent : INotification
{
    public Passenger Customer { get; private set; }
    
    public PassengerInfoUpdateEvent(Passenger customer)
    {
        Customer = customer;
    }
}
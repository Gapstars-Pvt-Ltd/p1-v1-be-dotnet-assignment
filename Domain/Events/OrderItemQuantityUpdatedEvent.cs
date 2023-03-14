using System;
using MediatR;

namespace Domain.Events;

public class OrderItemQuantityUpdatedEvent : INotification
{
    public Guid FlightId { get; private set; }
    public int NoOfSeats { get; private set; }
    public OrderItemQuantityUpdatedEvent(Guid flightId, int noOfSeats)
    {
        FlightId = flightId;
        NoOfSeats = noOfSeats;
    }
}
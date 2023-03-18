using System;
using MediatR;

namespace Domain.Events;

public class OrderItemAddedEvent : INotification
{
    public Guid FlightId { get; private set; }
    public int NoOfSeats { get; private set; }
    public decimal Price { get; private set; }
    
    public OrderItemAddedEvent(Guid flightId, int noOfSeats, decimal price)
    {
        FlightId = flightId;
        NoOfSeats = noOfSeats;
        Price = price;
    }
}
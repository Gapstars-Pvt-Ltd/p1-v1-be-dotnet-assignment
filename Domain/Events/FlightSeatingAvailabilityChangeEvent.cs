using System;
using MediatR;

namespace Domain.Events;

public class FlightSeatingAvailabilityChangeEvent : INotification
{
    public Guid FlightId { get; private set; }
    public int NoOfSeats { get; private set; }
    public FlightSeatingAvailabilityChangeEvent(Guid flightId, int noOfSeats)
    {
        FlightId = flightId;
        NoOfSeats = noOfSeats;
    }
}
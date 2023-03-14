using System;
using MediatR;

namespace Domain.Events;

public class OrderPlacedEvent : INotification
{
    public Guid OrderId { get; private set; }
    public OrderPlacedEvent(Guid orderId)
    {
        OrderId = orderId;
    }
}
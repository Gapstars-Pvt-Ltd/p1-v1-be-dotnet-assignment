using System;
using Domain.Aggregates.OrderAggregate;
using MediatR;

namespace Domain.Events;

public class OrderPlacedEvent : INotification
{
    public Order Order { get; }
    public OrderPlacedEvent(Order order)
    {
        Order = order;
    }
}
using System;
using Domain.Common;
using MediatR;

namespace Domain.Events;

public class OrderCancelledEvent : INotification    
{
    public Guid OrderId { get; private set; }
    public OrderStatus Status { get; private set;  }
    public OrderCancelledEvent(Guid orderId, OrderStatus status)
    {
        OrderId = orderId;
        Status = status;
    }
}
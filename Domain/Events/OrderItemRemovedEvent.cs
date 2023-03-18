using System;
using MediatR;

namespace Domain.Events;

public class OrderItemRemovedEvent : INotification
{
    public Guid OrderItemId { get; set; }
    public Guid OrderId { get; set; }
    
    public OrderItemRemovedEvent(Guid orderItemId, Guid orderId)
    {
        OrderItemId = orderItemId;
        OrderId = orderId;
    }
}
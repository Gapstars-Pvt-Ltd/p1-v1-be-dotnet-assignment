using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.PassengerAggregate;
using Domain.Common;
using Domain.Events;
using Domain.SeedWork;

namespace Domain.Aggregates.OrderAggregate;

public class Order : Entity, IAggregateRoot
{
    public DateTimeOffset OrderDate { get; private set; }
    public Guid PassengerId { get; private set; }
    
    private List<OrderItem> _orderItems = new List<OrderItem>();
    public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();
    public decimal Total { get; private set; }

    public Order() { }

    public Order(Guid passengerId, List<OrderItem> orderItems) : this()
    {
        PassengerId = passengerId;
        OrderDate = DateTimeOffset.Now;
        _orderItems = orderItems;
        Total = OrderItems.Sum(o => o.TotalPrice);
    }
    
    public void AddOrderItem(OrderItem orderItem)
    {
        _orderItems.Add(orderItem);
    }

    public void RemoveOrderItem(OrderItem orderItem)
    {
        _orderItems.Remove(orderItem);
    }

    public void UpdateOrderItemQuantity(OrderItem orderItem, int quantity)
    {
        orderItem.UpdateQuantity(quantity);
    }

    public void UpdateOrderItemPrice(OrderItem orderItem, decimal price)
    {
        orderItem.UpdatePrice(price);
    }

    public void Place(Order order)
    {
        AddDomainEvent(new OrderPlacedEvent(order));
    }
}
using Domain.Aggregates.FlightAggregate;
using Domain.Exceptions;
using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Events;

namespace Domain.Aggregates.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public decimal Total { get; set; }
        public OrderStatus Status { get; set; }
        
        private readonly List<OrderItems> _orderItems;
        public IReadOnlyCollection<OrderItems> OrderItems => _orderItems.AsReadOnly();

        public Order() { }
        public Order(Guid customerId, decimal total)
        {
            OrderId = Guid.NewGuid();
            CustomerId = customerId;
            OrderDate = DateTimeOffset.Now;
            Total = total;
            Status = OrderStatus.New;
        }

        public void AddOrderItem(Guid flightId, int noOfSeats, decimal price)
        {
            var orderItem = new OrderItems(flightId, noOfSeats, price);
            _orderItems.Add(orderItem); 
            
            AddDomainEvent(new OrderItemAddedEvent(flightId, noOfSeats, price));
        }

        public void UpdateOrderItemQuantity(Guid flightId, int noOfSeats)
        {
            var orderItem = _orderItems.SingleOrDefault(x => x.FlightId == flightId);
            
            if (orderItem != null)
            {
                orderItem.UpdateSeatCount(noOfSeats);
                
                AddDomainEvent(new OrderItemQuantityUpdatedEvent(flightId, noOfSeats));
            }
        }

        public void PlaceOrder()
        {
            if (Status == OrderStatus.New)
            {
                Status = OrderStatus.Placed;
                
                AddDomainEvent(new OrderPlacedEvent(OrderId));
            }
        }
    }
}
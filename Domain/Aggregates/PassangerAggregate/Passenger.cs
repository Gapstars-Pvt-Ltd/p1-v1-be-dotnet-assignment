using System;
using System.Collections.Generic;
using Domain.Aggregates.OrderAggregate;
using Domain.Events;
using Domain.SeedWork;

namespace Domain.Aggregates.PassengerAggregate
{
    public class Passenger : Entity, IAggregateRoot
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }
        public string Email { get; private set; }
        
        private List<Order> _orders = new List<Order>();
        public IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();

        public Passenger() { }
        
        public Passenger(string firstName, string lastName, int age, string email) : this()
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Email = email;
        }
        
        public void PlaceOrder(List<OrderItem> orderItems)
        {
            var order = new Order(Id, orderItems);
            _orders.Add(order);
            order.Place(order);
            
            AddDomainEvent(new OrderPlacedEvent(order));
        }
    }
}

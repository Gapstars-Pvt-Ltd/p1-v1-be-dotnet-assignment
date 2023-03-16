using System;
using System.Collections.Generic;
using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate;
using Domain.Aggregates.PassengerAggregate;

namespace API.Application.Dto;

public class OrderDto
{
    public PassengerInfo PassengerInfo { get; set; }
    public List<OrderItem> OrderItems { get; set; }
}

public record OrderItem (Guid flightId, int quantity, decimal unitPrice);
public record PassengerInfo (string firstName, string lastName, int Age, string email);
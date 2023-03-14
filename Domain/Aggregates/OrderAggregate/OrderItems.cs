using System;

namespace Domain.Aggregates.OrderAggregate;

public class OrderItems
{
    public Guid OrderItemId { get; set; }
    public Guid FlightId { get; set; }
    public int NoOfSeats { get; set; }
    public decimal Price { get; set; }
    
    public decimal Total => NoOfSeats * Price;

    public OrderItems(Guid flightId, int noOfSeats, decimal price)
    {
        OrderItemId = Guid.NewGuid();
        FlightId = flightId;
        NoOfSeats = noOfSeats;
        Price = price;
    }
    
    public void UpdateSeatCount(int noOfSeats)
    {
        NoOfSeats = noOfSeats;
    }
}
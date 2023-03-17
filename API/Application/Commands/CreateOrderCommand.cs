using Domain.Aggregates.OrderAggregate;
using MediatR;
using System;

namespace API.Application.Commands
{
    public class CreateOrderCommand : IRequest<Order>
    {
        public Guid FlightId { get; private set; }

        public string Name { get; private set; }

        public Guid CustomerId { get; private set; }

        public int SeatCount { get; private set; }

        public CreateOrderCommand(Guid flightId, string name, Guid customerId, int seatCount)
        {
            FlightId = flightId;
            Name = name;
            CustomerId = customerId;
            SeatCount = seatCount;
        }
    }
}

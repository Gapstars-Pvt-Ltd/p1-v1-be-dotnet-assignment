using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate;
using MediatR;
using System;

namespace API.Application.Commands
{
    public class CreateOrderCommand : IRequest<Order>
    {
        public Guid FlightId { get; private set; }

        public Guid FlightRateId { get; private set; }

        public Guid CustomerId { get; private set; }

        public int SeatCount { get; private set; }

        public CreateOrderCommand(Guid flightId, Guid flightRateId, Guid customerId, int seatCount)
        {
            FlightId = flightId;
            FlightRateId = flightRateId;
            CustomerId = customerId;
            SeatCount = seatCount;
        }
    }
}

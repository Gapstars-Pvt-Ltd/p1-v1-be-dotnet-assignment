

using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.OrderAggregate;
using MediatR;

namespace Application.Commands
{
    public class CreateOrderCommand : IRequest<Order>
    {
        public CreateOrderCommand(string name,int quantity, Guid flightRateId)
        {
            Name = name;
            Quantity = quantity;
            FlightRateId = flightRateId;
        }

        public Guid FlightRateId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

    }
}
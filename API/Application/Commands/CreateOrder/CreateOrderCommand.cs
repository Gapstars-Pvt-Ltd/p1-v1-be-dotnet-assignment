using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate;
using Domain.Aggregates.PassangerAggregate;
using MediatR;

namespace API.Application.Commands
{
    public class CreateOrderCommand : IRequest
    {
        public string Class { get; set; }
        public int NoOfPassengers {  get; set; }
        public Flight Flight { get; set; }
        public Passenger Customer { get; set; }
    }
}

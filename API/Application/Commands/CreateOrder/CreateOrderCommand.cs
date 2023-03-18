using API.Application.Dto;
using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate;
using Domain.Aggregates.PassengerAggregate;
using MediatR;

namespace API.Application.Commands
{
    public class CreateOrderCommand : IRequest
    {
        public OrderDto OrderDto { get; set; }
    }
}

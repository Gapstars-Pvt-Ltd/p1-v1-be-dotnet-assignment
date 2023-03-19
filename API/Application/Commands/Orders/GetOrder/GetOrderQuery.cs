using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate;
using MediatR;
using System;

namespace API.Application.Commands.Orders.GetOrder
{
    public class GetOrderQuery : IRequest<Order>
    {
        public Guid Id { get; set; }
    }
}

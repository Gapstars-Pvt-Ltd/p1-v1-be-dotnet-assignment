using API.Application.ViewModels.Orders;
using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate;
using MediatR;
using System;

namespace API.Application.Commands.Orders.GetOrder
{
    public class GetOrderQuery : IRequest<OrderViewModel>
    {
        public Guid Id { get; set; }
    }
}

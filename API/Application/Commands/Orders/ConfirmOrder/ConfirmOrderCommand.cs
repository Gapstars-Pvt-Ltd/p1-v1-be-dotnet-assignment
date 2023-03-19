using Domain.Aggregates.OrderAggregate;
using MediatR;
using System;

namespace API.Application.Commands.Orders.ConfirmOrder
{
    public class ConfirmOrderCommand : IRequest<Order>
    {
        public Guid Id { get; set; }
    }
}

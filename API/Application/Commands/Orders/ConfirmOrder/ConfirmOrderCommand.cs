using API.Application.ViewModels.Orders;
using Domain.Aggregates.OrderAggregate;
using MediatR;
using System;

namespace API.Application.Commands.Orders.ConfirmOrder
{
    public class ConfirmOrderCommand : IRequest<OrderViewModel>
    {
        public Guid Id { get; set; }
    }
}

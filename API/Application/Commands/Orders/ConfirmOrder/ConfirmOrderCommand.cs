using API.Application.ViewModels.Orders.View;
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

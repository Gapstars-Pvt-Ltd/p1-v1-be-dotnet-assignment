using API.Application.ViewModels.Orders.View;
using Domain.Aggregates.OrderAggregate;
using MediatR;
using System;
using System.Collections.Generic;

namespace API.Application.Commands.Customers.GetOrders
{
    public class GetOrdersByCutomerQuery : IRequest<List<OrderViewModel>>
    {
        public Guid CustomerId { get; set; }
    }
}

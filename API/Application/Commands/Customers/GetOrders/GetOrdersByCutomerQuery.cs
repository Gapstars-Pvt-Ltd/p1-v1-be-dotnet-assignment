using Domain.Aggregates.OrderAggregate;
using MediatR;
using System;
using System.Collections.Generic;

namespace API.Application.Commands.Customers.GetOrders
{
    public class GetOrdersByCutomerQuery : IRequest<List<Order>>
    {
        public Guid CustomerId { get; set; }
    }
}

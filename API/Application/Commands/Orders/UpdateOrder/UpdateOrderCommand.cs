using API.Application.ViewModels.Orders;
using System.Collections.Generic;
using System;
using Domain.Aggregates.OrderAggregate;
using MediatR;

namespace API.Application.Commands.Orders.UpdateOrder
{
    public class UpdateOrderCommand : IRequest<Order>
    {
        public DateTimeOffset OrderedDate { get; private set; }

        public string OrderNo { get; set; }

        public Guid CustomerId { get; private set; }

        public Guid FlightId { get; private set; }

        public Guid Id { get; private set; }

        public List<OrderItemViewModel> OrderItems { get; set; }

        public UpdateOrderCommand(Guid id,DateTimeOffset orderedDate, string orderNo, Guid customerId, Guid flightId, List<OrderItemViewModel> orderItems)
        {
            OrderedDate = orderedDate;
            OrderNo = orderNo;
            CustomerId = customerId;
            FlightId = flightId;
            OrderItems = orderItems;
            Id = id;
        }
    }
}

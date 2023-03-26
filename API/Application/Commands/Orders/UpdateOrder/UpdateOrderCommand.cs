using API.Application.ViewModels.Orders;
using System.Collections.Generic;
using System;
using Domain.Aggregates.OrderAggregate;
using MediatR;

namespace API.Application.Commands.Orders.UpdateOrder
{
    public class UpdateOrderCommand : IRequest<OrderViewModel>
    {
        public DateTimeOffset OrderedDate { get;  set; }

        public string OrderNo { get; set; }

        public Guid CustomerId { get;  set; }

        public Guid FlightId { get;  set; }

        public Guid Id { get;  set; }

        public string Status { get; set; }

        public List<OrderItemViewModel> OrderItems { get; set; }

        public UpdateOrderCommand(Guid id,DateTimeOffset orderedDate, string orderNo, Guid customerId, Guid flightId,string status, List<OrderItemViewModel> orderItems)
        {
            OrderedDate = orderedDate;
            OrderNo = orderNo;
            CustomerId = customerId;
            FlightId = flightId;
            OrderItems = orderItems;
            Id = id;
            Status = status;
        }
    }
}

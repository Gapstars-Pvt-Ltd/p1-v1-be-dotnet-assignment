using System.Collections.Generic;
using System;
using Domain.Aggregates.OrderAggregate;
using MediatR;
using API.Application.ViewModels.Orders.Update;
using API.Application.ViewModels.Orders.View;

namespace API.Application.Commands.Orders.UpdateOrder
{
    public class UpdateOrderCommand : IRequest<OrderViewModel>
    {
        public DateTimeOffset OrderedDate { get;  set; }

       

        public Guid CustomerId { get;  set; }

        public Guid FlightId { get;  set; }

        public Guid Id { get;  set; }

        public string Status { get; set; }

        public List<UpdateOrderItemViewModel> OrderItems { get; set; }

        public UpdateOrderCommand(Guid id,DateTimeOffset orderedDate,  Guid customerId, Guid flightId,string status, List<UpdateOrderItemViewModel> orderItems)
        {
            OrderedDate = orderedDate;
           
            CustomerId = customerId;
            FlightId = flightId;
            OrderItems = orderItems;
            Id = id;
            Status = status;
        }
    }
}

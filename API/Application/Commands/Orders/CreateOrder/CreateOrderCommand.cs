using API.Application.ViewModels.Orders.Create;
using API.Application.ViewModels.Orders.View;
using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.OrderAggregate;
using MediatR;
using System;
using System.Collections.Generic;

namespace API.Application.Commands.Orders.CreateOrder
{
    public class CreateOrderCommand : IRequest<OrderViewModel>
    {


        public Guid CustomerId { get; private set; }

        public Guid FlightId { get; private set; }

        public List<CreateOrderItemViewModel> OrderItems { get; set; }

        public CreateOrderCommand( Guid customerId, Guid flightId, List<CreateOrderItemViewModel> orderItems)
        {
           
            CustomerId = customerId;
            FlightId = flightId;
            OrderItems = orderItems;
        }
    }
}

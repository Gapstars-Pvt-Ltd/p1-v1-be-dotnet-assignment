using API.Application.Commands.Airports;
using API.Application.Commands.Flights.GetFlight;
using API.Application.Commands.Orders.ConfirmOrder;
using API.Application.Commands.Orders.CreateOrder;
using API.Application.Commands.Orders.GetAllOrder;
using API.Application.Commands.Orders.GetOrder;
using API.Application.Commands.Orders.UpdateOrder;
using API.Application.ViewModels;
using API.Application.ViewModels.Customers;
using API.Application.ViewModels.Orders;
using AutoMapper;
using Domain.Aggregates.OrderAggregate;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YamlDotNet.Core;

namespace API.Controllers.V1
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<AirportsController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrdersController(ILogger<AirportsController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        //create orders 
        [HttpPost]
        public async Task<IActionResult> Order([FromBody] CreateOrderCommand command)
        {
            var order = await _mediator.Send(command);

            return CreatedAtRoute("GetOrderById", new { id = order.Id },order);
            
        }
        //get order by id and if not order is not found with give Id return not found Error 
        [HttpGet("{id:guid}",Name = "GetOrderById")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var order = await _mediator.Send(new GetOrderQuery { Id = id });

            return order != null ? Ok(order) : NotFound("Order Not Found With Given Id");
        }

        //get all orders 
        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var order = await _mediator.Send(new GetAllOrderQuery { });

            return order != null ? Ok(order) : NotFound("Order Not Found With Given Id");
        }

        //confrim order by id and if not order nor found with given id return not foun error 
        [HttpPut("{id:guid}/confirm")]
        public async Task<IActionResult> Confirm(Guid id)
        {
            var order = await _mediator.Send(new ConfirmOrderCommand { Id = id });

            return order != null ? Ok(_mapper.Map<OrderViewModel>(order)) : NotFound("Order Not Found With Given Id");
        }

        // update orders. if order status is Confrim order cannot be updated 
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateOrderCommand command)
        {
            var order = await _mediator.Send(command);

            return Ok(order);
        }
    }
}

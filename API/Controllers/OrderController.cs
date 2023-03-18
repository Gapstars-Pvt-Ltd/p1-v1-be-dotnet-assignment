using System;
using System.Net;
using System.Threading.Tasks;
using API.Application.Commands;
using API.Application.Commands.UpdateOrder;
using API.Application.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers;

public class OrderController : BaseController
{
    private readonly ILogger<OrderController> _logger;
    private readonly CreateOrderCommand _createOrderCommand;
    private readonly UpdateOrderStatusCommand _updateOrderStatusCommand;

    public OrderController(ILogger<OrderController> logger, CreateOrderCommand createOrderCommand, UpdateOrderStatusCommand updateOrderStatusCommand)
    {
        _logger = logger;
        _createOrderCommand = createOrderCommand;
        _updateOrderStatusCommand = updateOrderStatusCommand;
    }
    
    [HttpPost]
    [Route("/Bookings")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> BookAFlight (OrderDto order)
    {
        _createOrderCommand.OrderDto = new OrderDto
        {
            PassengerInfo = order.PassengerInfo, 
            OrderItems = order.OrderItems
        };
        
        return Ok(await Mediator.Send(_createOrderCommand));
    }

    [HttpPut]
    [Route("/Confirm")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> ConfirmBooking(ConfirmDto confirmDto)
    {

        _updateOrderStatusCommand.ConfirmBooking = confirmDto;

        return Ok(await Mediator.Send(_updateOrderStatusCommand));
    }
}
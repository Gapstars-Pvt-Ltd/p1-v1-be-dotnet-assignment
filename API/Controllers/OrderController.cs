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

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<OrderController> _logger;
    private readonly CreateOrderCommand _createOrderCommand;
    private readonly UpdateOrderStatusCommand _updateOrderStatusCommand;

    public OrderController(ILogger<OrderController> logger, CreateOrderCommand createOrderCommand, UpdateOrderStatusCommand updateOrderStatusCommand, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
        _createOrderCommand = createOrderCommand;
        _updateOrderStatusCommand = updateOrderStatusCommand;
    }
    
    [HttpPost]
    [Route("Flight/Booking")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> BookAFlight (OrderDto order)
    {
        _createOrderCommand.OrderDto = new OrderDto
        {
            PassengerInfo = order.PassengerInfo, 
            OrderItems = order.OrderItems
        };
        
        return Ok(await _mediator.Send(_createOrderCommand));
    }

    [HttpPut]
    [Route("Flight/Booking/Confirm")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> ConfirmBooking(ConfirmDto confirmDto)
    {

        _updateOrderStatusCommand.ConfirmBooking = confirmDto;

        return Ok(await _mediator.Send(_createOrderCommand));
    }
}
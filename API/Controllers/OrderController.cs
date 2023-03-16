using System;
using System.Threading.Tasks;
using API.Application.Commands;
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
    private readonly CreateOrderCommand _command;

    public OrderController(ILogger<OrderController> logger, CreateOrderCommand command, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
        _command = command;
    }
    
    [HttpPost]
    [Route("Booking")]
    public async Task<IActionResult> BookAFlight (OrderDto order)
    {
        _command.OrderDto = new OrderDto
        {
            PassengerInfo = order.PassengerInfo, 
            OrderItems = order.OrderItems
        };
        
        return Ok(await _mediator.Send(_command));
    }
}
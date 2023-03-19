using API.Application.Commands.Airports;
using API.Application.Commands.Flights.GetFlight;
using API.Application.Commands.Orders.CreateOrder;
using API.Application.Commands.Orders.GetOrder;
using API.Application.ViewModels;
using API.Application.ViewModels.Orders;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<AirportsController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrderController(ILogger<AirportsController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Order([FromBody] CreateOrderCommand command)
        {
            var order = await _mediator.Send(command);

            return Ok(_mapper.Map<OrderViewModel>(order));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var order = await _mediator.Send(new GetOrderQuery { Id = id });
           
            return order != null ? Ok(order) : NotFound("Order Not Found With Given Id");
        }
    }
}

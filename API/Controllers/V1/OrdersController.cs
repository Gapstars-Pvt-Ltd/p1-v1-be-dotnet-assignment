using API.Application.Commands.Airports;
using API.Application.Commands.Flights.GetFlight;
using API.Application.Commands.Orders.ConfirmOrder;
using API.Application.Commands.Orders.CreateOrder;
using API.Application.Commands.Orders.GetAllOrder;
using API.Application.Commands.Orders.GetOrder;
using API.Application.Commands.Orders.UpdateOrder;
using API.Application.ViewModels;
using API.Application.ViewModels.Orders;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

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

            return order != null ? Ok(_mapper.Map<OrderViewModel>(order)) : NotFound("Order Not Found With Given Id");
        }


        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var order = await _mediator.Send(new GetAllOrderQuery { });

            return order != null ? Ok(order) : NotFound("Order Not Found With Given Id");
        }


        [HttpPut("{id:guid}/confirm")]
        public async Task<IActionResult> Confirm(Guid id)
        {
            var order = await _mediator.Send(new ConfirmOrderCommand { Id = id });

            return order != null ? Ok(_mapper.Map<OrderViewModel>(order)) : NotFound("Order Not Found With Given Id");
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateOrderCommand command)
        {
            var order = await _mediator.Send(command);

            return Ok(order);
        }
    }
}

using System.Threading.Tasks;
using Application.Commands;
using Application.ViewModels;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrderController(
            ILogger<OrderController> logger,
            IMediator mediator,
            IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }
        
        [HttpPost]
        public async Task<IActionResult> Store([FromBody]CreateOrderCommand command)
        {
            var order = await _mediator.Send(command);

            return Created("~/api/Order", order);
        }

        [HttpPut]
        public async Task<IActionResult> Confirm([FromBody] UpdateOrderCommand command)
        {
            var airport = await _mediator.Send(command);

            return Ok(_mapper.Map<OrderViewModel>(airport));
        }
    }
}
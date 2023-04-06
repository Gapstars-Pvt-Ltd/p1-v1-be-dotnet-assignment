using System.Threading.Tasks;
using API.Application.Commands.Airports;
using API.Application.ViewModels;
using API.Contracts;
using API.Contracts.V1;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace API.Controllers.V1
{
    [ApiController]

    public class AirportsController : ControllerBase
    {
        private readonly ILogger<AirportsController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AirportsController(
            ILogger<AirportsController> logger,
            IMediator mediator,
            IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost(ApiRoutes.Airport.Create)]
        public async Task<IActionResult> Store([FromBody] CreateAirportCommand command)
        {
            var airport = await _mediator.Send(command);

            return Ok(_mapper.Map<AirportViewModel>(airport));
        }

    }
}
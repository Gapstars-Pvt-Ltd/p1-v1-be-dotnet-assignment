using System.Threading.Tasks;
using API.Application.Commands;
using API.Application.ViewModels;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    public class AirportsController : BaseController
    {
        private readonly ILogger<AirportsController> _logger;
        private readonly IMapper _mapper;

        public AirportsController(
            ILogger<AirportsController> logger,
            IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }
        
        [HttpPost]
        public async Task<IActionResult> Store([FromBody]CreateAirportCommand command)
        {
            var airport = await Mediator.Send(command);

            return Ok(_mapper.Map<AirportViewModel>(airport));
        }
    }
}
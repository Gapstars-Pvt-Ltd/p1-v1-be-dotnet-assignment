using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.ApiResponses;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using API.Application.Queries;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class FlightsController : ControllerBase
{
    private readonly ILogger<AirportsController> _logger;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public FlightsController(
            ILogger<AirportsController> logger,
            IMediator mediator,
            IMapper mapper)
    {
        _logger = logger;
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("Search")]
    public async Task<ActionResult<IEnumerable<FlightResponse>>> GetAvailableFlights() //Guid destinationAirportId
    {

        Guid id = Guid.NewGuid();

        GetAvailableFlightsQuery query = new GetAvailableFlightsQuery(id);
        var flightsToDestination = await _mediator.Send(query);
        return Ok(flightsToDestination);
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.ApiResponses;
using API.Application.Commands.Flights.GetAllFlights;
using API.Application.Commands.Flights.GetAvailableFlights;
using API.Application.Commands.Flights.GetFlight;
using API.Application.ViewModels.Flights;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class FlightsController : ControllerBase
{
    private readonly ILogger<AirportsController> _logger;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public FlightsController(ILogger<AirportsController> logger, IMediator mediator, IMapper mapper)
    {
        _logger = logger;
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetFlights()
    {
        var flights = await _mediator.Send(new GetALlAirportQuery { });

        return Ok(flights);
    }

    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var flight = await _mediator.Send(new GetFlightQuery { Id = id });

        return Ok(flight);
    }

    [HttpGet]
    [Route("Search")]
    public async Task<IActionResult> GetAvailableFlights(string AirPortCode)
    {
        var flights = await _mediator.Send(new GetAvailableFlightsQuery { AirPortCode = AirPortCode });

        return Ok(flights);
    }

}

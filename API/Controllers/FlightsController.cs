using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.ApiResponses;
using Application.Query;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
    public async Task<IActionResult> GetAvailableFlights(string AirPortCode)
    {
        var flights = await _mediator.Send(new GetAvailableFlightsQuery { AirPortCode = AirPortCode});

        return Ok(flights);
    }
}

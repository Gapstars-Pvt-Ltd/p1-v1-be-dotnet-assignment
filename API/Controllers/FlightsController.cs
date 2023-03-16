using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using API.ApiResponses;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.Extensions.Logging;
using API.Application.Query;
using API.Application.ViewModels;

namespace API.Controllers;

public class FlightsController : BaseController
{
    private readonly ILogger<FlightsController> _logger;
    private readonly FlightSearchQuery _flightSearchQuery;

    public FlightsController(ILogger<FlightsController> logger, FlightSearchQuery flightSearchQuery)
    {
        _logger = logger;
        _flightSearchQuery = flightSearchQuery;
    }

    [HttpGet]
    [Route("/Search")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAvailableFlights([FromQuery]Guid arrivingAirport)
    {
        _flightSearchQuery.DestinationAirPortId = Guid.Parse(Request.Query["arrivingAirport"].ToString());
        return Ok(await Mediator.Send(_flightSearchQuery));
    }
}
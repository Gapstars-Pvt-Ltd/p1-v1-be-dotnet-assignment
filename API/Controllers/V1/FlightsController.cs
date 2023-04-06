using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.ApiResponses;
using API.Application.Commands.Flights.GetAllFlights;
using API.Application.Commands.Flights.GetAvailableFlights;
using API.Application.Commands.Flights.GetFlight;
using API.Application.ViewModels.Flights;
using API.Application.ViewModels.Orders;
using API.Contracts;
using API.Contracts.V1;
using AutoMapper;
using Domain.Aggregates.FlightAggregate;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers.V1;

[ApiController]

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

    [HttpGet(ApiRoutes.Flight.GetAll)]

    public async Task<IActionResult> GetFlights()
    {
        var flights = await _mediator.Send(new GetALlAirportQuery { });

        return Ok(_mapper.Map<List<Flight>,List<FlightViewModel>>(flights));
    }

    //get flights by its Id and if not found return notfound error 
    [HttpGet(ApiRoutes.Flight.Get)]
    public async Task<IActionResult> Get(Guid id)
    {
        var flight = await _mediator.Send(new GetFlightQuery { Id = id });

        return flight != null ? Ok(_mapper.Map<FlightViewModel>(flight)) : NotFound("Flight Not Found With Given Id");
    }

    //search flight by given airport code 
    [HttpGet(ApiRoutes.Flight.Search)]
    public async Task<IActionResult> GetAvailableFlights(string AirPortCode)
    {
        var flights = await _mediator.Send(new GetAvailableFlightsQuery { AirPortCode = AirPortCode });

        return Ok(_mapper.Map<List<AvailableFlightsDomainViewModel>, List<AvailableFlightsViewModel>>(flights));
    }

}

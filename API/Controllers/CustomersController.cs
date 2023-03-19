using API.Application.Commands.Airports;
using API.Application.Commands.Customers.CreateCustomer;
using API.Application.Commands.Customers.GetCustomer;
using API.Application.Commands.Customers.GetCustomers;
using API.Application.Commands.Flights.GetAllFlights;
using API.Application.ViewModels;
using API.Application.ViewModels.Customers;
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
    public class CustomersController  : ControllerBase
    {


        private readonly ILogger<CustomersController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CustomersController(ILogger<CustomersController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomerCommand command)
        {
            var customer = await _mediator.Send(command);

            return Ok(_mapper.Map<CustomerViewModel>(customer));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _mediator.Send(new GetAllCustomersQuery { });

            return Ok(customers);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetCutomerById(Guid id)
        {
            var customer = await _mediator.Send(new GetCustomerQuery { Id = id });

            return customer != null
                ? Ok(customer)
                : NotFound(new { error = "Customer not found with given Id" });
        }
    }
}

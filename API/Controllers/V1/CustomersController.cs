using API.Application.Commands.Airports;
using API.Application.Commands.Customers.CreateCustomer;
using API.Application.Commands.Customers.GetCustomer;
using API.Application.Commands.Customers.GetCustomers;
using API.Application.Commands.Customers.GetOrders;
using API.Application.Commands.Flights.GetAllFlights;
using API.Application.Commands.Orders.ConfirmOrder;
using API.Application.ViewModels;
using API.Application.ViewModels.Customers;
using API.Application.ViewModels.Orders;
using API.Contracts;
using API.Contracts.V1;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace API.Controllers.V1
{
    [ApiController]

    public class CustomersController : ControllerBase
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

        // This action method handles the HTTP POST request to create a new customer.
        [HttpPost(ApiRoutes.Customer.Create)]
        public async Task<IActionResult> Create([FromBody] CreateCustomerCommand command)
        {
            var customer = await _mediator.Send(command);

            // Returns a response indicating that the resource was created successfully.
            return CreatedAtRoute("GetCustomerById", new { id = customer.Id }, _mapper.Map<CustomerViewModel>(customer));

        }


        // This action method handles the HTTP GET request to retrieve all customers.
        [HttpGet(ApiRoutes.Customer.GetAll)]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _mediator.Send(new GetAllCustomersQuery { });

            return Ok(customers);
        }

        // This action method handles the HTTP GET request to retrieve a customer by Id.
        [HttpGet(ApiRoutes.Customer.Get, Name = "GetCustomerById")]
        public async Task<IActionResult> GetCustomerById(Guid id)
        {
            var customer = await _mediator.Send(new GetCustomerQuery { Id = id });

            // Returns a response with the requested customer as the content, or a "not found" error if the customer does not exist.
            return customer != null
                ? Ok(customer)
                : NotFound(new { error = "Customer not found with given Id" });
        }

        // This action method handles the HTTP GET request to retrieve all orders for a specific customer.
        [HttpGet(ApiRoutes.Customer.GetOrderByCustomer)]
        public async Task<IActionResult> Orders(Guid id)
        {
            var order = await _mediator.Send(new GetOrdersByCutomerQuery { CustomerId = id });

            // Returns a response with all orders for the given customer as the content, or a "not found" error if no orders exist.
            return order != null ? Ok(order) : NotFound("Order Not Found With Given Id");
        }
    }
}

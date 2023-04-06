using Domain.Aggregates.CustomerAggregate;
using Domain.Aggregates.FlightAggregate;
using MediatR;
using System;

namespace API.Application.Commands.Customers.GetCustomer
{
    public class GetCustomerQuery : IRequest<Customer>
    {
        public Guid  Id { get; set; }
    }
}

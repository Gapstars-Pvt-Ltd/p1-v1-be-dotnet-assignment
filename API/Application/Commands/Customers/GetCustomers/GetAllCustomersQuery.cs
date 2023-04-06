using Domain.Aggregates.CustomerAggregate;
using MediatR;
using System.Collections.Generic;

namespace API.Application.Commands.Customers.GetCustomers
{
    public class GetAllCustomersQuery : IRequest<List<Customer>>
    {

    }
}

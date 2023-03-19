using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.CustomerAggregate;
using MediatR;

namespace API.Application.Commands.Customers.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<Customer>
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public CreateCustomerCommand(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}

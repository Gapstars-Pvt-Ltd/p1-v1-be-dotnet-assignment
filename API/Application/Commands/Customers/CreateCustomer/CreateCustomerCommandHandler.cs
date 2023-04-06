using API.Application.Commands.Airports;
using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.CustomerAggregate;
using Infrastructure.Repositores;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Commands.Customers.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Customer>
    {
        private readonly ICustomerRepository _CustomerRepository;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _CustomerRepository = customerRepository;
        }

        public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer= _CustomerRepository.Add(new Customer(request.Name, request.Email));

            await _CustomerRepository.UnitOfWork.SaveEntitiesAsync();

            return customer;
        }
    }
}

using API.Application.Commands.Flights.GetFlight;
using Domain.Aggregates.CustomerAggregate;
using Domain.Aggregates.FlightAggregate;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Commands.Customers.GetCustomer
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, Customer>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
         return  await _customerRepository.GetAsync(request.Id);
        }
    }
}

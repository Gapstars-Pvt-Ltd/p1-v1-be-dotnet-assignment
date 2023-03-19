using Domain.Abstraction;
using Domain.Aggregates.AirportAggregate;
using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.CustomerAggregate
{
    public interface ICustomerRepository : IRepository<Customer>, ITransientService
    {

        Customer Add(Customer customer);

        void Update(Customer customer);

        Task<Customer> GetAsync(Guid customerId);

        Task<List<Customer>> GetAllAsync();
    }
}

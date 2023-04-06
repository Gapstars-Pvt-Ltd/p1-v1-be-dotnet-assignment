using Domain.Aggregates.CustomerAggregate;
using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositores
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly FlightsContext _context;

        public CustomerRepository(FlightsContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        //add new customer to the context
        public Customer Add(Customer customer)
        {
            return _context.Customers.Add(customer).Entity;
        }


        //get all cutomers 
        public async Task<List<Customer>> GetAllAsync()
        {
            return await  _context.Customers.ToListAsync();
        }

        //get customer by id 
        public async Task<Customer> GetAsync(Guid customerId)
        {
            return await _context.Customers.Where(x => x.Id == customerId).SingleOrDefaultAsync();
        }
        //update customer 
        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}

using Domain.Exceptions;
using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.CustomerAggregate
{
    public class Customer : Entity, IAggregateRoot
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public Customer()
        {

        }

        public Customer(string name, string email):this()
        {
            if (email == null)
            {
                throw new AirportDomainException("The Email Cannot be null or Empty");
            }
            Name = name;
            Email = email;
        }
    }
}

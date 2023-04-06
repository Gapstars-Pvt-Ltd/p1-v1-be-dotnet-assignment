using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class CustomerDomainException : Exception
    {
        public CustomerDomainException()
        {
        }

        public CustomerDomainException(string message) : base(message)
        {
        }

        public CustomerDomainException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

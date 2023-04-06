using System;

namespace API.Application.ViewModels.Customers
{
    public class CustomerViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
    }
}

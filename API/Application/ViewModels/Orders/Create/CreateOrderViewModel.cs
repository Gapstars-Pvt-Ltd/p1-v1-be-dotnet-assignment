using API.Application.ViewModels.Orders.View;
using System;
using System.Collections.Generic;

namespace API.Application.ViewModels.Orders.Create
{
    public class CreateOrderViewModel
    {
        public Guid Id { get; set; }
      
        public Guid CustomerId { get; set; }

        public Guid FlightId { get; set; }

        public List<CreateOrderItemViewModel> OrderItems { get; set; }
    }
}

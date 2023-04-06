using System.Collections.Generic;
using System;

namespace API.Application.ViewModels.Orders.Update
{
    public class UpdateOrderViewModel
    {
        public Guid Id { get; set; }
        public DateTimeOffset OrderedDate { get; set; }

        public Guid CustomerId { get; set; }

        public Guid FlightId { get; set; }

        public string Status { get; set; }

        public List<UpdateOrderItemViewModel> OrderItems { get; set; }
    }
}

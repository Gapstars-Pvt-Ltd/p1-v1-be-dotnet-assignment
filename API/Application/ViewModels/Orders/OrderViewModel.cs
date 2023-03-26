using Domain.Aggregates.OrderAggregate;
using System.Collections.Generic;
using System;

namespace API.Application.ViewModels.Orders
{
    public class OrderViewModel
    {
        public Guid Id { get;  set; }
        public DateTimeOffset OrderedDate { get; set; }

        public string OrderNo { get; set; }

        public Guid CustomerId { get;  set; }

        public Guid FlightId { get;  set; }

        public string Status { get; set; }

        public double Total { get; set; }

        public List<OrderItemViewModel> OrderItems { get; set; }
    }
}

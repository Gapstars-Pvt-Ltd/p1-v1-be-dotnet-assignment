using Domain.Aggregates.OrderAggregate;
using System.Collections.Generic;
using System;

namespace API.Application.ViewModels.Orders
{
    public class OrderViewModel
    {
        public Guid Id { get; private set; }
        public DateTimeOffset OrderedDate { get; private set; }

        public string OrderNo { get; set; }

        public Guid CustomerId { get; private set; }

        public Guid FlightId { get; private set; }

        public string Status { get; set; }

        public double Total { get; set; }

        public List<OrderItemViewModel> OrderItems { get; set; }
    }
}

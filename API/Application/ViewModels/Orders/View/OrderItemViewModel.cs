using System;

namespace API.Application.ViewModels.Orders.View
{
    public class OrderItemViewModel
    {
        public Guid Id { get; set; }
        public Guid FlightRateId { get; set; }
        public double Price { get; set; }

        public int Qty { get; set; }
    }
}

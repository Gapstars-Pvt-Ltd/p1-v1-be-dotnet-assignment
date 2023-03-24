using System;

namespace API.Application.ViewModels.Orders
{
    public class OrderItemViewModel
    {
        public Guid FlightRateId { get; set; }
        public double Price { get; set; }

        public int Qty { get; set; }
    }
}

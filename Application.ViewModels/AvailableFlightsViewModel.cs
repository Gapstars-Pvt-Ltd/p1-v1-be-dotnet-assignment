using System;

namespace Application.ViewModels
{
    public class AvailableFlightsViewModel
    {
       public string DepartureAirportCode { get; set; }
        public string ArrivalAirportCode { get; set; }
        public DateTimeOffset DepartureDateTime { get; set; }
        public DateTimeOffset ArrivalDateTime { get; set; }
        public decimal LowestPrice { get; set; }
    }
}

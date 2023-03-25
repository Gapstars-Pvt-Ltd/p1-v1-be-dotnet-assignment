using System;

namespace API.Application.ViewModels.Flights
{
    public class AvailableFlightsViewModel
    {
        public Guid Id { get; set; }
        public string DepartureAirportCode { get; set; }
        public string ArrivalAirportCode { get; set; }
        public DateTimeOffset Departure { get; set; }
        public DateTimeOffset Arrival { get; set; }
        public decimal LowestPrice { get; set; }
    }
}

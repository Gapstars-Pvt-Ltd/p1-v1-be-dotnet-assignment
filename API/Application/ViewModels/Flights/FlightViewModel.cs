using Domain.Aggregates.FlightAggregate;
using System.Collections.Generic;
using System;

namespace API.Application.ViewModels.Flights
{
    public class FlightViewModel
    {
        public Guid Id { get; set; }
        public Guid OriginAirportId { get; private set; }
        public Guid DestinationAirportId { get; private set; }

        public DateTimeOffset Departure { get; private set; }
        public DateTimeOffset Arrival { get; private set; }

        public List<FlightRateViewModel> Rates { get; set; }
    }
}

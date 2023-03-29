using Domain.Common;
using System;

namespace API.Application.ViewModels.Flights
{
    public class FlightRateViewModel
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Price Price { get; private set; }
        public int Available { get; private set; }
    }
}

using Domain.Common;

namespace API.Application.ViewModels.Flights
{
    public class FlightRateViewModel
    {
        public string Name { get; private set; }
        public Price Price { get; private set; }
        public int Available { get; private set; }
    }
}

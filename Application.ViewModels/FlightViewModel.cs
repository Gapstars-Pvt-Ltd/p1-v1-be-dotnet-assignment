using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class FlightViewModel
    {
        public Guid OriginAirportId { get; private set; }
        public Guid DestinationAirportId { get; private set; }
        public DateTimeOffset Departure { get; private set; }
        public DateTimeOffset Arrival { get; private set; }
    }
}

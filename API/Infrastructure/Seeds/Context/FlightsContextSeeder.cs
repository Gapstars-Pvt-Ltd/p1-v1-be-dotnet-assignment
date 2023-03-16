using System;
using Infrastructure;

namespace API.Infrastructure.Seeds.Context
{
    public abstract class FlightsContextSeeder : ISeeder
    {
        public FlightsContextSeeder(FlightsContext flightsContext)
        {   
            FlightsContext = flightsContext;
        }

        protected FlightsContext FlightsContext { get; }

        public abstract void Seed();
    }
}
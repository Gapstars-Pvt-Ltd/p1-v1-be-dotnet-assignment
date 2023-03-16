using System;
using System.Collections.Generic;
using System.Linq;
using API.Infrastructure.Seeds.Context;
using Domain.Aggregates.PassengerAggregate;
using Infrastructure;

namespace API.Infrastructure.Seeds;

public class PassengerSeeder : PassengerContextSeeder
{
    public PassengerSeeder(FlightsContext passengerContext) : base(passengerContext)
    {
    }

    public override void Seed()
    {
        if (PassengerContext.Passengers.Any())
        {
            Console.WriteLine("Skipping Passenger seeder because table is not empty.");
            return;
        };
        
        // Seed the database with 100 passengers
    }
}
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

        List<Passenger> passengers = new List<Passenger>
        {
            new Passenger("John", "Doe", 25, "johndoe@gmail.com"),
            new Passenger("Jane", "Doe", 35, "janedoe@gmail.com"),
            new Passenger("Jonny", "Doe", 18, "jonny@gmail.com"),
            new Passenger("Alan", "Sams", 23, "alansams@gmail.com")
        };

        PassengerContext.AddRange(passengers);

        PassengerContext.SaveChanges();
    }
}
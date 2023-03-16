using Infrastructure;

namespace API.Infrastructure.Seeds.Context;

public abstract class PassengerContextSeeder : ISeeder
{
    public PassengerContextSeeder(FlightsContext passengerContext)
    {
        PassengerContext = passengerContext;
    }
    
    protected FlightsContext PassengerContext { get; }
    
    public abstract void Seed();
}
using Domain.SeedWork;

namespace Domain.Aggregates.PassangerAggregate
{
    public class Passenger : Entity
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Email { get; private set; }
        
        public string Street { get; private set; }

        public string City { get; private set; }

        public string State { get; private set; }

        public string Country { get; private set; }

        public string ZipCode { get; private set; }

        public Passenger() { }

        public Passenger(string name, int age, string email, string street, string city, string state, string country, string zipCode)
        {
            Name = name;
            Age = age;
            Email = email;
            Street = street;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
        }
        
        public void UpdatePassenger(string name, int age, string email, string street, string city, string state, string country, string zipCode)
        {
            Name = name;
            Age = age;
            Email = email;
            Street = street;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
            
            // Implement Domain events here
        }
    }
}

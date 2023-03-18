using System;
using Domain.Events;
using Domain.SeedWork;

namespace Domain.Aggregates.PassengerAggregate;

public interface IPassengerRepository : IRepository<Passenger>
{
    Passenger GetById(Guid id);
    Passenger GetByEmail(string email);
    Passenger Add(Passenger passenger);
    void Update(Passenger passenger);
}
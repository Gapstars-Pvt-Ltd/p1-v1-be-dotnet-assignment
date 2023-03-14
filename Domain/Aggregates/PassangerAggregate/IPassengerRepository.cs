using System;

namespace Domain.Aggregates.PassangerAggregate;

public interface IPassengerRepository
{
    Passenger GetById(Guid id);
    void Add(Passenger passenger);
    void Update(Passenger passenger);
}
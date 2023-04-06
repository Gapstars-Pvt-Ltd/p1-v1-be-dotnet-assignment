using System;
using System.Threading.Tasks;
using Domain.Abstraction;
using Domain.SeedWork;

namespace Domain.Aggregates.AirportAggregate
{
    public interface IAirportRepository : IRepository<Airport>, ITransientService
    {
        Airport Add(Airport airport);

        void Update(Airport airport);

        Task<Airport> GetAsync(Guid airportId);
    }
}
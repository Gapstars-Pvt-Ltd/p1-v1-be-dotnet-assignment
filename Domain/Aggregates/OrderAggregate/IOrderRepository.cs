using System;
using System.Threading.Tasks;
using Domain.Aggregates.FlightAggregate;
using Domain.SeedWork;

namespace Domain.Aggregates.OrderAggregate
{
    public interface IOrderRepository : IRepository<Order>
    {
        Order Add(Order order);

        void Update(Order order);
        void UpdateFlightRate(FlightRate flightRate);
        Task<Order> GetAsync(Guid OrderId);

        Task<FlightRate> GetFlightByIdAsync(Guid flightRateId);
    }
}
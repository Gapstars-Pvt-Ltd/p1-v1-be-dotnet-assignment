using Domain.Abstraction;
using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.FlightAggregate;
using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.OrderAggregate
{
    public interface IOrderRepository : IRepository<Order>, ITransientService
    {
        Order Add(Order order);

        void Update(Order order);

        Task<Order> ConfirmAsync(Guid orderId);

        Task<Order> GetAsync(Guid orderId);
    }
}

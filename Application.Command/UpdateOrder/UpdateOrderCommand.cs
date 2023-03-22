

using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.OrderAggregate;
using MediatR;

namespace Application.Commands
{
    public class UpdateOrderCommand : IRequest<Order>
    {
        public UpdateOrderCommand(Guid orderId)
        {

            this.orderId = orderId;
        }

        public Guid orderId { get; private set; }

    }
}
using Domain.Aggregates.AirportAggregate;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Domain.Aggregates.OrderAggregate;

namespace API.Application.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Order>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _orderRepository.Add(
                new Order(request.FlightId, request.FlightRateId, request.CustomerId, request.SeatCount));

            await _orderRepository.UnitOfWork.SaveEntitiesAsync();

            return order;
        }
    }
}

using System.Threading;
using System.Threading.Tasks;
using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate;
using MediatR;

namespace Application.Commands
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
            // Check the flightRateId is Valid.
            var flightRate = await _orderRepository.GetFlightByIdAsync(request.FlightRateId);
            if (flightRate == null)
            {
                throw new Exception("Invalid FlightRateId.Get a valid FlightRateId from the FlightRate table");
            }
            // Create a new Order object using the request data.
            var order = _orderRepository.Add(new Order(request.FlightRateId,request.Name,request.Quantity,0,DateTimeOffset.Now,DateTimeOffset.Now));
            // Save the changes to the repository.
            await _orderRepository.UnitOfWork.SaveEntitiesAsync();
            
            return order;
        }
    }
}
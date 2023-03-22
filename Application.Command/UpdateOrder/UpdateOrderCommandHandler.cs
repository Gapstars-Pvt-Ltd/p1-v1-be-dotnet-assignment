using System.Threading;
using System.Threading.Tasks;
using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.OrderAggregate;
using MediatR;

namespace Application.Commands
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Order>
    {
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository) 
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            // Get the Order object to be updated from the repository.
            var order = await _orderRepository.GetAsync(request.orderId);
            // Check the OrderId is Valid.
            if (order == null) {
                throw new Exception("Invalid OrderId. Please get a valid OrderId from Order table.");
            }
            // Get the available flightRate from FlightRate table
            var flightRate = await _orderRepository.GetFlightByIdAsync(order.FlightRateId);
            // Check if the requested quantity is greater than the available quantity.
            if (order.Quantity > flightRate.Available)
            {
                throw new Exception($"You have requested ({order.Quantity}). But only ({flightRate.Available}) seats available.We can't proceed the order.");
            }
            // Check if the order has already been confirmed.
            if (order.isConfirmed) {
                throw new Exception("Order is already confirmed.");
            }else
            {
                order.OrderConfirmedDate= DateTime.UtcNow;
                order.isConfirmed = true;
                order.Price = flightRate.Price.Value * order.Quantity;           }
            _orderRepository.Update(order);

            // Update the available quantity in the FlightRate table in the repository.      
            flightRate.Available = flightRate.Available - order.Quantity;
            _orderRepository.UpdateFlightRate(flightRate);

            await _orderRepository.UnitOfWork.SaveEntitiesAsync();
            Console.WriteLine("Order has been confirmed.");
            return order;
        }
    }
}
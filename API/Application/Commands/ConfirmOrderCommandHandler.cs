using Domain.Aggregates.AirportAggregate;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Domain.Aggregates.OrderAggregate;
using Domain.Aggregates.FlightAggregate;

namespace API.Application.Commands
{
    public class ConfirmOrderCommandHandler : IRequestHandler<ConfirmOrderCommand, Order>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IFlightRepository _flightRepository;

        public ConfirmOrderCommandHandler(IOrderRepository orderRepository, IFlightRepository flightRepository)
        {
            _orderRepository = orderRepository;
            _flightRepository = flightRepository;
        }

        public async Task<Order> Handle(ConfirmOrderCommand request, CancellationToken cancellationToken)
        {
            Order orderToConfirm = await _orderRepository.GetAsync(request.OrderId);
            orderToConfirm.ConfirmOrder();

            _orderRepository.Update(orderToConfirm);

            Flight flight = await _flightRepository.GetAsync(orderToConfirm.FlightId);



            flight.MutateRateAvailability(orderToConfirm.FlightRateId, orderToConfirm.SeatCount);

            _flightRepository.Update(flight); 

            await _orderRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return orderToConfirm;
        }
    }
}

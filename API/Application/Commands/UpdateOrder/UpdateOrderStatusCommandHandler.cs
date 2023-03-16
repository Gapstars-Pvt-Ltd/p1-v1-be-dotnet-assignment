using Domain.Aggregates.OrderAggregate;
using Domain.Aggregates.PassengerAggregate;
using Domain.Common;
using FluentValidation.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Commands.UpdateOrder
{
    public class UpdateOrderStatusCommandHandler : IRequestHandler<UpdateOrderStatusCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderStatusCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Unit> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var booking = _orderRepository.GetOrderByOrderIdAndCustomerId(request.ConfirmBooking.OrderId, request.ConfirmBooking.CustomerId).Result;

            if (booking != null)
            {
                booking.Status = OrderStatus.Placed.ToString();

                _orderRepository.Update(booking);

                await _orderRepository.UnitOfWork.SaveChangesAsync();
            }

            return Unit.Value;
        }
    }
}

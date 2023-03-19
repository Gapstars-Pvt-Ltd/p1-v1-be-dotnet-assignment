using Domain.Aggregates.OrderAggregate;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Commands.Orders.ConfirmOrder
{
    public class ConfirmOrderCommandHandler : IRequestHandler<ConfirmOrderCommand, Order>
    {
        private readonly IOrderRepository _orderRepository;

        public ConfirmOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> Handle(ConfirmOrderCommand request, CancellationToken cancellationToken)
        {
          return await  _orderRepository.ConfirmAsync(request.Id);
        }

       
    }
}

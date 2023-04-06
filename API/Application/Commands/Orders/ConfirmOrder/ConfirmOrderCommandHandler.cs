using API.Application.ViewModels.Orders.View;
using AutoMapper;
using Domain.Aggregates.OrderAggregate;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Commands.Orders.ConfirmOrder
{
    public class ConfirmOrderCommandHandler : IRequestHandler<ConfirmOrderCommand, OrderViewModel>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public ConfirmOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderViewModel> Handle(ConfirmOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetAsync(request.Id);
           await _orderRepository.ConfirmAsync(request.Id);

            if (order != null)
            {
                var orderViewModel = _mapper.Map<OrderViewModel>(order);
                orderViewModel.Total = order.Items.Sum(x => x.Qty * x.Price);
                return orderViewModel;
            }

            return null;
        }

       
    }
}

using API.Application.Commands.Orders.GetOrder;
using API.Application.ViewModels.Orders;
using AutoMapper;
using Domain.Aggregates.OrderAggregate;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Commands.Orders.GetAllOrder
{
    public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQuery, List<OrderViewModel>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetAllOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<List<OrderViewModel>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAllAsync();

            var result = orders.Select(order =>
            {
                var orderViewModelItem = _mapper.Map<OrderViewModel>(order);
                orderViewModelItem.Total = orderViewModelItem.OrderItems.Sum(x => x.Qty * x.Price);
                return orderViewModelItem;
            }).ToList();

            return result;
        }
    }
}

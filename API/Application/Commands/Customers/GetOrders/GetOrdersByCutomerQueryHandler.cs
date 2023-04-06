using API.Application.Commands.Orders.GetAllOrder;
using API.Application.ViewModels.Orders.View;
using AutoMapper;
using Domain.Aggregates.OrderAggregate;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Commands.Customers.GetOrders
{
    public class GetOrdersByCutomerQueryHandler : IRequestHandler<GetOrdersByCutomerQuery, List<OrderViewModel>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrdersByCutomerQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<List<OrderViewModel>> Handle(GetOrdersByCutomerQuery request, CancellationToken cancellationToken)
        {
            var orders =  await  _orderRepository.GetAllAsyncByCustomer(request.CustomerId);
            var OrderViewModel =   _mapper.Map<List<Order>, List<OrderViewModel>>(orders);

            foreach(var order in OrderViewModel)
            {
                order.Total = order.OrderItems.Sum(x=>x.Price * x.Qty);
            }
           
            return OrderViewModel;
          
        }
    }
}

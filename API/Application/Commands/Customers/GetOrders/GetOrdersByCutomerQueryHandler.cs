using API.Application.Commands.Orders.GetAllOrder;
using Domain.Aggregates.OrderAggregate;
using MediatR;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Commands.Customers.GetOrders
{
    public class GetOrdersByCutomerQueryHandler : IRequestHandler<GetOrdersByCutomerQuery, List<Order>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrdersByCutomerQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<Order>> Handle(GetOrdersByCutomerQuery request, CancellationToken cancellationToken)
        {
          return await  _orderRepository.GetAllAsyncByCustomer(request.CustomerId);
        }
    }
}

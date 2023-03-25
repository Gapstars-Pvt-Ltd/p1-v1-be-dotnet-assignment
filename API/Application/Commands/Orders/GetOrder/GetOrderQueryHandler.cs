using API.Application.Commands.Flights.GetFlight;
using API.Application.ViewModels.Orders;
using AutoMapper;
using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Commands.Orders.GetOrder
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, OrderViewModel>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderViewModel> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetAsync(request.Id);

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

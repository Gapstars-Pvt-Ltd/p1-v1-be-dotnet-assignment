using API.Application.Commands.Airports;
using API.Application.ViewModels.Orders.View;
using AutoMapper;
using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.OrderAggregate;
using Infrastructure.Repositores;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Commands.Orders.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderViewModel>
    {

        private readonly IOrderRepository _OrderReposioty;
        private readonly IMapper _mapper;


        public CreateOrderCommandHandler(IOrderRepository orderReposioty, IMapper mapper)
        {
            _OrderReposioty = orderReposioty;
            _mapper = mapper;
        }

        public async Task<OrderViewModel> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var items = request.OrderItems.Select(item => new OrderItem
            {
                FlightRateId = item.FlightRateId,
                Qty = item.Qty
            }).ToList();

            var order = new Order(
               
                customerId: request.CustomerId,
                flightId: request.FlightId,
                //todo : need to implment enum to order status 
                status: "Pending",
                items: items
            );

            _OrderReposioty.Add(order);
            
            await _OrderReposioty.UnitOfWork.SaveChangesAsync();
            var OrderViewModel = _mapper.Map<OrderViewModel>(order);
            OrderViewModel.Total = OrderViewModel.OrderItems.Sum(x => x.Qty * x.Price);
            return OrderViewModel;


        }
    }
}

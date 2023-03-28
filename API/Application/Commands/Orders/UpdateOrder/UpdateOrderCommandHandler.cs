using Domain.Aggregates.OrderAggregate;
using MediatR;
using System.Collections.Generic;
using System;
using API.Application.Commands.Orders.CreateOrder;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using AutoMapper;
using Domain.Aggregates.FlightAggregate;
using API.Application.ViewModels.Orders.View;
using Domain.Exceptions;

namespace API.Application.Commands.Orders.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, OrderViewModel>
    {
        private readonly IOrderRepository _OrderReposioty;
        private readonly IFlightRepository _FlightRepository;
        private readonly IMapper _mapper;
        public UpdateOrderCommandHandler(IOrderRepository orderReposioty, IMapper mapper = null, IFlightRepository flightRepository = null)
        {
            _OrderReposioty = orderReposioty;
            _mapper = mapper;
            _FlightRepository = flightRepository;
        }

        public async Task<OrderViewModel> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
           // get order details by order id 
            var order = await _OrderReposioty.GetAsync(request.Id);
            order.IsConfimOrder();
            if (order == null)
            {
                throw new OrderDomainException($"Unable to Find Order realted To {request.Id}");
            }

            // set private property of order entity
            order.SetCutomerId(request.CustomerId);
            order.SetFlightId(request.FlightId);
            order.SetStatus(request.Status);

            _OrderReposioty.RemoveOrderItem(order.Items.ToList());
            //get flight rates realted to flight ID
            var flight =await _FlightRepository.GetAsync(request.FlightId);
            if (order == null)
            {
                throw new OrderDomainException($"Unable to Find Flight Rate Related To {request.FlightId}");
            }
            var items = request.OrderItems.Select(oi => new OrderItem
            {
                FlightRateId = oi.FlightRateId,
                Price = Convert.ToDouble(flight.GetRate(oi.FlightRateId).Price.Value),//get price by flight rate ID
                Qty = oi.Qty
            }).ToList();

            order.SetItems(items);
            await _OrderReposioty.Update(order);

          var _OrderViewModel =  _mapper.Map<OrderViewModel>(order);
          _OrderViewModel.Total = _OrderViewModel.OrderItems.Sum(x => x.Qty * x.Price);

            return _OrderViewModel;
        }
    }
}

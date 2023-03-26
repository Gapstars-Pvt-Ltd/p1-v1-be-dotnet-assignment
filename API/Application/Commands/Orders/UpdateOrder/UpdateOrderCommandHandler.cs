using API.Application.ViewModels.Orders;
using Domain.Aggregates.OrderAggregate;
using MediatR;
using System.Collections.Generic;
using System;
using API.Application.Commands.Orders.CreateOrder;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using AutoMapper;

namespace API.Application.Commands.Orders.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, OrderViewModel>
    {
        private readonly IOrderRepository _OrderReposioty;
        private readonly IMapper _mapper;
        public UpdateOrderCommandHandler(IOrderRepository orderReposioty, IMapper mapper = null)
        {
            _OrderReposioty = orderReposioty;
            _mapper = mapper;
        }

        public async Task<OrderViewModel> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {

            var items = request.OrderItems.Select(item => new OrderItemViewModel
            {
                FlightRateId = item.FlightRateId,
                Price= item.Price,
                Qty = item.Qty,
                Id = item.Id,
            }).ToList();


            var OrderViewModel = new OrderViewModel();
            OrderViewModel.Status = request.Status;
            OrderViewModel.OrderNo= request.OrderNo;
            OrderViewModel.Id = request.Id;
            OrderViewModel.CustomerId = request.CustomerId;
            OrderViewModel.FlightId = request.FlightId;
            OrderViewModel.OrderedDate= request.OrderedDate;
            OrderViewModel.OrderItems = items;

            var _order = _mapper.Map<Order>(OrderViewModel);

            _OrderReposioty.Update(_order);
            await _OrderReposioty.UnitOfWork.SaveChangesAsync();
            //map order to orderviewmodel
           
            //update total of the order
            OrderViewModel.Total = OrderViewModel.OrderItems.Sum(x => x.Qty * x.Price);

            return OrderViewModel;
        }
    }
}

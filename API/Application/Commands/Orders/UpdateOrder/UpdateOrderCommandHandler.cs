using API.Application.ViewModels.Orders;
using Domain.Aggregates.OrderAggregate;
using MediatR;
using System.Collections.Generic;
using System;
using API.Application.Commands.Orders.CreateOrder;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace API.Application.Commands.Orders.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Order>
    {
        private readonly IOrderRepository _OrderReposioty;
        public UpdateOrderCommandHandler(IOrderRepository orderReposioty)
        {
            _OrderReposioty = orderReposioty;
        }

        public async Task<Order> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var items = request.OrderItems.Select(item => new OrderItem
            {
                FlightRateId = item.FlightRateId,
                Qty = item.Nos
            }).ToList();

            var order = new Order(
                orderedDate: request.OrderedDate,
                orderNo: request.OrderNo,
                customerId: request.CustomerId,
                flightId: request.FlightId,
                //todo : need to implment enum to order status 
                status: "Pending",
                items: items
                
            );

            order.SetId(request.Id);

            _OrderReposioty.Update(order);
            await _OrderReposioty.UnitOfWork.SaveChangesAsync();

            return order;
        }
    }
}

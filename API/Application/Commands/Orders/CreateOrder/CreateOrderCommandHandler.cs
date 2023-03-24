using API.Application.Commands.Airports;
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
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Order>
    {

        private readonly IOrderRepository _OrderReposioty;



        public CreateOrderCommandHandler(IOrderRepository orderReposioty)
        {
            _OrderReposioty = orderReposioty;
        }

        public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var items = request.OrderItems.Select(item => new OrderItem
            {
                FlightRateId = item.FlightRateId,
                Qty = item.Qty
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

            _OrderReposioty.Add(order);
            await _OrderReposioty.UnitOfWork.SaveChangesAsync();

            return order;


        }
    }
}

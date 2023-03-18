using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Aggregates.OrderAggregate;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Domain.Aggregates.PassengerAggregate;

namespace API.Application.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IPassengerRepository _passengerRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IPassengerRepository passengerRepository)
        {
            _orderRepository = orderRepository;
            _passengerRepository = passengerRepository;
        }
        public async Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            // Check if customer exists
            var result = _passengerRepository.GetByEmail(request.OrderDto.PassengerInfo.email);
            
            // No Customer found, create new customer
            if (result == null)
            {
                var passenger = new Passenger(request.OrderDto.PassengerInfo.firstName, request.OrderDto.PassengerInfo.lastName, request.OrderDto.PassengerInfo.Age, request.OrderDto.PassengerInfo.email);
                _passengerRepository.Add(passenger);
                await  _passengerRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                
                // Create order
                await CreateBooking(passenger.Id, request, cancellationToken);

                return Unit.Value;
            }
            
            // Customer found, create order for the existing customer
            await CreateBooking(result.Id, request, cancellationToken);
            
            return Unit.Value;
        }
        
        private async Task CreateBooking(Guid customerId, CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var customer = _passengerRepository.GetById(customerId);
            var orderItems = request.OrderDto.OrderItems.Select(item => new OrderItem(item.flightId, item.quantity, item.unitPrice)).ToList();

            customer.PlaceOrder(orderItems);
            
           await _passengerRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
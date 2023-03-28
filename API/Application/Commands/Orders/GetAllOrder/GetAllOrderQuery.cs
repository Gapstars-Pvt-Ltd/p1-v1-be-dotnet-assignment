using API.Application.ViewModels.Orders.View;
using Domain.Aggregates.OrderAggregate;
using MediatR;
using System.Collections.Generic;

namespace API.Application.Commands.Orders.GetAllOrder
{
    public class GetAllOrderQuery : IRequest<List<OrderViewModel>>
    {
    
    }
}

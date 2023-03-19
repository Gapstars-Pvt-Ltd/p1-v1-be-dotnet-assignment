using Domain.Events;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace API.Events
{
    public class OrderConfirmedEventHandler : INotificationHandler<OrderConfirmedEvent>
    {
        public Task Handle(OrderConfirmedEvent notification, CancellationToken cancellationToken)
        {
            return Task.Run(() => System.Diagnostics.Debug.WriteLine(
                string.Format("Inform customer : {0} that the order {1} is confirmed.", 
                notification.Order.Id, notification.CustomerId))); 
        }
    }
}

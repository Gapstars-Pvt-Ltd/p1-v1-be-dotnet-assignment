using API.Application.Dto;
using MediatR;

namespace API.Application.Commands.UpdateOrder
{
    public class UpdateOrderStatusCommand : IRequest
    {
        public ConfirmDto ConfirmBooking { get; set; }
    }
}

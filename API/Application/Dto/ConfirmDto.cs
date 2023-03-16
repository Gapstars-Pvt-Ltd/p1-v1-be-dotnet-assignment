using Domain.Common;
using System;

namespace API.Application.Dto
{
    public class ConfirmDto
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public string Confirmation { get; set; }
    }
}

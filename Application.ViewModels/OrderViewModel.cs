using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public DateTimeOffset? OrderConfirmedDate { get; set; }
        public bool isConfirmed { get; set; }
        public decimal Price { get; set; }
    }
}

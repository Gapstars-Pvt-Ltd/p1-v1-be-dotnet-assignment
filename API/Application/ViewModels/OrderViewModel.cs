﻿using System;

namespace API.Application.ViewModels
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }

        public Guid FlightId { get; set; }

        public Guid FlightRateId { get; set; }

        public Guid CustomerId { get; set; }

        public int SeatCount { get; set; }

    }
}

using Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;

namespace Application.Query
{
    public class GetAvailableFlightsQuery : IRequest<List<AvailableFlightsViewModel>>
    {
        public string AirPortCode { get; set; }
    }
    

}

using API.Application.ViewModels;
using API.Application.ViewModels.Customers;
using AutoMapper;
using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.CustomerAggregate;

namespace API.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
        }
    }
}

using Application.Features.Customers.Commands.CreateCustomer;
using Application.Features.Customers.Commands.DeleteCustomer;
using Application.Features.Customers.Queries.GetCustomerDetails;
using Application.Features.Customers.Queries.GetCustomersList;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        protected MappingProfile()
        {
            CreateMap<Customer, CustomerListVM>().ReverseMap();
            CreateMap<Customer, CustomerDetailsVM>().ReverseMap();
            CreateMap<Customer, CreateCustomerCommand>().ReverseMap();
            CreateMap<Customer, DeleteCustomerCommand>().ReverseMap();
        }
    }
}

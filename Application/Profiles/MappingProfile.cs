using Application.Features.Customers;
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
        }
    }
}

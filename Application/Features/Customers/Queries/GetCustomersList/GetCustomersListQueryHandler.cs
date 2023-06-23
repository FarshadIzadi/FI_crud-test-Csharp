using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Queries.GetCustomersList
{
    public class GetCustomersListQueryHandler : IRequestHandler<GetCustomersListQuery, List<CustomerListVM>>
    {
        private readonly IAsyncRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomersListQueryHandler(IMapper mapper, IAsyncRepository<Customer> customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<List<CustomerListVM>> Handle(GetCustomersListQuery request, CancellationToken cancellationToken)
        {
            var allCustomers = await _customerRepository.GetAll();

            return _mapper.Map<List<CustomerListVM>>(allCustomers);
        }
    }
}

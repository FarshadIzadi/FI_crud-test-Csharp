using Application.Contracts.Persistence;
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
    public class GetCustomersListQueryHandler : IRequestHandler<GetCustomersListQuery, List<Customer>>
    {
        private readonly IAsyncRepository<Customer> _customerRepository;

        public GetCustomersListQueryHandler(IAsyncRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<Customer>> Handle(GetCustomersListQuery request, CancellationToken cancellationToken)
        {
            var allCustomers = (await _customerRepository.GetAll()).ToList();
            
            return allCustomers;
        }
    }
}

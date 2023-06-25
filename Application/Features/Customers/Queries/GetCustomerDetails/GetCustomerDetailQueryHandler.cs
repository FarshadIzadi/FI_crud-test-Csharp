using Application.Contracts.Persistence;
using Application.Features.Customers.Commands.DeleteCustomer;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Queries.GetCustomerDetails
{
    public class GetCustomerDetailQueryHandler : IRequestHandler<GetCustomerDetailQuery, CustomerDetailVM>
    {

        private readonly IAsyncRepository<Customer> _customerRepository;

        public GetCustomerDetailQueryHandler(IAsyncRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerDetailVM> Handle(GetCustomerDetailQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.Id);

            var customerDetailVM = new CustomerDetailVM()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PhoneNmber = customer.PhoneNmber,
                Email = customer.Email,
                BankAccountNumber = customer.BankAccountNumber,
                DateOfBirth = customer.DateOfBirth,
            };

            return customerDetailVM;
        }
    }
}

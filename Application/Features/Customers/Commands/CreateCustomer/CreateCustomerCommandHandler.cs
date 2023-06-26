using Application.Contracts.Persistence;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerResponse>
    {
        private readonly IAsyncRepository<Customer> _customerRepository;

        public CreateCustomerCommandHandler(IAsyncRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CreateCustomerResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var createCustomerResponse = new CreateCustomerResponse();

            var validator = new CreateCustomerValidator(_customerRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createCustomerResponse.Success = false;
                createCustomerResponse.Errors = new List<string>();
                foreach (var error in validationResult.Errors) {
                    createCustomerResponse.Errors.Add(error.ErrorMessage);
                }
            }
            if (createCustomerResponse.Success)
            {
                var customer = new Customer()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    DateOfBirth = request.DateOfBirth,
                    BankAccountNumber = request.BankAccountNumber,
                    Email = request.Email,
                    PhoneNmber = request.PhoneNmber
                };
                customer = await _customerRepository.AddAsync(customer);
                
                createCustomerResponse = new CreateCustomerResponse()
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    DateOfBirth = customer.DateOfBirth,
                    Email = customer.Email,
                    PhoneNmber = customer.PhoneNmber,
                    Errors = null
                };
            }

            return createCustomerResponse;
        }
    }
}

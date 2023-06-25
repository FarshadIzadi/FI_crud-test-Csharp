using Application.Contracts.Persistence;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        async Task IRequestHandler<UpdateCustomerCommand>.Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerToUpdate = await _customerRepository.GetByIdAsync(request.Id);

            customerToUpdate.FirstName = request.FirstName;
            customerToUpdate.LastName = request.LastName;
            customerToUpdate.DateOfBirth = request.DateOfBirth;
            customerToUpdate.PhoneNmber = request.PhoneNmber;
            customerToUpdate.Email = request.Email;
            customerToUpdate.BankAccountNumber = request.BankAccountNumber;

            await _customerRepository.UpdateAsync(customerToUpdate);
        }
    }
}

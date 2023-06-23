using Application.Contracts.Persistence;
using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Features.Customers.Commands.CreateCustomer
{
    internal class CreateCustomerValidator : AbstractValidator<CreateCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerValidator(ICustomerRepository customerRepository)
        {

            _customerRepository = customerRepository;

            RuleFor(m => new { m.FirstName, m.LastName, m.DateOfBirth })
                .Must(x => isUserUnique(x.FirstName,x.LastName,x.DateOfBirth).GetAwaiter().GetResult())
                .WithMessage("User already Exists");

            RuleFor(property => property.FirstName)
                 .NotEmpty()
                 .NotNull().WithMessage("First Name is required.")
                 .MaximumLength(50).WithMessage("First Name must not exceed 50 characters.");

            RuleFor(property => property.LastName)
                 .NotEmpty()
                 .NotNull().WithMessage("Last Name is required.")
                 .MaximumLength(50).WithMessage("Last Name must not exceed 50 characters.");

            RuleFor(property => property.DateOfBirth)
                 .NotEmpty()
                 .NotNull().WithMessage("Date of Birth is required.")
                 .LessThan(DateTime.Now);


            RuleFor(property => property.PhoneNmber)
                 .NotEmpty()
                 .NotNull().WithMessage("Phone Number is required.")
                 .MinimumLength(10).WithMessage("PhoneNumber must not be less than 10 characters.")
                 .MaximumLength(20).WithMessage("PhoneNumber must not exceed 50 characters.")
                 .Matches(new Regex(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}")).WithMessage("PhoneNumber not valid");

            RuleFor(property => property.Email)
                .EmailAddress()
                .Must(x => isEmailUnique(x).GetAwaiter().GetResult())
                .WithMessage("Email Already Exists");
            
            RuleFor(property => property.BankAccountNumber).CreditCard();
        }

        public async Task<bool> isEmailUnique(string email)
        {
            var customer = (await _customerRepository.GetAll()).Where(x => x.Email == email).FirstOrDefault();
            if (customer == null) return true;

            return false;
        }

        public async Task<bool> isUserUnique(string firstName,string lastName,DateTime dateOfBirth)
        {
            var customer = (await _customerRepository.GetAll())
                .Where(x => x.FirstName == firstName
                        && x.LastName == lastName
                        && x.DateOfBirth == dateOfBirth
                ).FirstOrDefault();
            if (customer == null) return true;

            return false;
        }
    }
}

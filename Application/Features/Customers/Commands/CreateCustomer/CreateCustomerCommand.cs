using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Commands.CreateCustomer
{
    internal class CreateCustomerCommand : IRequest<int>
    {
        public int FirstName { get; set; }
        public int LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNmber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }

        public override string ToString()
        {
            return $"Full name: {FirstName} {LastName}; Date of Birth: {DateOfBirth.ToShortDateString()};" +
                $" Phone Number: {PhoneNmber}; Email: {Email}; Account Number: {BankAccountNumber};";
        }
    }
}

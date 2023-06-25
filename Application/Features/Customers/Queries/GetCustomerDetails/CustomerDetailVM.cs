using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Queries.GetCustomerDetails
{
    public class CustomerDetailVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNmber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
    }
}

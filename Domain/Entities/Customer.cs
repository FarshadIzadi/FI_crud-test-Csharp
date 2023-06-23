using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Customer : AuditableEntity
    {        
        public int Id { get; set; }


        public int FirstName { get; set; }
        
        public int LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string PhoneNmber { get; set; }

        public string Email { get; set; }

        public string BankAccountNumber { get; set; }

    }
}

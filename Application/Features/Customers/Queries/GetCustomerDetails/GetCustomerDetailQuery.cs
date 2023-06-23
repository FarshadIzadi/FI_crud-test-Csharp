using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Queries.GetCustomerDetails
{
    public class GetCustomerDetailQuery : IRequest<CustomerDetailsVM>
    {
        public int Id { get; set; }
    }
}

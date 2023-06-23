using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Queries.GetCustomersList
{
    public class GetCustomersListQuery : IRequest<List<CustomerListVM>>
    {
    }
}

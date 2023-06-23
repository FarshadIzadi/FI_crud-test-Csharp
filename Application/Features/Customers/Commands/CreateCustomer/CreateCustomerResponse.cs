using Application.Responses;


namespace Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerResponse : BaseResponse
    {
        public CreateCustomerResponse() : base()
        {
        }

        public CreateCustomerDTO createCustomerDTO { get; set; }
    }
}

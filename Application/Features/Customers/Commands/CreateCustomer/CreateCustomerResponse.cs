

namespace Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerResponse
    {
        public bool Success { get; set; } = true;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string PhoneNmber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<string> Errors { get; set; }
    }
}

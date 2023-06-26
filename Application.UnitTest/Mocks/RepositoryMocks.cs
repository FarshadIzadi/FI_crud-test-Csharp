using Application.Contracts.Persistence;
using Domain.Entities;
using Moq;

namespace Application.UnitTest.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<IAsyncRepository<Customer>> GetCustomerRepository()
        {
            var customers = new List<Customer>()
            {
                new Customer() {
                    Id = 1,
                    FirstName = "Farshad",
                    LastName = "Izadi",
                    PhoneNmber = "9363538306",
                    DateOfBirth = DateTime.Now.AddYears(-30),
                    BankAccountNumber = "6037995465412365",
                    Email = "farshad.izadi@gmail.com"
                },
                new Customer() {
                    Id = 2,
                    FirstName = "James",
                    LastName = "Web", 
                    PhoneNmber = "9354786542",
                    DateOfBirth = DateTime.Now.AddYears(-20),
                    BankAccountNumber = "8000659865478521",
                    Email = "james.web@gmail.com"
                },
                new Customer() {
                    Id = 3,
                    FirstName = "John",
                    LastName = "Wick",
                    PhoneNmber = "9128746548",
                    DateOfBirth = DateTime.Now.AddYears(-35),
                    BankAccountNumber = "9658321458731564",
                    Email = "john.wick@yahoo.com"
                }
            };

            var mockCustomerRepository = new Mock<IAsyncRepository<Customer>>();
            mockCustomerRepository.Setup(rep => rep.GetAll()).ReturnsAsync(customers);

            mockCustomerRepository.Setup(rep => rep.AddAsync(It.IsAny<Customer>()))
                            .ReturnsAsync(
                (Customer customer) =>
                {
                    customers.Add(customer);
                    return customer;
                });

            return mockCustomerRepository;
        }
    }
}

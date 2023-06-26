using Application.Contracts.Persistence;
using Application.Features.Customers.Commands.CreateCustomer;
using Application.UnitTest.Mocks;
using Domain.Entities;
using Moq;
using Shouldly;
using Xunit;

namespace Application.UnitTest.Customers.Commands
{
    public class CreateCustomerTests
    {
        private readonly Mock<IAsyncRepository<Customer>> _mockCustomerRepository;

        public CreateCustomerTests()
        {
            _mockCustomerRepository = RepositoryMocks.GetCustomerRepository();
        }
        [Fact]
        public async Task CreateValidCustomerTest()
        {
            var handler = new CreateCustomerCommandHandler(_mockCustomerRepository.Object);
            await handler.Handle(new CreateCustomerCommand() {
                
                FirstName = "John",
                LastName = "Doe",
                BankAccountNumber = "9987456532128541",
                Email = "johndoe@hotmail.com",
                DateOfBirth = DateTime.Now,
                PhoneNmber = "9379875489"
            }, CancellationToken.None);

            var result = await _mockCustomerRepository.Object.GetAll();
            
            result.Count.ShouldBe(4);
        }
    }
}

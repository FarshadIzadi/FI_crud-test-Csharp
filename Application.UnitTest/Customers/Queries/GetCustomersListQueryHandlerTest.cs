using Application.Contracts.Persistence;
using Application.Features.Customers.Queries.GetCustomersList;
using Application.UnitTest.Mocks;
using AutoMapper;
using Domain.Entities;
using Moq;
using Shouldly;
using Xunit;

namespace Application.UnitTest.Customers.Queries
{
    public class GetCustomersListQueryHandlerTest
    {
        private readonly Mock<IAsyncRepository<Customer>> _mockCustomerRepository;

        public GetCustomersListQueryHandlerTest()
        {

            _mockCustomerRepository = RepositoryMocks.GetCustomerRepository();
        }

        [Fact]
        public async Task GetCustomersQueryListHandler()
        {
            var handler = new GetCustomersListQueryHandler(_mockCustomerRepository.Object);
            var result = await handler.Handle(new GetCustomersListQuery(), CancellationToken.None);
            result.ShouldBeOfType<List<Customer>>();
            result.Count.ShouldBe(3);
        }
    }
}

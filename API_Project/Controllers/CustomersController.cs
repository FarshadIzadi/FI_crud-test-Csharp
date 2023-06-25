using Application.Contracts.Persistence;
using Application.Features.Customers.Commands.CreateCustomer;
using Application.Features.Customers.Commands.DeleteCustomer;
using Application.Features.Customers.Commands.UpdateCustomer;
using Application.Features.Customers.Queries.GetCustomerDetails;
using Application.Features.Customers.Queries.GetCustomersList;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistence.Configurations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private readonly IMediator _mediator;
        public CustomersController(ICustomerRepository customerRepository, IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<CustomersController>
        [HttpGet(Name ="GetCustomersList")]
        public async Task<ActionResult<List<Customer>>> Get()
        {
            var customers = await _mediator.Send(new GetCustomersListQuery());
            return Ok(customers);
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public async Task<CustomerDetailVM> Get(int id)
        {
            var getCustomerDetailQuery = new GetCustomerDetailQuery() { Id = id };
            var result = await _mediator.Send(getCustomerDetailQuery);
            return result;
        }

        // POST api/<CustomersController>
        [HttpPost(Name = "CreateNewCustomer")]
        public async Task<ActionResult<CreateCustomerResponse>> Create([FromBody] CreateCustomerCommand createCustomerCommand)
        {
            var response = await _mediator.Send(createCustomerCommand);
            return Ok(response);
        }

        // PUT api/<CustomersController>/5
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateCustomerCommand updateCustomerCommand)
        {
            await _mediator.Send(updateCustomerCommand);
            return NoContent();
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteCustomerCommand = new DeleteCustomerCommand() { Id = id };
            await _mediator.Send(deleteCustomerCommand);
            return NoContent();
        }
    }
}

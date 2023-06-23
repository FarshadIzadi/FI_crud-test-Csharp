using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerResponse>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<CreateCustomerResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var createCustomerResponse = new CreateCustomerResponse();

            var validator = new CreateCustomerValidator(_customerRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createCustomerResponse.Success = false;
                createCustomerResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors) {
                    createCustomerResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createCustomerResponse.Success)
            {
                var customer = _mapper.Map<Customer>(request);
                customer = await _customerRepository.AddAsync(customer);
                createCustomerResponse.createCustomerDTO = _mapper.Map<CreateCustomerDTO>(customer);
            }

            return createCustomerResponse;
        }
    }
}

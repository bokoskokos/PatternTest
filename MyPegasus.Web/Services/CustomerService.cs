using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyPegasus.Common.DomainModel.Models;
using MyPegasus.Framework.HandlerRequests;
using MyPegasus.Framework.HandlerResponses;
using MyPegasus.Web.Models.Customer;
using MyPegasus.Web.Services.Contracts;

namespace MyPegasus.Web.Services
{
    public class CustomerService : ServiceBase, ICustomerService
    {
        public async Task<CustomerViewModel> RetrieveByIdAsync(Guid id)
        {
            var request = new RetrieveCustomerByIdHandlerRequest {CustomerId = id};
            var response = await CallHandlerAsync<RetrieveCustomerByIdHandlerRequest, RetrieveCustomerByIdHandlerResponse>(request);

            var viewModel = Mapper.Map<ICustomer, CustomerViewModel>(response.Customer);
            return viewModel;
        }

        public async Task CreateAsync(CreateCustomerViewModel customer)
        {
            var request = new CreateCustomerHandlerRequest
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                DateOfBirth = customer.DateOfBirth,
                Email = customer.Email
            };

            await CallHandlerAsync<CreateCustomerHandlerRequest, CreateCustomerHandlerResponse>(request);
        }

        public async Task<IEnumerable<CustomerViewModel>> RetrieveAllAsync()
        {
            var response = await CallHandlerAsync<RetrieveAllCustomersHandlerRequest, RetrieveAllCustomersHandlerResponse>(new RetrieveAllCustomersHandlerRequest());
            var viewModels = Mapper.Map<ICustomer, CustomerViewModel>(response.Customers);
            return viewModels;
        }
    }
}
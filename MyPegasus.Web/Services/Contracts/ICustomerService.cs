using System;
using System.Threading.Tasks;
using MyPegasus.Web.Models.Customer;
using System.Collections.Generic;

namespace MyPegasus.Web.Services.Contracts
{
    public interface ICustomerService : IService
    {
        Task<IEnumerable<CustomerViewModel>> RetrieveAllAsync();
        Task<CustomerViewModel> RetrieveByIdAsync(Guid id);
        Task CreateAsync(CreateCustomerViewModel customer);
    }
}

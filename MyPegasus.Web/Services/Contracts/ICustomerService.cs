using System;
using System.Threading.Tasks;
using MyPegasus.Web.Models.Customer;

namespace MyPegasus.Web.Services.Contracts
{
    public interface ICustomerService : IService
    {
        Task<CustomerViewModel> RetrieveByIdAsync(Guid id);
        Task CreateAsync(CreateCustomerViewModel customer);
    }
}

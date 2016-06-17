using System;
using System.Threading.Tasks;
using MyPegasus.Common.DomainModel.Models;
using System.Linq;

namespace MyPegasus.Common.DataAccess.Repositories
{
    public interface ICustomerRepository
    {
        Task<ICustomer> RetrieveByIdAsync(Guid id);
        Task CreateAsync(ICustomer customer);
        Task<IQueryable<ICustomer>> RetrieveAllAsync();
    }
}

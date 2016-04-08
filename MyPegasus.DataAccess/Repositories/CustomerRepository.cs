using System;
using System.Data.Entity;
using System.Threading.Tasks;
using MyPegasus.Common.DataAccess.Repositories;
using MyPegasus.Common.DomainModel.Models;
using MyPegasus.DataAccess.Database;
using MyPegasus.DomainModel.Models;

namespace MyPegasus.DataAccess.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IPegasusContext _pegasusContext;

        public CustomerRepository(IPegasusContext pegasusContext)
        {
            _pegasusContext = pegasusContext;
        }

        public async Task<ICustomer> RetrieveByIdAsync(Guid id)
        {
            return await _pegasusContext.Customers.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task CreateAsync(ICustomer customer)
        {
            await Task.Run(() => _pegasusContext.Customers.Add((Customer)customer));
        }
    }
}

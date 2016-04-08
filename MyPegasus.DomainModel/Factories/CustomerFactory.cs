using System;
using System.Threading.Tasks;
using MyPegasus.Common.DomainModel.Factories;
using MyPegasus.Common.DomainModel.Models;
using MyPegasus.DomainModel.Models;

namespace MyPegasus.DomainModel.Factories
{
    public class CustomerFactory : FactoryBase, ICustomerFactory
    {
        public async Task<ICustomer> CreateAsync(string firstName, string lastName, string email, DateTimeOffset dateOfBirth)
        {
            var customerResponse = await Customer.CreateAsync(firstName, lastName, email, dateOfBirth);
            return Return(customerResponse);
        }
    }
}

using System;
using System.Threading.Tasks;
using MyPegasus.Common.DomainModel.Models;

namespace MyPegasus.Common.DomainModel.Factories
{
    public interface ICustomerFactory
    {
        Task<ICustomer> CreateAsync(string firstName, string lastName, string email, DateTimeOffset dateOfBirth);
    }
}

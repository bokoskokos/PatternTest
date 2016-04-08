using System;
using System.Threading.Tasks;
using MyPegasus.Common.DomainModel.Models;

namespace MyPegasus.Common.DomainModel.Factories
{
    public interface ITripFactory
    {
        Task<ITrip> CreateAsync(string title, DateTimeOffset departure, DateTimeOffset arrival, ICustomer customer);
    }
}

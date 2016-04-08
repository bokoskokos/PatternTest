using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyPegasus.Common.DomainModel.Models;

namespace MyPegasus.Common.DataAccess.Repositories
{
    public interface ITripRepository
    {
        Task<ITrip> RetrieveByIdAsync(Guid id);
        Task CreateAsync(ITrip trip);
        Task<IEnumerable<ITrip>> RetrieveByCustomerIdAsync(Guid customerId);
    }
}

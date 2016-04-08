using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using MyPegasus.Common.DataAccess.Repositories;
using MyPegasus.Common.DomainModel.Models;
using MyPegasus.DataAccess.Database;
using MyPegasus.DomainModel.Models;

namespace MyPegasus.DataAccess.Repositories
{
    public class TripRepository : ITripRepository
    {
        private readonly IPegasusContext _pegasusContext;

        public TripRepository(IPegasusContext pegasusContext)
        {
            _pegasusContext = pegasusContext;
        }

        public async Task<ITrip> RetrieveByIdAsync(Guid id)
        {
            return await _pegasusContext.Trips.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task CreateAsync(ITrip trip)
        {
            await Task.Run(() => _pegasusContext.Trips.Add((Trip)trip));
        }

        public async Task<IEnumerable<ITrip>> RetrieveByCustomerIdAsync(Guid customerId)
        {
            return await _pegasusContext.Trips.Where(t => t.CustomerInternal.Id == customerId).ToListAsync();
        }
    }
}

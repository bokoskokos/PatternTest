using System;
using System.Threading.Tasks;
using MyPegasus.Common.DomainModel.Factories;
using MyPegasus.Common.DomainModel.Models;
using MyPegasus.DomainModel.Models;

namespace MyPegasus.DomainModel.Factories
{
    public class TripFactory : FactoryBase, ITripFactory
    {
        public async Task<ITrip> CreateAsync(string title, DateTimeOffset departure, DateTimeOffset arrival, ICustomer customer)
        {
            var tripResponse = await Trip.CreateAsync(title, departure, arrival, customer);
            return Return(tripResponse);
        }
    }
}

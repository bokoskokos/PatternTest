using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyPegasus.Web.Models.Trip;

namespace MyPegasus.Web.Services.Contracts
{
    public interface ITripService : IService
    {
        Task<IEnumerable<TripViewModel>> RetrieveTripsForCustomerAsync(Guid customerId);
        Task CreateTripAsync(CreateTripViewModel trip);
    }
}

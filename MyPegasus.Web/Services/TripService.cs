using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyPegasus.Common.DomainModel.Models;
using MyPegasus.Framework.HandlerRequests;
using MyPegasus.Framework.HandlerResponses;
using MyPegasus.Web.Models.Trip;
using MyPegasus.Web.Services.Contracts;

namespace MyPegasus.Web.Services
{
    public class TripService : ServiceBase, ITripService
    {
        public async Task<IEnumerable<TripViewModel>> RetrieveTripsForCustomerAsync(Guid customerId)
        {
            var request = new RetrieveTripsForCustomerHandlerRequest {CustomerId = customerId};

            var response = await CallHandlerAsync<RetrieveTripsForCustomerHandlerRequest, RetrieveTripsForCustomerHandlerResponse>(request);

            return Mapper.Map<ITrip, TripViewModel>(response.Trips);
        }

        public async Task CreateTripAsync(CreateTripViewModel trip)
        {
            var request = new CreateTripHandlerRequest
            {
                CustomerId = trip.CustomerId,
                Arrival = trip.Arrival,
                Departure = trip.Departure,
                Title = trip.Title
            };

            await CallHandlerAsync<CreateTripHandlerRequest, CreateTripHandlerResponse>(request);
        }
    }
}
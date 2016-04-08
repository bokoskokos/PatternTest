using System.Threading.Tasks;
using MyPegasus.Common.DataAccess.Repositories;
using MyPegasus.Common.Framework;
using MyPegasus.Framework.HandlerRequests;
using MyPegasus.Framework.HandlerResponses;

namespace MyPegasus.Framework.Handlers
{
    public class RetrieveTripsForCustomerHandler : IHandler<RetrieveTripsForCustomerHandlerRequest, RetrieveTripsForCustomerHandlerResponse>
    {
        private readonly ITripRepository _tripRepository;

        public RetrieveTripsForCustomerHandler(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }

        public async Task<RetrieveTripsForCustomerHandlerResponse> HandleAsync(RetrieveTripsForCustomerHandlerRequest request)
        {
            var trips = await _tripRepository.RetrieveByCustomerIdAsync(request.CustomerId);
            return new RetrieveTripsForCustomerHandlerResponse { Trips = trips };
        }
    }
}

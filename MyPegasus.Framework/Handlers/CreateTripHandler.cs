using System.Threading.Tasks;
using MyPegasus.Common.Common;
using MyPegasus.Common.DataAccess.Database;
using MyPegasus.Common.DataAccess.Repositories;
using MyPegasus.Common.DomainModel.Factories;
using MyPegasus.Common.Framework;
using MyPegasus.Framework.HandlerRequests;
using MyPegasus.Framework.HandlerResponses;

namespace MyPegasus.Framework.Handlers
{
    public class CreateTripHandler : IHandler<CreateTripHandlerRequest, CreateTripHandlerResponse>
    {
        private readonly ITripRepository _tripRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITripFactory _tripFactory;

        public CreateTripHandler(ITripRepository tripRepository, ICustomerRepository customerRepository, IUnitOfWork unitOfWork, ITripFactory tripFactory)
        {
            _tripRepository = tripRepository;
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _tripFactory = tripFactory;
        }

        public async Task<CreateTripHandlerResponse> HandleAsync(CreateTripHandlerRequest request)
        {
            var customer = await _customerRepository.RetrieveByIdAsync(request.CustomerId);

            if (customer == null)
            {
                return new CreateTripHandlerResponse { OperationResponse = OperationResponse.Error("Customer not found") };
            }

            var trip = await _tripFactory.CreateAsync(request.Title, request.Departure, request.Arrival, customer);

            await _tripRepository.CreateAsync(trip);
            await _unitOfWork.SaveAsync();

            return new CreateTripHandlerResponse { Trip = trip };
        }
    }
}

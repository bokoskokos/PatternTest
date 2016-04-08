using System.Threading.Tasks;
using MyPegasus.Common.DataAccess.Database;
using MyPegasus.Common.DataAccess.Repositories;
using MyPegasus.Common.DomainModel.Factories;
using MyPegasus.Common.Framework;
using MyPegasus.Framework.HandlerRequests;
using MyPegasus.Framework.HandlerResponses;

namespace MyPegasus.Framework.Handlers
{
    public class CreateCustomerHandler : IHandler<CreateCustomerHandlerRequest, CreateCustomerHandlerResponse>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerFactory _customerFactory;

        public CreateCustomerHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork, ICustomerFactory customerFactory)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _customerFactory = customerFactory;
        }

        public async Task<CreateCustomerHandlerResponse> HandleAsync(CreateCustomerHandlerRequest request)
        {
            var customer = await _customerFactory.CreateAsync(request.FirstName, request.LastName, request.Email, request.DateOfBirth);

            await _customerRepository.CreateAsync(customer);

            await _unitOfWork.SaveAsync();

            return new CreateCustomerHandlerResponse { Customer = customer };
        }
    }
}

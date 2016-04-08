using System;
using System.Threading.Tasks;
using MyPegasus.Common.DataAccess.Repositories;
using MyPegasus.Common.Framework;
using MyPegasus.Framework.HandlerRequests;
using MyPegasus.Framework.HandlerResponses;

namespace MyPegasus.Framework.Handlers
{
    public class RetrieveCustomerByIdHandler : IHandler<RetrieveCustomerByIdHandlerRequest, RetrieveCustomerByIdHandlerResponse>
    {
        private readonly ICustomerRepository _customerRepository;

        public RetrieveCustomerByIdHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<RetrieveCustomerByIdHandlerResponse> HandleAsync(RetrieveCustomerByIdHandlerRequest request)
        {
            if (request.CustomerId == default(Guid))
            {
                throw new ArgumentException("RetrieveCustomerByIdHandlerRequest.CustomerId is required");
            }

            var customer = await _customerRepository.RetrieveByIdAsync(request.CustomerId);

            return new RetrieveCustomerByIdHandlerResponse { Customer = customer };
        }
    }
}

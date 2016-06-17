using MyPegasus.Common.DataAccess.Repositories;
using MyPegasus.Common.Framework;
using MyPegasus.Framework.HandlerRequests;
using System.Linq;
using System.Threading.Tasks;

namespace MyPegasus.Framework.Handlers
{
    public class RetrieveAllCustomersHandler : IHandler<RetrieveAllCustomersHandlerRequest, RetrieveAllCustomersHandlerResponse>
    {
        private readonly ICustomerRepository _customerRepository;

        public RetrieveAllCustomersHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<RetrieveAllCustomersHandlerResponse> HandleAsync(RetrieveAllCustomersHandlerRequest request)
        {
            var response = new RetrieveAllCustomersHandlerResponse();
            var customers = await _customerRepository.RetrieveAllAsync();
            response.Customers = customers.ToList();

            return response;
        }
    }
}

using MyPegasus.Common.DomainModel;
using MyPegasus.Common.DomainModel.Models;

namespace MyPegasus.Framework.HandlerResponses
{
    public class RetrieveCustomerByIdHandlerResponse : HandlerResponseBase
    {
        public ICustomer Customer { get; set; }
    }
}

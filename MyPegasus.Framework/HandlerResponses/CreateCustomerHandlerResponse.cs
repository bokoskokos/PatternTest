using MyPegasus.Common.DomainModel.Models;

namespace MyPegasus.Framework.HandlerResponses
{
    public class CreateCustomerHandlerResponse : HandlerResponseBase
    {
        public ICustomer Customer { get; set; }
    }
}

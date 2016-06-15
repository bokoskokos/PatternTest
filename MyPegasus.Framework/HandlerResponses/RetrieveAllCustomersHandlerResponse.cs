using MyPegasus.Common.DomainModel.Models;
using MyPegasus.Framework.HandlerResponses;
using System.Collections.Generic;

namespace MyPegasus.Framework.HandlerRequests
{
    public class RetrieveAllCustomersHandlerResponse : HandlerResponseBase
    {
        public IList<ICustomer> Customers { get; set; }
    }
}

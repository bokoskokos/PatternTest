using System;

namespace MyPegasus.Framework.HandlerRequests
{
    public class RetrieveCustomerByIdHandlerRequest : HandlerRequestBase
    {
        public Guid CustomerId { get; set; }
    }
}

using System;

namespace MyPegasus.Framework.HandlerRequests
{
    public class RetrieveTripsForCustomerHandlerRequest : HandlerRequestBase
    {
        public Guid CustomerId { get; set; }
    }
}

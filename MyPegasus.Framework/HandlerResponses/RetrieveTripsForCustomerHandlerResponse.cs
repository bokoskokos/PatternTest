using System.Collections.Generic;
using MyPegasus.Common.DomainModel.Models;

namespace MyPegasus.Framework.HandlerResponses
{
    public class RetrieveTripsForCustomerHandlerResponse : HandlerResponseBase
    {
        public IEnumerable<ITrip> Trips { get; set; }
    }
}

using MyPegasus.Common.DomainModel;
using MyPegasus.Common.DomainModel.Models;

namespace MyPegasus.Framework.HandlerResponses
{
    public class CreateTripHandlerResponse : HandlerResponseBase
    {
        public ITrip Trip { get; set; }
    }
}

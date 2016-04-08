using MyPegasus.Common.Common;
using MyPegasus.Common.Framework;

namespace MyPegasus.Framework.HandlerResponses
{
    public class HandlerResponseBase : IHandlerResponse
    {
        public IOperationResponse OperationResponse { get; set; }
    }
}

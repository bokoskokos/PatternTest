using MyPegasus.Common.Common;

namespace MyPegasus.Common.Framework
{
    public interface IHandlerResponse
    {
        IOperationResponse OperationResponse { get; }
    }
}

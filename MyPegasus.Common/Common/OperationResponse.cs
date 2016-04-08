using MyPegasus.Common.DomainModel;

namespace MyPegasus.Common.Common
{
    public class OperationResponse : IOperationResponse
    {
        protected OperationResponse()
        {
        }

        public static IOperationResponse Success()
        {
            return new OperationResponse { Type = OperationResponseType.Success };
        }

        public static IOperationResponse Error(string message)
        {
            return new OperationResponse { Type = OperationResponseType.Error, Message = message };
        }

        public string Message { get; protected set; }

        public OperationResponseType Type { get; protected set; }

        public bool IsOk => Type == OperationResponseType.Success;
    }

    public class OperationResponse<TPayload> : OperationResponse, IOperationResponse<TPayload>
        where TPayload : class
    {
        public static IOperationResponse<TPayload> Success(TPayload payload)
        {
            return new OperationResponse<TPayload> { Type = OperationResponseType.Success, Payload = payload};
        }

        public static new IOperationResponse<TPayload> Error(string message)
        {
            return new OperationResponse<TPayload> { Type = OperationResponseType.Error };
        }

        public TPayload Payload { get; private set; }
    }
}

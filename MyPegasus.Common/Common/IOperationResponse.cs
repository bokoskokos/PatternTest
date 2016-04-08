namespace MyPegasus.Common.Common
{
    public interface IOperationResponse
    {
        string Message { get; }
        OperationResponseType Type { get; }
        bool IsOk { get; }
    }

    public interface IOperationResponse<out TPayload> : IOperationResponse
        where TPayload : class
    {
        TPayload Payload { get; }
    }

    public enum OperationResponseType
    {
        Success,
        Error
    }
}

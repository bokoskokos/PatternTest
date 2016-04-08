using System.Threading.Tasks;

namespace MyPegasus.Common.Framework
{
    public interface IHandler<in TRequest, TResponse> 
        where TRequest: class, IHandlerRequest
        where TResponse : class, IHandlerResponse
    {
        Task<TResponse> HandleAsync(TRequest request);
    }
}

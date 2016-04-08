using System.Threading.Tasks;
using MyPegasus.Common.Framework;

namespace MyPegasus.Web.Services.Contracts
{
    public interface IService
    {
        Task<THandlerResponse> CallHandlerAsync<THandlerRequest, THandlerResponse>(THandlerRequest request)
            where THandlerRequest : class, IHandlerRequest 
            where THandlerResponse : class, IHandlerResponse;
    }
}

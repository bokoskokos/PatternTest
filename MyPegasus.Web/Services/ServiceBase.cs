using System;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using MyPegasus.Common.Framework;
using MyPegasus.Web.App_Start;
using MyPegasus.Web.Mappers;
using MyPegasus.Web.Services.Contracts;

namespace MyPegasus.Web.Services
{
    public abstract class ServiceBase : IService
    {
        private readonly IUnityContainer _container;
        protected readonly IPegasusMapper Mapper;

        protected ServiceBase()
        {
            _container = UnityConfig.GetConfiguredContainer();
            Mapper = _container.Resolve<IPegasusMapper>();
        }

        public async Task<THandlerResponse> CallHandlerAsync<THandlerRequest, THandlerResponse>(THandlerRequest request) 
            where THandlerRequest : class, IHandlerRequest 
            where THandlerResponse : class, IHandlerResponse
        {
            try
            {
                var handler = _container.Resolve<IHandler<THandlerRequest, THandlerResponse>>();
                var response = await handler.HandleAsync(request);

                if (response.OperationResponse != null && !response.OperationResponse.IsOk)
                {
                    // Do something generic with this message
                }

                return response;
            }
            catch (Exception ex)
            {
                // we could also log here
                throw new Exception($"Failure to create and call handler of type {typeof(IHandler<THandlerRequest, THandlerResponse>)}", ex);
            }
        }
    }
}
using System;
using Microsoft.Practices.Unity;
using MyPegasus.Common.DataAccess.Database;
using MyPegasus.DataAccess.Database;
using MyPegasus.DataAccess.DeutscheBahnApi;
using MyPegasus.Web.Mappers;

namespace MyPegasus.Web.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public partial class UnityConfig
    {
        #region Unity Container
        private static readonly Lazy<IUnityContainer> Container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return Container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterInstance(typeof(IUnityContainer), container);
            container.RegisterWithPerRequestLifetime<IPegasusMapper, PegasusMapper>();

            RegisterHandlers(container);
            RegisterServices(container);
            RegisterRepositories(container);
            RegisterFactories(container);

            container.RegisterWithPerRequestLifetime<IDeutscheBahnApiClient, DeutscheBahnApiClient>();
            container.RegisterWithPerRequestLifetime<IPegasusContext, PegasusContext>();
            container.RegisterWithPerRequestLifetime<IUnitOfWork, PegasusContext>();
        }
    }
}

using System;
using System.Linq;
using Microsoft.Practices.Unity;
using MyPegasus.Common.DataAccess.Repositories;
using MyPegasus.Common.DomainModel.Factories;
using MyPegasus.Common.Framework;
using MyPegasus.DataAccess.Repositories;
using MyPegasus.DomainModel.Factories;
using MyPegasus.Web.Services;
using MyPegasus.Web.Services.Contracts;

namespace MyPegasus.Web.App_Start
{
    public partial class UnityConfig
    {
        public static void RegisterHandlers(IUnityContainer container)
        {
            var framework = AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => a.GetName().Name == "MyPegasus.Framework");

            var allHandlers = framework.SelectMany(s => s.GetTypes())
                .Where(m => m.IsClass && m.GetInterface("IHandler`2") != null);

            foreach (var handler in allHandlers)
            {
                var generics = handler.GetInterface("IHandler`2").GetGenericArguments();
                var requestType = generics[0];
                var responseType = generics[1];

                container.RegisterWithPerRequestLifetime((typeof (IHandler<,>).MakeGenericType(requestType, responseType)), handler);
            }
        }

        public static void RegisterServices(IUnityContainer container)
        {
            container.RegisterWithPerRequestLifetime<ICustomerService, CustomerService>();
            container.RegisterWithPerRequestLifetime<ITripService, TripService>();
            container.RegisterWithPerRequestLifetime<ITrainStationService, TrainStationService>();
        }

        public static void RegisterRepositories(IUnityContainer container)
        {
            container.RegisterWithPerRequestLifetime<ICustomerRepository, CustomerRepository>();
            container.RegisterWithPerRequestLifetime<ITripRepository, TripRepository>();
            container.RegisterWithPerRequestLifetime<ITrainStationRepository, TrainStationRepository>();
        }

        public static void RegisterFactories(IUnityContainer container)
        {
            container.RegisterWithPerRequestLifetime<ICustomerFactory, CustomerFactory>();
            container.RegisterWithPerRequestLifetime<ITripFactory, TripFactory>();
        }
    }

    public static class UnityExtensions
    {
        public static IUnityContainer RegisterWithPerRequestLifetime<TFrom, TTo>(this IUnityContainer value, params InjectionMember[] injectionMembers)
            where TTo : TFrom
        {
            return value.RegisterType<TFrom, TTo>(new PerRequestLifetimeManager(), injectionMembers);
        }

        public static IUnityContainer RegisterWithPerRequestLifetime(this IUnityContainer value, Type from, Type to, params InjectionMember[] injectionMembers)
        {
            return value.RegisterType(from, to, new PerRequestLifetimeManager(), injectionMembers);
        }
    }
}
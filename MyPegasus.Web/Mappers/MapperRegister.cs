using AutoMapper;
using MyPegasus.Common.DomainModel;
using MyPegasus.Common.DomainModel.Models;
using MyPegasus.Web.Models.Customer;
using MyPegasus.Web.Models.Trip;

namespace MyPegasus.Web.Mappers
{
    public class MapperRegister
    {
        public static void Register()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<ICustomer, CustomerViewModel>();
                cfg.CreateMap<ITrip, TripViewModel>();
            });
        }
    }
}
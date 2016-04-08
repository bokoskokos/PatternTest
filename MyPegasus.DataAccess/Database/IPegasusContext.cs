using System.Data.Entity;
using MyPegasus.DomainModel;
using MyPegasus.DomainModel.Models;

namespace MyPegasus.DataAccess.Database
{
    public interface IPegasusContext
    {
        DbSet<Trip> Trips { get; }
        DbSet<Customer> Customers { get; }
        IDbSet<Account> Users { get; }
    }
}

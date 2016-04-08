using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using MyPegasus.Common.DataAccess.Database;
using MyPegasus.DomainModel.Models;

namespace MyPegasus.DataAccess.Database
{
    public class PegasusContext : IdentityDbContext<Account, Account.GuidRole, Guid, Account.GuidUserLogin, Account.GuidUserRole, Account.GuidUserClaim>, IPegasusContext, IPegasusContextPersister
    {
        public Guid ThisIsMyId;

        public PegasusContext()
            : base("MyPegasus")
        {
            ThisIsMyId = Guid.NewGuid();
        }

        public static PegasusContext Create()
        {
            return new PegasusContext();
        }

        public DbSet<Trip> Trips { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public async Task SaveAsync()
        {
            await SaveChangesAsync();
        }
    }
}

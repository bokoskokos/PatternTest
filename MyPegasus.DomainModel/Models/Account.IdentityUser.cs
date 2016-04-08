using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MyPegasus.DomainModel.Models
{
    public sealed partial class Account : IdentityUser<Guid, Account.GuidUserLogin, Account.GuidUserRole, Account.GuidUserClaim>
    {
        public class GuidRole : IdentityRole<Guid, GuidUserRole>
        {
            public GuidRole()
            {
                Id = Guid.NewGuid();
            }
            public GuidRole(string name) : this() { Name = name; }
        }
        public class GuidUserRole : IdentityUserRole<Guid> { }
        public class GuidUserClaim : IdentityUserClaim<Guid> { }
        public class GuidUserLogin : IdentityUserLogin<Guid> { }

        private class GuidUserContext : IdentityDbContext<Account, GuidRole, Guid, GuidUserLogin, GuidUserRole, GuidUserClaim> { }
        public class GuidUserStore : UserStore<Account, GuidRole, Guid, GuidUserLogin, GuidUserRole, GuidUserClaim>
        {
            public GuidUserStore(DbContext context)
                : base(context)
            {
            }
        }
        private class GuidRoleStore : RoleStore<GuidRole, Guid, GuidUserRole>
        {
            public GuidRoleStore(DbContext context)
                : base(context)
            {
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Account, Guid> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

}

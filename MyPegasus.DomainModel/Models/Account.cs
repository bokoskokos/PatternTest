using System;
using System.ComponentModel.DataAnnotations;
using MyPegasus.Common.DomainModel;
using MyPegasus.Common.DomainModel.Enums;
using MyPegasus.Common.DomainModel.Models;

namespace MyPegasus.DomainModel.Models
{
    public sealed partial class Account : IAccount
    {
        // Keep protected for EF
        protected Account()
        {
        }

        public static Account Create(string firstName, string lastName, string email)
        {
            var account = new Account
            {
                FirstName = firstName,
                LastName = lastName,
                UserName = $"{firstName}.{lastName}",
                Email = email,
                Created = DateTimeOffset.UtcNow,
                Id = Guid.NewGuid(),
                Status = AccountStatus.Active
            };

            return account;
        }

        public DateTimeOffset Created { get; protected set; }

        public DateTimeOffset? Deleted { get; protected set; }

        [MaxLength(50)]
        public string FirstName { get; protected set; }

        [MaxLength(50)]
        public string LastName { get; protected set; }

        public AccountStatus Status { get; protected set; }
    }
}

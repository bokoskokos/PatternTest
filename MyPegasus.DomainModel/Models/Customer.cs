using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using MyPegasus.Common.Common;
using MyPegasus.Common.DomainModel.Models;

namespace MyPegasus.DomainModel.Models
{
    public class Customer : ICustomer
    {
        protected Customer()
        {
        }

        #region Factory

        public static async Task<IOperationResponse<Customer>> CreateAsync(string firstName, string lastName, string email, DateTimeOffset dateOfBirth)
        {
            return await Task.Run(() =>
            {
                if (string.IsNullOrEmpty(firstName))
                {
                    return OperationResponse<Customer>.Error("First name is required");
                }
                if (string.IsNullOrEmpty(lastName))
                {
                    return OperationResponse<Customer>.Error("Last name is required");
                }
                if (string.IsNullOrEmpty(email))
                {
                    return OperationResponse<Customer>.Error("Email is required");
                }
                if (dateOfBirth == default(DateTimeOffset))
                {
                    return OperationResponse<Customer>.Error("Date of Birth is required");
                }
                if (dateOfBirth > DateTimeOffset.UtcNow)
                {
                    return OperationResponse<Customer>.Error("Date of Birth is not valid");
                }

                var customer = new Customer
                {
                    Id = Guid.NewGuid(),
                    Created = DateTimeOffset.UtcNow,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    DateOfBirth = dateOfBirth
                };

                return OperationResponse<Customer>.Success(customer);
            });
        }

        #endregion

        #region Properties

        [Key]
        public Guid Id { get; protected set; }

        public DateTimeOffset Created { get; protected set; }

        public DateTimeOffset? Deleted { get; protected set; }

        [MaxLength(50)]
        public string FirstName { get; protected set; }

        [MaxLength(50)]
        public string LastName { get; protected set; }

        [MaxLength(50)]
        public string Email { get; protected set; }

        [MaxLength(50)]
        public string PhoneNumber { get; protected set; }

        public DateTimeOffset DateOfBirth { get; protected set; }

        #endregion

        #region Business Logic

        public IOperationResponse SetEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return OperationResponse.Error("Email must be provided");
            }
            if (!email.Contains("@"))
            {
                return OperationResponse.Error("Email is not valid");
            }

            Email = email;
            return OperationResponse.Success();
        }

        #endregion
    }
}

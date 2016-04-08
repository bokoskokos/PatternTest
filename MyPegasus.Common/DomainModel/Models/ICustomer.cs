using MyPegasus.Common.Common;

namespace MyPegasus.Common.DomainModel.Models
{
    public interface ICustomer : IDomainModel
    {
        string FirstName { get; }
        string LastName { get; }
        string Email { get; }
        string PhoneNumber { get; }

        IOperationResponse SetEmail(string email);
    }
}

using MyPegasus.Common.DomainModel.Enums;

namespace MyPegasus.Common.DomainModel.Models
{
    public interface IAccount : IDomainModel
    {
        string FirstName { get; }
        string LastName { get; }
        string Email { get; }
        AccountStatus Status { get; }
    }
}

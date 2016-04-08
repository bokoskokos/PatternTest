using System;

namespace MyPegasus.Common.DomainModel.Models
{
    public interface IDomainModel
    {
        Guid Id { get; }
        DateTimeOffset Created { get; }
        DateTimeOffset? Deleted { get; }
    }
}

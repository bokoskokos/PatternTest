using System.Collections.Generic;

namespace MyPegasus.Common.Web
{
    public interface ICurrentUser
    {
        int Id { get; }
        string Username { get; }
        string FirstName { get; }
        string LastName { get; }
        IEnumerable<string> Roles { get; }
    }
}

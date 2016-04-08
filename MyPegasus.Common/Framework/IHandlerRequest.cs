using MyPegasus.Common.Web;

namespace MyPegasus.Common.Framework
{
    public interface IHandlerRequest
    {
        ICurrentUser CurrentUser { get; }
    }
}

using MyPegasus.Common.Framework;
using MyPegasus.Common.Web;

namespace MyPegasus.Framework.HandlerRequests
{
    public class HandlerRequestBase : IHandlerRequest 
    {
        public ICurrentUser CurrentUser { get; set; }
    }
}

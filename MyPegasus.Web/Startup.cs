using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyPegasus.Web.Startup))]
namespace MyPegasus.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

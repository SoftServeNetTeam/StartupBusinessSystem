using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StartupBusinessSystem.Web.Startup))]
namespace StartupBusinessSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
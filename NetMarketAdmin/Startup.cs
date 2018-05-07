using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NetMarketAdmin.Startup))]
namespace NetMarketAdmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

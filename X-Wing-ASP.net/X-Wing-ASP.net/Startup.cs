using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(X_Wing_ASP.net.Startup))]
namespace X_Wing_ASP.net
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

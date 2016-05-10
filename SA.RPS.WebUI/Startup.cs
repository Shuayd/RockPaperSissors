using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SA.RPS.WebUI.Startup))]
namespace SA.RPS.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

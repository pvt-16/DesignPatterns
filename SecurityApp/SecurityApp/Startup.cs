using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SecurityApp.Startup))]
namespace SecurityApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SRP_GraphicalUI.Startup))]
namespace SRP_GraphicalUI
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

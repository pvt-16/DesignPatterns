using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DebuggerIIS.Startup))]
namespace DebuggerIIS
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

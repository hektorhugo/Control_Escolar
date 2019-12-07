using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ControlEscolar.Startup))]
namespace ControlEscolar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

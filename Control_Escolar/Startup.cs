using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Control_Escolar.Startup))]
namespace Control_Escolar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

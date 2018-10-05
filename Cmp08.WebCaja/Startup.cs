using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cmp08.WebCaja.Startup))]
namespace Cmp08.WebCaja
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cmp11.WebSistemas.Startup))]
namespace Cmp11.WebSistemas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

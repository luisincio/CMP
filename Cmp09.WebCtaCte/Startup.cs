using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cmp09.WebCtaCte.Startup))]
namespace Cmp09.WebCtaCte
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

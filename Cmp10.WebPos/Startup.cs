using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cmp10.WebPos.Startup))]
namespace Cmp10.WebPos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

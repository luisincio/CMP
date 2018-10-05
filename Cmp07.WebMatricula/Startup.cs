using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cmp07.WebMatricula.Startup))]
namespace Cmp07.WebMatricula
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

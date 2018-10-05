using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cmp06.WebPreMatricula.Startup))]
namespace Cmp06.WebPreMatricula
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

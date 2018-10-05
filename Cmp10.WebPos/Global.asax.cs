using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Cmp01.Utilities.Web;

namespace Cmp10.WebPos
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ModelMetadataProviders.Current = new EmptyStringDataAnnotations();
        }
    }
}

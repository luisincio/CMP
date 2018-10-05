using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Cmp01.Utilities.Web;
using Cmp08.WebCaja.Controllers;

namespace Cmp08.WebCaja
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

        protected void Application_Error(object sender, EventArgs e)
        {
            //Exception exception = Server.GetLastError();
            //Response.Clear();
            //HttpException httpException = exception as HttpException;
            //RouteData routeData = new RouteData();
            //routeData.Values.Add("controller", "Error");

            //if (httpException == null)
            //{
            //    routeData.Values.Add("action", "Index");
            //}
            //else //Es una excepción de Http, vamos a manejarlo.
            //{
            //    switch (httpException.GetHttpCode())
            //    {
            //        case 404: //Página no encontrada.
            //            routeData.Values.Add("action", "HttpError404");
            //            break;
            //        case 500: //Error del Servidor.
            //            routeData.Values.Add("action", "HttpError500");
            //            break;
            //        default: //Aquí puede manejar Vistas a otros códigos de error.
            //            routeData.Values.Add("action", "General");
            //            break;
            //    }
            //}
            ////Pasa los detalles de la excepción al error de destino Vista.
            //routeData.Values.Add("error", exception);

            ////Borrar el error en el servidor.
            //Server.ClearError();

            ////Evite que IIS7 se meta en el medio
            //Response.TrySkipIisCustomErrors = true;

            ////Llame al controlador de destino y pase la ruta de datos.
            //IController errorController = new ErrorController();
            //errorController.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
        }
    }
}

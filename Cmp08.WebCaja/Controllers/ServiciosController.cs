#region Espacios de Nombres
using Cmp02.Entities;
using Cmp04.BusinessLogic;
using System.Collections.Generic;
using System.Web.Mvc;
#endregion

namespace Cmp08.WebCaja.Controllers
{
    [Authorize]
    [SessionExpire]
    [OutputCache(NoStore = true, Duration = 0)]
    public class ServiciosController : Controller
    {
        #region Servicios para comprobante de ventas

        public ActionResult BuscarModal()
        {
            return PartialView("_BuscarModal");
        }

        public JsonResult BuscarJSON(string vDescripcion, int origen=0, string documento="",string TipoArticulo="")
        {
            //List<Articulo> lista = new Articulo_LN().List_Articulo_SinCuota("VENTA", vDescripcion, AppSession.Usuario.Consejo_Regional.Substring(4, 2)); 
            List<Articulo> lista = new Articulo_LN().List_Articulo_SinCuota("VENTA", vDescripcion, "", origen,documento, TipoArticulo);
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Servicios para recibos de caja

        public ActionResult ServiciosRecibo()
        {
            return PartialView("_ServiciosRecibo");
        }

        public JsonResult BuscarServiciosRecibo(string vDescripcion)
        {
            //List<Tb_Servicios> lista = new Tb_Servicios_LN().List(vDescripcion);
            //List<Articulo> lista = new Articulo_LN().List_Articulo("VENTA", vDescripcion, AppSession.Usuario.Consejo_Regional.Substring(4, 2));
            List<Articulo> lista = new Articulo_LN().List_Articulo("VENTA", vDescripcion, "");
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Mantenimiento de recibo

        public ActionResult Listar()
        {
            if (Request.IsAjaxRequest()) return PartialView("_Detalle", new Tb_Servicios_LN().List(""));
            return View(new Tb_Servicios_LN().List(""));
        }

        public ActionResult Editar()
        {
            return PartialView("_EditarServicio", new Tb_Servicios());
        }

        public ActionResult EditarOpciones()
        {
            return PartialView("_EditarOpciones", new Tb_Servicios());
        }

        #endregion
    }
}
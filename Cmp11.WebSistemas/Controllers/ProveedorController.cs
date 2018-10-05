using Cmp02.Entities;
using Cmp04.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cmp11.WebSistemas.Controllers
{
    [Authorize]
    [SessionExpire]
    [OutputCache(NoStore = true, Duration = 0)]
    public class ProveedorController : Controller
    {
        Proveedor_LN vObj = new Proveedor_LN();
        public ActionResult Listar(string vNombre)
        {
            if (Request.IsAjaxRequest()) return PartialView("_Detalle", vObj.List(vNombre));
            return View(vObj.List(vNombre));
        }

        public ActionResult Editar(string vRuc = "")
        {
            ViewBag.LstDocumento = vObj.List_TipoDocProveedor();
            ViewBag.LstTipoPersona = vObj.List_TipoPersona();
            if (vRuc.Trim().Length > 0) return PartialView("_EditarProveedor", vObj.List(vRuc.Trim())[0]);
            return PartialView("_EditarProveedor", new Proveedores());
        }

        [HttpPost]
        public ActionResult Editar(Proveedores vProveedor)
        {
            //.Usu_Modifica = AppSession.Usuario.Usuario;
            vObj.Grabar(vProveedor);
            return RedirectToAction("Listar", "Proveedor", new { vNombre = vProveedor.NroDocumento });
            //return PartialView("_EditarProveedor", vProveedor);
        }

        //public ActionResult Editar()
        //{
        //    return PartialView("_EditarProveedor", new Tb_Servicios());
        //}

        public ActionResult EditarDireccion()
        {
            return PartialView("_EditarDireccion", new Tb_Servicios());
        }

        public ActionResult EditarOpciones()
        {
            return PartialView("_EditarOpciones", new Tb_Servicios());
        }

        public ActionResult Buscar(string vNombre = "FULLSITO")
        {
            if (vNombre == "FULLSITO")
                return PartialView("_BuscarProveedor", new Orden_Compra_LN().List_Proveedor(vNombre));
            else
                return PartialView("_BuscarProveedorDetalle", new Orden_Compra_LN().List_Proveedor(vNombre));
        }
	}
}
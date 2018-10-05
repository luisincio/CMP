#region Espacios de Nombres
using Cmp02.Entities;
using Cmp04.BusinessLogic;
using Cmp01.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
#endregion

namespace Cmp11.WebSistemas.Controllers
{
    [Authorize]
    [SessionExpire]
    [OutputCache(NoStore = true, Duration = 0)]
    public class CorrelativoController : Controller
    {
        Tb_Correlativos_LN oParametro = new Tb_Correlativos_LN();
        public ActionResult Listar(int vId_Sucursal = 0, int vId_Tidodocumento = 0)
        {
            var Temp = oParametro.List(vId_Sucursal, vId_Tidodocumento, 0);
            ViewBag.LstTipoDocumento = new Tb_Maestras_LN().List(EnumMaestras.TIPO_DOCUMENTOSUNAT);
            ViewBag.LstConsejo = new Tb_Maestras_LN().List(EnumMaestras.CONSEJO_REGIONAL);
            if (Request.IsAjaxRequest()) return PartialView("_Detalle", Temp);
            return View(Temp);
        }

        public ActionResult Editar(int vId_Sucursal, int vId_Tidodocumento, int vSerie)
        {
            ViewBag.LstTipoDocumento = new Tb_Maestras_LN().List(EnumMaestras.TIPO_DOCUMENTOSUNAT);
            ViewBag.LstConsejo = new Tb_Maestras_LN().List(EnumMaestras.CONSEJO_REGIONAL);
            return PartialView("_EditarCorrelativo", oParametro.GetRegistry(vId_Sucursal, vId_Tidodocumento, vSerie));
        }

        //
        // POST: /Parametro/Create
        [HttpPost]
        public ActionResult Editar(Tb_Correlativos vParametro)
        {
            vParametro.Usu_Ingreso = vParametro.Usu_Modifica = AppSession.Usuario.Usuario;

            if (ModelState.IsValid)
            {
                if (vParametro.Accion)
                    oParametro.Insert(vParametro);
                else
                    oParametro.Update(vParametro);
            }
            ViewBag.LstTipoDocumento = new Tb_Maestras_LN().List(EnumMaestras.TIPO_DOCUMENTOSUNAT);
            ViewBag.LstConsejo = new Tb_Maestras_LN().List(EnumMaestras.CONSEJO_REGIONAL);
            return PartialView("_EditarCorrelativo2", vParametro);
        }

        public ActionResult Eliminar(int vId_Sucursal, int vId_Tidodocumento, int vSerie)
        {
            return Json(oParametro.Delete(vId_Sucursal, vId_Tidodocumento, vSerie, AppSession.Usuario.Usuario, Variables.Hoy), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Asociacion(int vId_Sucursal, int vId_Tidodocumento, int vSerie)
        {
            ViewBag.LstTipoDocumento = new Tb_Maestras_LN().List(EnumMaestras.TIPO_DOCUMENTOSUNAT);
            ViewBag.LstConsejo = new Tb_Maestras_LN().List(EnumMaestras.CONSEJO_REGIONAL);
            var vTemp = oParametro.GetRegistry(vId_Sucursal, vId_Tidodocumento, vSerie);
            vTemp.Opcional = "";
            return PartialView("_AsignarUsuario", oParametro.GetRegistry(vId_Sucursal, vId_Tidodocumento, vSerie));
        }

        [HttpPost]
        public ActionResult Asociacion(Tb_Correlativos vParametro)
        {
            ViewBag.LstTipoDocumento = new Tb_Maestras_LN().List(EnumMaestras.TIPO_DOCUMENTOSUNAT);
            ViewBag.LstConsejo = new Tb_Maestras_LN().List(EnumMaestras.CONSEJO_REGIONAL);
            var Temp = oParametro.GetRegistry(vParametro.Id_Sucursal, vParametro.Id_Tidodocumento, vParametro.Serie);
            Temp.Id_Persona = vParametro.Id_Persona;
            Temp.Usu_Ingreso = Temp.Usu_Modifica = AppSession.Usuario.Usuario;
            Temp = oParametro.Update(Temp);
            return PartialView("_AsignarUsuario2", Temp);
        }
    }
}

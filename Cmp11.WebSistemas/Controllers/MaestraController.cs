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
    public class MaestraController : Controller
    {
        Tb_Maestras_LN oMaestra = new Tb_Maestras_LN();

        #region Mantenimiento de Padres

        public ActionResult Listar(string vValor)
        {
            var Temp = oMaestra.Lista(vValor);
            if (Request.IsAjaxRequest()) return PartialView("_Detalle", Temp);
            return View(Temp);
        }

        public ActionResult Editar(int vId)
        {
            return PartialView("_EditarMaestra", oMaestra.GetRegistry(vId));
        }

        [HttpPost]
        public ActionResult Editar(Tb_Maestras vMaestra)
        {
            vMaestra.Usu_Ingreso = vMaestra.Usu_Modifica = AppSession.Usuario.Usuario;
            if (ModelState.IsValid) oMaestra.Grabar(vMaestra);
            return PartialView("_EditarMaestra2", vMaestra);
        }

        public ActionResult Eliminar(int vId)
        {
            return Json(oMaestra.Delete(vId, AppSession.Usuario.Usuario, Variables.Hoy), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Mantenimiento de Padres

        public ActionResult ListarHijo(string vValor, int vPadre = 9999999)
        {
            var Temp = oMaestra.Lista(vValor, vPadre);
            if (Request.IsAjaxRequest()) return PartialView("_DetalleHijo", Temp);
            return View(Temp);
        }

        public ActionResult EditarHijo(int vId, int vPadre)
        {
            var vTemp = oMaestra.GetRegistry(vId);
            vTemp.Id_General = vPadre;
            return PartialView("_EditarMaestraHijo", vTemp);
        }

        [HttpPost]
        public ActionResult EditarHijo(Tb_Maestras vMaestra)
        {
            vMaestra.Usu_Ingreso = vMaestra.Usu_Modifica = AppSession.Usuario.Usuario;
            if (ModelState.IsValid) oMaestra.Grabar(vMaestra);
            return PartialView("_EditarMaestraHijo2", vMaestra);
        }

        public ActionResult EliminarHijo(int vId)
        {
            return Json(oMaestra.Delete(vId, AppSession.Usuario.Usuario, Variables.Hoy), JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}

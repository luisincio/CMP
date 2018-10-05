#region Espacios de Nombres
using Cmp02.Entities;
using Cmp04.BusinessLogic;
using Cmp01.Utilities;
using System;
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
    public class PermisoController : Controller
    {
        Tb_Permiso_LN oPermiso = new Tb_Permiso_LN();
        public ActionResult Listar(string vValor)
        {
            var Temp = oPermiso.List(vValor);
            if (Request.IsAjaxRequest()) return PartialView("_Detalle", Temp);
            return View(Temp);
        }

        public ActionResult Editar(int vId)
        {
            return PartialView("_EditarPermiso", oPermiso.GetRegistry(vId));
        }

        [HttpPost]
        public ActionResult Editar(Tb_Permiso vPermiso)
        {
            vPermiso.Usu_Ingreso = vPermiso.Usu_Modifica = AppSession.Usuario.Usuario;


            if (ModelState.IsValid)
            {
                oPermiso.Grabar(vPermiso);
            }

            return PartialView("_EditarPermiso2", vPermiso);
        }

        public ActionResult Eliminar(int vId)
        {
            return Json(oPermiso.Delete(vId, AppSession.Usuario.Usuario, Variables.Hoy), JsonRequestBehavior.AllowGet);
        }

        public ActionResult PerfilPermisos(int vId_Perfil)
        {
            ViewBag.Perfil = vId_Perfil;
            ViewBag.LstPerfil = new Tb_Perfil_LN().List();
            var Temp = oPermiso.List("", vId_Perfil);
            if (Request.IsAjaxRequest()) return PartialView("_DetallePerfil", Temp);
            return View(Temp);
        }

        public ActionResult GuardarPermisos(int vId_Perfil, string vPermisos)
        {
            try
            {
                if (string.IsNullOrEmpty(vPermisos))
                {
                    return Json(new { rpta = "0", mensaje = "Debe seleccionar al menos un permiso" }, JsonRequestBehavior.AllowGet);
                }

                if (vId_Perfil <= 0)
                {
                    return Json(new { rpta = "0", mensaje = "No se ha seleccionado un perfil" }, JsonRequestBehavior.AllowGet);
                }

                new Tb_Perfilpermiso_LN().Grabar(vId_Perfil, vPermisos, AppSession.Usuario.Usuario);
                return Json(new { rpta = "1" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { rpta = "0", mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}

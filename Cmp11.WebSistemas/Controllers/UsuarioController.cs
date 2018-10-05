#region Espacios de Nombres
using Cmp02.Entities;
using Cmp04.BusinessLogic;
using Cmp01.Utilities;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System.Web;
#endregion

namespace Cmp11.WebSistemas.Controllers
{
    [Authorize]
    [SessionExpire]
    [OutputCache(NoStore = true, Duration = 0)]
    public class UsuarioController : Controller
    {
        Tb_Usuario_LN oUsuario = new Tb_Usuario_LN();
        public ActionResult Listar(string vValor)
        {
            var Temp = oUsuario.List(vValor);
            if (Request.IsAjaxRequest()) return PartialView("_Detalle", Temp);
            return View(Temp);
        }

        public ActionResult Editar(int vId)
        {
            ViewBag.LstConsejo = new Tb_Maestras_LN().List(EnumMaestras.CONSEJO_REGIONAL);
            return PartialView("_EditarUsuario", oUsuario.GetRegistry(vId));
        }


        [HttpPost]
        public ActionResult Editar(Tb_Usuario vUsuario)
        {
            vUsuario.Usu_Ingreso = vUsuario.Usu_Modifica = AppSession.Usuario.Usuario;
            if (vUsuario.Confirmacion == vUsuario.Contraseña)
            {
                if (ModelState.IsValid) oUsuario.Grabar(vUsuario);
            }
            else
            {
                vUsuario.Opcional = "PASS";
            }
            ViewBag.LstConsejo = new Tb_Maestras_LN().List(EnumMaestras.CONSEJO_REGIONAL);
            return PartialView("_EditarUsuario", vUsuario);
        }

        public ActionResult Eliminar(int vId)
        {
            return Json(oUsuario.Delete(vId, AppSession.Usuario.Usuario, Variables.Hoy), JsonRequestBehavior.AllowGet);
        }

        public ActionResult BuscarUsuario(string vNumero)
        {
            var vTemp = new Tb_Persona_Natural_LN().GetRegistry(0, vNumero);
            return Json(vTemp, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AsignarPerfil(int vId)
        {
            ViewBag.LstPerfil = new Tb_Perfil_LN().List();
            return PartialView("_AsignarPerfil", oUsuario.GetRegistry_Perfil(vId));
        }

        public ActionResult GuardarPerfil(int vId,int vIdPerfil)
        {
            var vTemp = new Tb_Perfilusuario_LN().Grabar(vId,vIdPerfil,AppSession.Usuario.Usuario);
            return Json(vTemp, JsonRequestBehavior.AllowGet);
        }
	}
}
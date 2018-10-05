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
    public class PerfilController : Controller
    {

        Tb_Perfil_LN oPerfil = new Tb_Perfil_LN();
        public ActionResult Listar(string vValor)
        {
            var Temp = oPerfil.List(vValor);
            if (Request.IsAjaxRequest()) return PartialView("_Detalle", Temp);
            return View(Temp);
        }

        public ActionResult Editar(int vId)
        {
            return PartialView("_EditarPerfil", oPerfil.GetRegistry(vId));
        }


        [HttpPost]
        public ActionResult Editar(Tb_Perfil vPerfil)
        {
            vPerfil.Usu_Ingreso = vPerfil.Usu_Modifica = AppSession.Usuario.Usuario;

            
                if (ModelState.IsValid)
                {
                    oPerfil.Grabar(vPerfil);
                }

                return PartialView("_EditarPerfil2", vPerfil);
        }

        public ActionResult Eliminar(int vId)
        {
            return Json(oPerfil.Delete(vId, AppSession.Usuario.Usuario, Variables.Hoy), JsonRequestBehavior.AllowGet);
        }

    }
}

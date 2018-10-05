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
    public class ParametroController : Controller
    {
         Tb_Parametro_LN oParametro = new Tb_Parametro_LN();
         public ActionResult Listar(string vValor)
        {
            var Temp = oParametro.List(vValor);
            if (Request.IsAjaxRequest()) return PartialView("_Detalle", Temp);
            return View(Temp);
        }

        public ActionResult Editar(int vId)
        {
            return PartialView("_EditarParametro", oParametro.GetRegistry(vId));
        }

        //
        // POST: /Parametro/Create
        [HttpPost]
        public ActionResult Editar(Tb_Parametro vParametro)
        {
            vParametro.Usu_Ingreso = vParametro.Usu_Modifica = AppSession.Usuario.Usuario;


            if (ModelState.IsValid)
            {
                oParametro.Grabar(vParametro);
            }

            return PartialView("_EditarParametro2", vParametro);
        }

        public ActionResult Eliminar(int vId)
        {
            return Json(oParametro.Delete(vId, AppSession.Usuario.Usuario, Variables.Hoy), JsonRequestBehavior.AllowGet);
        }
    }
}

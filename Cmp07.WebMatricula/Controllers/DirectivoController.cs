#region Espacios de Nombres
using Cmp02.Entities;
using Cmp04.BusinessLogic;
using Cmp01.Utilities;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
#endregion

namespace Cmp07.WebMatricula.Controllers
{
    [Authorize]
    [SessionExpire]
    [OutputCache(NoStore = true, Duration = 0)]
    public class DirectivoController : Controller
    {

        Tb_Persona_Directivo_LN oDirectivo = new Tb_Persona_Directivo_LN();

        public ActionResult Listar(int vConsejo = 0, string vPeriodo = "")
        {
            ViewBag.LstConsejo = new Tb_Maestras_LN().List(EnumMaestras.CONSEJO_REGIONAL);
            ViewBag.LstPeriodo = new Tb_Maestras_LN().ListPeriodo();
            var vTemp = oDirectivo.List(vConsejo, vPeriodo);
            if (Request.IsAjaxRequest()) return PartialView("_Detalle", vTemp);
            return View(vTemp);
        }

        public ActionResult Editar(int vId)
        {
            ViewBag.LstConsejo = new Tb_Maestras_LN().List(EnumMaestras.CONSEJO_REGIONAL);
            ViewBag.LstCargos = new Tb_Maestras_LN().List(EnumMaestras.CARGOS_DIRECTIVOS_CMP);
            ViewBag.LstPeriodo = new Tb_Maestras_LN().ListPeriodo();
            return PartialView("_Editar", oDirectivo.GetRegistry(vId));
        }


        [HttpPost]
        public ActionResult Editar(Tb_Persona_Directivo vDirectivo)
        {
            vDirectivo.Usu_Ingreso = vDirectivo.Usu_Modifica = AppSession.Usuario.Usuario;
            if (ModelState.IsValid) vDirectivo = oDirectivo.Save(vDirectivo);

            ViewBag.LstConsejo = new Tb_Maestras_LN().List(EnumMaestras.CONSEJO_REGIONAL);
            ViewBag.LstCargos = new Tb_Maestras_LN().List(EnumMaestras.CARGOS_DIRECTIVOS_CMP);
            ViewBag.LstPeriodo = new Tb_Maestras_LN().ListPeriodo();

            return PartialView("_Editar", vDirectivo);
        }

        public ActionResult Eliminar(int vId)
        {
            return Json(oDirectivo.Delete(vId, AppSession.Usuario.Usuario), JsonRequestBehavior.AllowGet);
        }

        public ActionResult BuscarMedico(string vNumero)
        {
            var vTemp = new Tb_Persona_Natural_LN().GetRegistry(vNumero);
            return Json(vTemp, JsonRequestBehavior.AllowGet);
        }

    }
}
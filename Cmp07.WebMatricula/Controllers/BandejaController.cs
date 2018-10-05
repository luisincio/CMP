#region Espacios de Nombres
using Cmp02.Entities;
using Cmp04.BusinessLogic;
using System.Web.Mvc;
using System.Linq;
using Cmp01.Utilities;
using System;
#endregion

namespace Cmp07.WebMatricula.Controllers
{
    [Authorize]
    [SessionExpire]
    [OutputCache(NoStore = true, Duration = 0)]
    public class BandejaController : Controller
    {
        public ActionResult Listar(string vNombre, int? vEstado = (int)EnumEstado.PRE_EVALUACION, int vConsejo = 0)
        {
            ViewBag.LstConsejo = new Tb_Maestras_LN().List(EnumMaestras.CONSEJO_REGIONAL);
            var Temporal = new Tb_Maestras_LN().List(EnumMaestras.ESTADO_MATRICULA);
            Temporal.Add(new Tb_Maestras() { Id_Maestras = 0, Descripcion = "TODOS" });
            ViewBag.LstEstado = Temporal;

            var Temp = new Tb_Persona_LN().List_Bandeja(vNombre, (int)vEstado, vConsejo );
            if (Request.IsAjaxRequest()) return PartialView("_Detalle", Temp);
            return View(Temp);
        }

        public ActionResult Carnets(string vNombre, int vConsejo = 0)
        {
            ViewBag.LstConsejo = new Tb_Maestras_LN().List(EnumMaestras.CONSEJO_REGIONAL);
            var Temp = new Tb_Persona_LN().List_Carnets(vNombre, vConsejo);
            if (Request.IsAjaxRequest()) return PartialView("_DetalleCarnets", Temp);
            return View(Temp);
        }

        public ActionResult ListarAuxiliar(string vNombre, int vConsejo = 0)
        {
            ViewBag.LstConsejo = new Tb_Maestras_LN().List(EnumMaestras.CONSEJO_REGIONAL);
            var Temp = new Tb_Persona_LN().List_Bandeja(vNombre, (int)EnumEstado.ACTIVO, vConsejo);
            if (Request.IsAjaxRequest()) return PartialView("_DetalleAx", Temp);
            return View(Temp);
        }

        public ActionResult EmitirCarnet(int vId_Carnet, bool vAccion)
        {
            var Temp = new Tb_Colegiado_Carnet_LN().Actualizar_Emision(vId_Carnet, vAccion, AppSession.Usuario.Usuario).ToShortDateString();
            return Json((Temp.Length > 0 && vAccion == true)?Temp:"", JsonRequestBehavior.AllowGet);
        }

        public ActionResult EntregarCarnet(int vId_Carnet, bool vAccion)
        {
            var Temp = new Tb_Colegiado_Carnet_LN().Actualizar_Entrega(vId_Carnet, vAccion, AppSession.Usuario.Usuario).ToShortDateString();
            return Json((Temp.Length > 0 && vAccion == true) ? Temp : "", JsonRequestBehavior.AllowGet);
        }

        public ActionResult ListarDesabilitados(string vNombre, int? vEstado = 0, int vConsejo = 0, string vFecha = "")
        {
            ViewBag.LstConsejo = new Tb_Maestras_LN().List(EnumMaestras.CONSEJO_REGIONAL);
            //var Temporal = new Tb_Maestras_LN().List(EnumMaestras.ESTADO_MATRICULA).Where(x => x.Id_Maestras != (int)EnumEstadoMatricula.ACTIVO && x.Id_Maestras != (int)EnumEstadoMatricula.CANCELADO && x.Id_Maestras != (int)EnumEstadoMatricula.PRE_EVALUACION && x.Id_Maestras != (int)EnumEstadoMatricula.EXPULSADO && x.Id_Maestras != (int)EnumEstadoMatricula.FALLECIDO && x.Id_Maestras != (int)EnumEstadoMatricula.INACTIVO).ToList();
            var Temporal = new Tb_Maestras_LN().List(EnumMaestras.ESTADO_MATRICULA).Where(x => x.Id_Maestras == (int)EnumEstadoMatricula.INHABILITADO_TEMPORAL || x.Id_Maestras == (int)EnumEstadoMatricula.SUSPENDIDO).ToList();
            Temporal.Insert(0, new Tb_Maestras() { Id_Maestras = 0, Descripcion = "TODOS" });
            ViewBag.LstEstado = Temporal;
            if (vFecha.Length == 0) vFecha = Variables.Hoy.AddDays(1).ToShortDateString();
            var Temp = new Tb_Persona_LN().List_Inactivos(vNombre, (int)vEstado, vConsejo, Convert.ToDateTime(vFecha));
            if (Request.IsAjaxRequest()) return PartialView("_DetalleDesabilitado", Temp);
            return View(Temp);
        }

        public ActionResult ActivarColegiados(string vIds)
        {
            if (vIds.Trim().Length == 0) return Json("2", JsonRequestBehavior.AllowGet);
            return Json((new Tb_Persona_Natural_LN().Activar_Colegiados(vIds, AppSession.Usuario.Usuario)) ? "1" : "0", JsonRequestBehavior.AllowGet);
        }

	}
}
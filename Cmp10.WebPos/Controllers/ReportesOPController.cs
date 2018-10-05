#region Espacios de Nombres
using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
#endregion

namespace Cmp10.WebPos.Controllers
{
    [Authorize]
    [SessionExpire]
    [OutputCache(NoStore = true, Duration = 0)]
    public class ReportesOPController : Controller
    {
        [HttpGet, ValidateInput(false)]
        public ActionResult Reportador(int vTipo = 1)
        {
            ViewBag.Tipo = vTipo;
            return View();
        }

        [HttpGet, ValidateInput(false)]
        public ActionResult EnviarLista(string vFecRegInicial="", string vFecRegFinal="", int vTipo = 1)
        {
            if  (vFecRegInicial != "" || vFecRegFinal != "")
            {
                string parametros = "FecIni," + vFecRegInicial + "|FecFin," + vFecRegFinal + "|idConsejo," + AppSession.Usuario.Id_Consejo_Regional.ToString();
                ViewBag.Tipo = vTipo;
                switch (vTipo)
                {
                    case 1: ViewBag.Url = Utildatatool.HelperReportView.Buildreport("RegistroVentasIngresosConsejo", parametros); break;
                    case 2: ViewBag.Url = Utildatatool.HelperReportView.Buildreport("RegistroComprasConsejo", parametros); break;
                    case 3: ViewBag.Url = Utildatatool.HelperReportView.Buildreport("LibroDiarioConsejo", parametros); break;
                    default: ViewBag.Url = Utildatatool.HelperReportView.Buildreport("LibroMayorConsejo", parametros); break;
                }
            }
            return PartialView("_FullDetail");
        }
	}
}
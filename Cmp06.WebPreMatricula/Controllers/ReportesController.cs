using Cmp04.BusinessLogic;
using Cmp01.Utilities;
using System;
using System.Web.Mvc;

namespace Cmp06.WebPreMatricula.Controllers
{
    [Authorize]
    [SessionExpire]
    [OutputCache(NoStore = true, Duration = 0)]
    public class ReportesController : Controller
    {
        public ActionResult ImprimirFicha(int vId = 1)
        {
            string parametros = "ID_PERSONA," + vId;
            ViewBag.Url = Utildatatool.HelperReportView.Buildreport("rpt_FichaMatricula", parametros);
            return PartialView("_FullPrinter");
        }

        public ActionResult ImprimirFichaInterna(int vId = 1)
        {
            string parametros = "ID_PERSONA," + vId;
            ViewBag.Url = Utildatatool.HelperReportView.Buildreport("rpt_FichaMatriculaExt", parametros);
            return PartialView("_FullPrinter");
        }

        public ActionResult ImprimirDiploma(int vId = 1)
        {
            string parametros = "ID_ESPECIALIDAD," + vId;
            ViewBag.Url = Utildatatool.HelperReportView.Buildreport("rpt_Diploma", parametros);
            return PartialView("_FullPrinter");
        }

        public ActionResult ImprimirGraduado(int vId = 1)
        {
            string parametros = "ID_PERSONA," + vId;
            ViewBag.Url = Utildatatool.HelperReportView.Buildreport("rpt_Graduado", parametros);
            return PartialView("_FullPrinter");

            //string parametros = "ID_ESPECIALIDAD," + vId;
            //ViewBag.Url = Utildatatool.HelperReportView.Buildreport("rpt_Graduado", parametros);
            //return PartialView("_FullPrinter");
        }

        public ActionResult ImprimirCarnet(string vId)
        {
            int vCount = vId.Split('$').Length;
            if (vCount < 10) for (int i = vCount; i <= 10; i++) vId = vId + "0$";
            string parametros = "ID_PERSONA," + vId;
            ViewBag.Url = Utildatatool.HelperReportView.Buildreport("rpt_FullCarnet", parametros);
            return PartialView("_FullPrinter");
        }

        public ActionResult ImprimirCarnetAtras(string vId)
        {
            int vCount = vId.Split('$').Length;
            if (vCount < 10) for (int i = vCount; i <= 10; i++) vId = vId + "0$";
            string parametros = "ID_PERSONA," + vId;
            ViewBag.Url = Utildatatool.HelperReportView.Buildreport("rpt_FullCarnetAtras", parametros);
            return PartialView("_FullPrinter");
        }

        public ActionResult ImprimirRecibo(string vId)
        {
            string parametros = "ID_COMPROBANTE," + vId;
            ViewBag.Url = Utildatatool.HelperReportView.Buildreport("rpt_ReciboCaja", parametros);
            return PartialView("_FullPrinter");
        }

        public ActionResult ImprimirFactura(string vId)
        {
            string parametros = "ID_COMPROBANTE," + vId;

            if (new Tb_Comprobantecabecera_LN().GetRegistry(Convert.ToInt32(vId)).Tipo_Documentosunat == (int)EnumTipoDocSunat.BOLETA)
                ViewBag.Url = Utildatatool.HelperReportView.Buildreport("rpt_BoletaCaja", parametros);
            else
                ViewBag.Url = Utildatatool.HelperReportView.Buildreport("rpt_FacturaCaja", parametros);

            return PartialView("_FullPrinter");
        }

        public ActionResult HistoriaEstadoCuenta(string vFiltro)
        {
            string parametros = "FILTRO," + vFiltro;
            ViewBag.Url = Utildatatool.HelperReportView.Buildreport("rpt_EstadoCC", parametros);
            return PartialView("_FullPrinter");
        }

        public ActionResult ImprimirConstanciaEspecialidad(int vId = 1)
        {
            string parametros = "ID_ESPECIALIDAD," + vId;
            ViewBag.Url = Utildatatool.HelperReportView.Buildreport("rpt_ConstanciaEspecialidad", parametros);
            return PartialView("_FullPrinter");
        }
        
    }
}
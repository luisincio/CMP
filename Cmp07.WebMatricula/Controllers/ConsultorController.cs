#region Espacios de Nombres
using Cmp04.BusinessLogic;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using Cmp01.Utilities;
#endregion

namespace Cmp07.WebMatricula.Controllers
{
    [Authorize]
    [SessionExpire]
    [OutputCache(NoStore = true, Duration = 0)]
    public class ConsultorController : Controller
    {
        public ActionResult Listar()
        {
            ViewBag.LstEstadoCivil = new Tb_Maestras_LN().List(EnumMaestras.ESTADO_CIVIL);
            ViewBag.LstSexo = new Tb_Maestras_LN().List(EnumMaestras.GENERO);
            ViewBag.LstConsejo = new Tb_Maestras_LN().List(EnumMaestras.CONSEJO_REGIONAL);
            ViewBag.LstEstadosCMP = new Tb_Maestras_LN().List(EnumMaestras.ESTADO_MATRICULA);
            ViewBag.LstTipoDocumento = new Tb_Maestras_LN().List(EnumMaestras.TIPO_DOCUMENTO);
            ViewBag.LstEspecialidad = new Tb_Maestras_LN().List(EnumMaestras.TIPO_ESPECIALIDAD);
            return View();
        }

        public ActionResult EnviarLista(int vEstadoCivil=0, string vCodCmpInicial="", string vCodCmpFinal=""
            , string vSexo = "", string vFullConsejos = "", string vFecCmpInicial = "", string vFecCmpFinal = ""
            , string vFullEstados = "", string vFullTiposDocumentos = "", int vEdadInicial = 0, int vEdadFinal = 0
            , string vAnioIniFallecido = "", string vAnioFinFallecido = ""
            , string vFecRegInicial="", string vFecRegFinal="", string vUbigeo="", string vUniversidad=""
            , string vNombre = "", string vFullEspecialidad = "")
        {
            vSexo = (vSexo == "43") ? "F" : (vSexo == "44")? "M": "";
            string parametros = "ID_TIPO_ESTADO_CIVIL," + vEstadoCivil + "|CMP_INICIAL," + vCodCmpInicial +
                "|CMP_FINAL," + vCodCmpFinal + "|SEXO," + vSexo + "|ID_CONSEJOS," + vFullConsejos +
                "|FEC_CMPINICIAL," + vFecCmpInicial + "|FEC_CMPFINAL," + vFecCmpFinal + "|ID_CMPESTADOS," + vFullEstados +
                "|ID_TIPODOCUMENTOS," + vFullTiposDocumentos + "|EDAD_INICIAL," + vEdadInicial + "|EDAD_FINAL," + vEdadFinal +
                "|REGISTRO_INICIAL," + vFecRegInicial + "|REGISTRO_FINAL," + vFecRegFinal + "|UBICACION_GEOGRAFICA," + vUbigeo +
                "|UNIVERSIDAD," + vUniversidad + "|NOMBRE_COMPLETO," + vNombre +
                "|FEC_MURIOINICIAL," + vAnioIniFallecido + "|FEC_MURIOFINAL," + vAnioFinFallecido +
                "|ID_ESPECIALIDADES," + vFullEspecialidad
                ;
            //string parametros = "@ID_TIPO_ESTADO_CIVIL," + vEstadoCivil;
            ViewBag.Url = Utildatatool.HelperReportView.Buildreport("rpt_FullConsultor", parametros);
            return PartialView("_FullDetail");
        }
	}
}
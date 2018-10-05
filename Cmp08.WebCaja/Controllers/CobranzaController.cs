#region Espacios de Nombres
using Cmp02.Entities;
using Cmp04.BusinessLogic;
using Cmp01.Utilities;
using Excel;
using FileHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using Cmp08.WebCaja.Models;
#endregion

namespace Cmp08.WebCaja.Controllers
{
    [Authorize]
    [SessionExpire]
    [OutputCache(NoStore = true, Duration = 0)]
    public class CobranzaController : Controller
    {
        #region Pagos Locales
        public ActionResult Listar(string vValor, int vTipo = 0)
        {
            if (Request.IsAjaxRequest()) return PartialView("_Detalle", new Tb_Cobranza_LN().List(vValor, vTipo));
            return View(new Tb_Cobranza_LN().List(vValor, vTipo));
        }

        public ActionResult Procesar_Pago_Local(string vIds)
        {
            int vId_Comprobante = 0;
            string[] vParams = vIds.Split(',');
            //foreach (string vId in vParams)
            //{
            //    vId_Comprobante = Convert.ToInt32(new Tb_Cobranza_LN().GetRegistry(Convert.ToInt32(vId)).Id_Comprobante);
            //    if (vId_Comprobante > 0) break;
            //}

            if (vId_Comprobante == 0)
            {
                int vComprobante = new Tb_Cobranza_LN().Generar_Comprobante(vIds, AppSession.Usuario.Usuario, AppSession.Usuario.Id_Usuario);
                return RedirectToAction("Comprobante2", "Comprobante", new { vComprobante = vComprobante });
            }
            else
            {
                return RedirectToAction("Comprobante2", "Comprobante", new { vComprobante = vId_Comprobante });
            }
        }
        #endregion

        #region Pagos en Planilla en Excel Automatico

        public JsonResult ObtenerRecibo(string vRecibo)
        {
            return Json(new Tb_Recibocabecera_LN().GetRegistry_Nro(vRecibo), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Planilla_Excel(string vDocumento = "", int vIdConsejo = 0, int vIdEntidad = 0, int Pagina = 1)
        {
            var Temp = new Tb_Temporal_Planilla_LN().List(vDocumento, vIdConsejo, vIdEntidad, Pagina, Variables.Paginacion);
            ViewBag.Documento = (vDocumento.Trim().Length > 0) ? vDocumento : "";
            ViewBag.LstConsejo = new SelectList(new Tb_Maestras_LN().List(EnumMaestras.CONSEJO_REGIONAL), "ID_MAESTRAS", "DESCRIPCION", (Temp.Count > 0) ? Temp[0].Id_Consejo : 0);
            ViewBag.LstEntidad = (Temp.Count > 0) ? ViewBag.LstEntidad = new SelectList(new Tb_Persona_Juridica_LN().List(), "Id_Persona", "Razon_Social", (Temp.Count > 0) ? Temp[0].Id_EntidadPagadora : 0) : null;

            if (Request.IsAjaxRequest()) return PartialView("_DetalleExcel", Temp);
            return View(Temp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Planilla_Excel(HttpPostedFileBase uploadfile, int vIdConsejo, int vId_Entidad)
        public ActionResult Planilla_Excel(HttpPostedFileBase uploadfile)
        {
            if (ModelState.IsValid)
            {
                if (uploadfile != null && uploadfile.ContentLength > 0)
                {
                    Stream stream = uploadfile.InputStream;
                    IExcelDataReader reader = null;
                    if (uploadfile.FileName.EndsWith(".xls"))
                    {
                        reader = ExcelReaderFactory.CreateBinaryReader(stream, false);
                    }
                    else if (uploadfile.FileName.EndsWith(".xlsx"))
                    {
                        reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    }
                    else
                    {
                        ModelState.AddModelError("File", "Este formato de archivo no es compatible. Cargue un Xls o Xlsx");
                        return View();
                    }

                    string vRecibo = Request.Form["Nro_Documento"].ToString();
                    if (new Tb_Temporal_Planilla_LN().Save(reader, vRecibo, AppSession.Usuario.Usuario) == true)
                    {
                        return RedirectToAction("Planilla_Excel", "Cobranza", new { vDocumento = vRecibo, vIdConsejo = 0, vIdEntidad = 0, Pagina = 1 });
                    }
                    else
                    {
                        ModelState.AddModelError("File", "Hubo errores al procesar el archivo");
                        return View();
                    }
                }
            }
            else
            {
                ModelState.AddModelError("File", "Cargue su archivo por favor");
            }
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Planilla_Refresh(List<Tb_Temporal_Planilla> vList)
        {
            if (vList.Count < 1) return Json("0", JsonRequestBehavior.AllowGet);
            var x = new Tb_Temporal_Planilla_LN().Save(vList, AppSession.Usuario.Usuario);
            return Json("1", JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarEntidad(int vConsejo)
        {
            return Json((from x in new Tb_Persona_Juridica_LN().List(vConsejo) select new { id = x.Id_Persona, label = x.Razon_Social }).ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Procesar_Planilla(string vDocumento, int vIdConsejo, int vIdEntidad)
        {
            //new Tb_Comprobantecabecera_LN().Procesar_Planilla(vIds, AppSession.Usuario.Usuario);
            new Tb_Temporal_Planilla_LN().Procesar(vDocumento, vIdConsejo, vIdEntidad, AppSession.Usuario.Usuario, AppSession.Usuario.Id_Usuario);
            return Json("1", JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Planilla Manual

        public ActionResult Planilla(string vValor, string vPeriodo, int vIdConsejo = 0, int vId_Entidad = 0)
        {
            ViewBag.LstConsejo = new SelectList(new Tb_Maestras_LN().List(EnumMaestras.CONSEJO_REGIONAL), "ID_MAESTRAS", "DESCRIPCION", 0);
            ViewBag.LstPeriodo = new SelectList(new Tb_Correlativos_LN().List_PeriodoCobro(), "DESCRIPCION", "VALOR1", 0);
            ViewBag.LstEntidad = null;
            if (Request.IsAjaxRequest()) return PartialView("_DetallePlanilla", new Tb_Cobranza_LN().ListPlanilla(vValor, vPeriodo, vIdConsejo, vId_Entidad));
            return View(new Tb_Cobranza_LN().ListPlanilla(vValor, vPeriodo, vIdConsejo, vId_Entidad));
        }

        public ActionResult Listar_Doctores()
        {
            return PartialView("_Listar_Doctores", new List<ColegiadoMin>());
        }

        [HttpPost]
        public ActionResult Listar_Doctores(string vValor)
        {
            return PartialView("_ListarDetalle_Doctores", new Tb_Persona_LN().List_Modal(vValor));
        }

        public ActionResult Seleccionar_Doctor(int vId, int vIdEntidad, int vIdConsejo)
        {
            var Temp = new Tb_Persona_Natural_LN().GetRegistry(vId);
            Temp.Id_Entidad_Paga = vIdEntidad;
            Temp.Usu_Modifica = AppSession.Usuario.Usuario;
            new Tb_Persona_Natural_LN().UpdateColegiado_Cobranza(Temp);
            return Json("1", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Quitar_Doctor(int vId)
        {
            var Temp = new Tb_Persona_Natural_LN().GetRegistry(vId);
            Temp.Id_Entidad_Paga = null;
            Temp.Usu_Modifica = AppSession.Usuario.Usuario;
            new Tb_Persona_Natural_LN().Update(Temp);
            return Json("1", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Procesar_Pago(string vIds, string vMontos, string vRecibo)
        {
            new Tb_Comprobantecabecera_LN().Procesar_Planilla(vIds, vMontos, vRecibo, AppSession.Usuario.Usuario);
            return Json("1", JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Planilla Bancos


        public ActionResult Bancos_Archivo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Bancos_Archivo(HttpPostedFileBase vUploadfile)
        {
            if (ModelState.IsValid)
            {
                if (vUploadfile != null && vUploadfile.ContentLength > 0)
                {
                    var vExtension = new string[] { "txt", "rtf", "html", "xaml", "xslx", "pdf", "doc", "docx", "csv" };
                    var vFileExt = Path.GetExtension(vUploadfile.FileName).Substring(1);
                    if (Array.FindAll(vExtension, s => s.Equals(vFileExt)).Length < 1)
                    {
                        ModelState.AddModelError("File", "Este formato de archivo no es compatible. Cargue un Xls o Xlsx");
                        return View();
                    }
                    else
                    {
                        var vFileName = Path.GetFileName(vUploadfile.FileName);
                        var vPath = Path.Combine(Server.MapPath("~/Uploads"), vFileName);
                        vUploadfile.SaveAs(vPath);
                        var vEngine = new FileHelperEngine<BancosLocal>();
                        BancosLocal[] vResult = vEngine.ReadFile(vPath);
                        Session["BancoLocal"] = vResult;
                        return View(vResult);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("File", "Cargue su archivo por favor");
            }
            return View();
        }

        public ActionResult Procesar_PagoBanco()
        {
            if (Session["BancoLocal"] != null)
            {
                List<Tb_Cobranza> LstCobranza = new List<Tb_Cobranza>();
                foreach (var item in (BancosLocal[])Session["BancoLocal"])
                {

                    LstCobranza.Add(new Tb_Cobranza()
                    {
                        //Id_Colegiado = vId_Persona,
                        //Id_Estado_Colegiado = Temp.Id_Estado_Actual,
                        Colegiatura = item.Colegiatura,
                        Año = Variables.Hoy.Year,
                        Mes = Variables.Hoy.Month,
                        Id_Servicio = (int)EnumTipoArticuloCuota.CUOTA_PENSION,
                        Descuento = 0,
                        Monto = Convert.ToDecimal(item.Monto),
                        Fecha = Variables.Hoy,
                        Fecha_Pagado = Convert.ToDateTime(item.Fecha_Pago),
                        Id_Comprobante = 0,
                        Flg_Activo = Variables.Activo,
                        Fec_Ingreso = Variables.Hoy,
                        Fec_Modifica = Variables.Hoy,
                        Usu_Ingreso = AppSession.Usuario.Usuario,
                        Usu_Modifica = AppSession.Usuario.Usuario
                    });
                }

                Session.Remove("BancoLocal");
                return Json("1", JsonRequestBehavior.AllowGet);
            }
            else
            {
                //new Tb_Comprobantecabecera_LN().Procesar_Planilla(vIds, AppSession.Usuario.Usuario);
                return Json("0", JsonRequestBehavior.AllowGet);
            }

        }

        #endregion

        #region Entrada de Cobros

        public ActionResult BuscarClienteGP(string vValor = "FULLSITO")
        {
            if (vValor == "FULLSITO")
                return PartialView("_BuscarCliente", new Cliente_LN().Listar(vValor));
            else
                return PartialView("_BuscarClienteDetalle", new Cliente_LN().Listar(vValor));
        }


        public ActionResult EntradaCobros()
        {
            ViewBag.LstTipoago = new Cuentas_Cobrar_LN().List_TipoPago();
            //ViewBag.LstChequera = new Recepcion_LN().List_Chequera(AppSession.Usuario.Consejo_Regional.Substring(4, 2));
            ViewBag.LstChequera = new Recepcion_LN().List_Chequera(AppSession.Usuario.Consejo_Regional,AppSession.Usuario.Usuario,(int)EnumTipoPago.EFECTIVO);
            return View(new OtraCobranza());
        }

        public ActionResult GrabarCobrosEfectivo(OtraCobranza vOtraCobranza)
        {
            //vOtraCobranza.IdLote = AppSession.Usuario.Consejo_Regional.Substring(4, 2) + AppSession.Usuario.Usuario;
            vOtraCobranza.IdLote = AppSession.Usuario.Consejo_Regional + AppSession.Usuario.Usuario;
            var Temp = new Cuentas_Pagar_LN().OtrasCobranzas(vOtraCobranza);
            return Json(Temp, JsonRequestBehavior.AllowGet);
        }
        

        [HttpPost]
        public ActionResult EntradaCobros(OtraCobranza vOtraCobranza)
        {
            //vOtraCobranza.IdLote = AppSession.Usuario.Consejo_Regional.Substring(4, 2) + AppSession.Usuario.Usuario;
            vOtraCobranza.IdLote = AppSession.Usuario.Consejo_Regional + AppSession.Usuario.Usuario;
            new Cuentas_Pagar_LN().OtrasCobranzas(vOtraCobranza);
            return View(vOtraCobranza);
        }

        public JsonResult ListarFacturas(string vCliente)
        {
            return Json(new Cuentas_Cobrar_LN().List_FacturaPendientes(vCliente), JsonRequestBehavior.AllowGet);
        }

        #endregion


    }
}
using Cmp02.Entities;
using Cmp04.BusinessLogic;
using Cmp01.Utilities;
using System;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace Cmp09.WebCtaCte.Controllers
{
    [Authorize]
    [SessionExpire]
    [OutputCache(NoStore = true, Duration = 0)]
    public class ComprobanteController : Controller
    {
        #region Comprobante Lectura

        public ActionResult Comprobante(int vComprobante = 0)
        {
            LoadCbo();
            var Temp = new Tb_Comprobantecabecera_LN().GetRegistry(vComprobante);
            Temp.Id_Sitio_Origen = AppSession.Usuario.Id_Consejo_Regional;
            Temp.Id_Sitio_Destino = AppSession.Usuario.Id_Consejo_Regional;
            return View(Temp);
        }

        public JsonResult ListarSerie(int vTipoDocumento)
        {
            return Json(new Tb_Correlativos_LN().List(AppSession.Usuario.Id_Consejo_Regional, vTipoDocumento, 0), JsonRequestBehavior.AllowGet);
        }

        public JsonResult TraerNumero(int vTipoDocumento, int vSerie)
        {
            return Json(new Tb_Correlativos_LN().GetRegistry(AppSession.Usuario.Id_Consejo_Regional, vTipoDocumento, vSerie).Opcional, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ObtenerCliente(string vDni)
        {
            return Json(new Tb_Persona_Natural_LN().GetRegistry(0, vDni), JsonRequestBehavior.AllowGet);
        }


        #endregion

        #region Modal de Personas Naturales

        public ActionResult Listar_Persona()
        {
            return PartialView("_ListarPersona", new List<ColegiadoMin>());
        }

        [HttpPost]
        public ActionResult Listar_Persona(string vValor)
        {
            return PartialView("_ListarPersonaDetalle", new Tb_Persona_LN().List_Persona(vValor, "N"));
        }

        #endregion

        #region Modal de Personas Juridicas

        public ActionResult Listar_Empresa()
        {
            return PartialView("_ListarPersonaJ", new List<ColegiadoMin>());
        }

        [HttpPost]
        public ActionResult Listar_Empresa(string vValor)
        {
            return PartialView("_ListarPersonaJDetalle", new Tb_Persona_LN().List_Persona(vValor, "J"));
        }
        
        #endregion



        [HttpPost]
        public ActionResult Comprobante(Tb_Comprobantecabecera vComprobante)
        {
            vComprobante.Usu_Ingreso = vComprobante.Usu_Modifica = AppSession.Usuario.Usuario;
            vComprobante.Equipo = System.Net.Dns.GetHostEntry(Request.UserHostAddress).HostName;
            if (vComprobante.Id_Sitio_Origen == 0) vComprobante.Id_Sitio_Origen = vComprobante.Id_Sitio_Destino;
            if (ModelState.IsValid) vComprobante = new Tb_Comprobantecabecera_LN().Grabar(vComprobante);
            LoadCbo();
            if (Request.IsAjaxRequest()) return PartialView("_Cabecera", vComprobante);
            return View(vComprobante);
        }

        public ActionResult Detalle(string vServicios = "", int vId = 0)
        {
            try
            {
                if (string.IsNullOrEmpty(vServicios)) return Json(new { rpta = "0", mensaje = "Debe seleccionar los articulo" }, JsonRequestBehavior.AllowGet);
                if (vId <= 0) return Json(new { rpta = "0", mensaje = "No se ha seleccionado el comprobante" }, JsonRequestBehavior.AllowGet);
                if (new Tb_Comprobantedetalle_LN().Procesar_Pedido(vServicios, vId, AppSession.Usuario.Consejo_Regional.Substring(4, 2), "", "") > 0) return Json(new { rpta = "0", mensaje = "Ya existe una Matricula, no puede volver a matricularse" }, JsonRequestBehavior.AllowGet);
                return Json(new { rpta = "1" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { rpta = "0", mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult DetalleGet(int vId)
        {
            return PartialView("_Detalle", new Tb_Comprobantedetalle_LN().List(vId));
        }

        public JsonResult EliminarServicio(int vId)
        {
            try
            {
                new Tb_Comprobantedetalle_LN().Delete(vId, AppSession.Usuario.Usuario, Variables.Hoy);
                return Json(new { rpta = "1" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { rpta = "0", mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult Procesar(int vId, int vId_Comprobante)
        {
            return Json(new Tb_Persona_Natural_LN().ProcesarPreMatricula(vId, vId_Comprobante, AppSession.Usuario.Usuario), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ActualizarDescuento(int vId, decimal vDescuento)
        {
            return Json(new Tb_Comprobantedetalle_LN().DescuentoServicio(vId, vDescuento, AppSession.Usuario.Usuario), JsonRequestBehavior.AllowGet);
        }

        //public ActionResult Emitir(int vId)
        //{
        //    return Json(new Tb_Comprobantecabecera_LN().EmitirFactura(vId, AppSession.Usuario.Usuario), JsonRequestBehavior.AllowGet);
        //}

        public ActionResult ObtenerEmpresa(string vRuc)
        {
            return Json(new Tb_Persona_LN().List_EmpresaBandeja(vRuc, 0)[0], JsonRequestBehavior.AllowGet);
        }





        public ActionResult Obtener(int Tipo_Documentosunat = 0, string Nro_Documento = "")
        {
            var Temp = new Tb_Comprobantecabecera_LN().GetRegistry(Tipo_Documentosunat, Nro_Documento);
            Temp.Id_Sitio_Origen = AppSession.Usuario.Id_Consejo_Regional;
            Temp.Id_Sitio_Destino = AppSession.Usuario.Id_Consejo_Regional;
            ViewBag.LstDocumento = new Tb_Maestras_LN().List(EnumMaestras.TIPO_DOCUMENTOSUNAT);
            ViewBag.LstMoneda = new Tb_Maestras_LN().List(EnumMaestras.TIPO_MONEDA);
            ViewBag.LstSitio = new Tb_Maestras_LN().List(EnumMaestras.CONSEJO_REGIONAL);
            ViewBag.LstPago = new Tb_Maestras_LN().List(EnumMaestras.TIPO_PAGO);
            if (Request.IsAjaxRequest()) return PartialView("_AnularComprobante", Temp);
            return View(Temp);
        }

        public ActionResult Anulacion(int vId_Comprobante)
        {
            var Temp = new Tb_Comprobantecabecera_LN().GetRegistry(vId_Comprobante);
            Temp.Id_Sitio_Origen = AppSession.Usuario.Id_Consejo_Regional;
            Temp.Id_Sitio_Destino = AppSession.Usuario.Id_Consejo_Regional;
            if (ModelState.IsValid) Temp = new Tb_Comprobantecabecera_LN().Anular(Temp);
            return Json(Temp.Opcional, JsonRequestBehavior.AllowGet);
        }



        #region Recibo de Caja

        public ActionResult Recibo(int vComprobante = 0)
        {
            //ViewBag.LstDocumento = new Tb_Maestras_LN().List(EnumMaestras.TIPO_DOCUMENTOSUNAT);
            ViewBag.LstSerie = new Tb_Correlativos_LN().List(AppSession.Usuario.Id_Consejo_Regional, (int)EnumTipoDocSunat.RECIBO, 0);
            ViewBag.LstMoneda = new Tb_Maestras_LN().List(EnumMaestras.TIPO_MONEDA);
            ViewBag.LstSitio = new Tb_Maestras_LN().List(EnumMaestras.CONSEJO_REGIONAL);
            ViewBag.LstPago = new Tb_Maestras_LN().List(EnumMaestras.TIPO_PAGO);
            ViewBag.LstCondicionPago = new Recepcion_LN().List_CondicionPago();

            var Temp = new Tb_Recibocabecera_LN().GetRegistry(vComprobante);
            Temp.Id_Sitio_Origen = AppSession.Usuario.Id_Consejo_Regional;
            Temp.Id_Sitio_Destino = AppSession.Usuario.Id_Consejo_Regional;
            return View(Temp);
        }

        [HttpPost]
        public ActionResult Recibo(Tb_Comprobantecabecera vComprobante)
        {
            vComprobante.Usu_Ingreso = vComprobante.Usu_Modifica = AppSession.Usuario.Usuario;
            vComprobante.Equipo = System.Net.Dns.GetHostEntry(Request.UserHostAddress).HostName;
            if (vComprobante.Id_Sitio_Origen == 0) vComprobante.Id_Sitio_Origen = vComprobante.Id_Sitio_Destino;
            vComprobante.Cta_Contable = "";
            //vComprobante.Observacion = "";
            //if (ModelState.IsValid) 
            vComprobante = new Tb_Recibocabecera_LN().Grabar(vComprobante);

            ViewBag.LstSerie = new Tb_Correlativos_LN().List(AppSession.Usuario.Id_Consejo_Regional, (int)EnumTipoDocSunat.RECIBO, 0);
            ViewBag.LstMoneda = new Tb_Maestras_LN().List(EnumMaestras.TIPO_MONEDA);
            ViewBag.LstSitio = new Tb_Maestras_LN().List(EnumMaestras.CONSEJO_REGIONAL);
            ViewBag.LstPago = new Tb_Maestras_LN().List(EnumMaestras.TIPO_PAGO);
            ViewBag.LstCondicionPago = new Recepcion_LN().List_CondicionPago();
            if (Request.IsAjaxRequest()) return PartialView("_ReciboCabecera", vComprobante);
            return View(vComprobante);
        }

        public ActionResult ReciboDetalle(string vServicios = "", int vId = 0)
        {
            try
            {
                if (string.IsNullOrEmpty(vServicios))
                {
                    return Json(new { rpta = "0", mensaje = "Debe seleccionar los articulo" }, JsonRequestBehavior.AllowGet);
                }
                if (vId <= 0)
                {
                    return Json(new { rpta = "0", mensaje = "No se ha seleccionado el comprobante" }, JsonRequestBehavior.AllowGet);
                }
                if (new Tb_Recibodetalle_LN().Procesar_Pedido(vServicios, vId) == 0)
                {
                    return Json(new { rpta = "0", mensaje = "Ya existe una Matricula, no puede volver a matricularse" }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { rpta = "1" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { rpta = "0", mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult ActualizarDescripcion(int vId, string vDescripcion)
        {
            return Json(new Tb_Recibodetalle_LN().UpdateServicio(vId, vDescripcion), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ActualizarMonto(int vId, decimal vMonto)
        {
            return Json(new Tb_Recibodetalle_LN().UpdateMonto(vId, vMonto), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ReciboDetalleGet(int vId)
        {
            var Temp = new Tb_Recibodetalle_LN().List(vId);
            return PartialView("_ReciboDetalle", Temp);
        }

        public JsonResult EliminarReciboServicio(int vId)
        {
            try
            {
                new Tb_Recibodetalle_LN().Delete(vId, AppSession.Usuario.Usuario, Variables.Hoy);
                return Json(new { rpta = "1" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { rpta = "0", mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        

        #endregion

        #region Métodos Privados
        public void LoadCbo()
        {
            ViewBag.LstDocumento = (from x in new Tb_Maestras_LN().List(EnumMaestras.TIPO_DOCUMENTOSUNAT) where x.Id_Maestras != (int)EnumTipoDocSunat.RECIBO select x).ToList();
            ViewBag.LstMoneda = new Tb_Maestras_LN().List(EnumMaestras.TIPO_MONEDA);
            ViewBag.LstSitio = new Tb_Maestras_LN().List(EnumMaestras.CONSEJO_REGIONAL);
            ViewBag.LstPago = new Tb_Maestras_LN().List(EnumMaestras.TIPO_PAGO);
            ViewBag.LstCondicionPago = new Recepcion_LN().List_CondicionPago();
        }

        #endregion

        #region Comprobante de Deuda Cuotas

        public ActionResult ComprobanteFull(int vComprobante = 0)
        {
            LoadCbo();
            var Temp = new Tb_Comprobantecabecera_LN().GetRegistry(vComprobante);
            Temp.Id_Sitio_Origen = AppSession.Usuario.Id_Consejo_Regional;
            Temp.Id_Sitio_Destino = AppSession.Usuario.Id_Consejo_Regional;
            return View(Temp);
        }

        #endregion

    }
}
using Cmp02.Entities;
using Cmp04.BusinessLogic;
using Cmp01.Utilities;
using System;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;

namespace Cmp08.WebCaja.Controllers
{
    [Authorize]
    [SessionExpire]
    [OutputCache(NoStore = true, Duration = 0)]
    public class ComprobanteController : Controller
    {
        #region Comprobante Lectura

        public ActionResult Comprobante(int vComprobante = 0)
        {
            
            var Temp = new Tb_Comprobantecabecera_LN().GetRegistry(vComprobante);
            LoadCbo(AppSession.Usuario.Usuario,Temp.Id_Tipo_Pago);
            Temp.Id_Sitio_Origen = AppSession.Usuario.Id_Consejo_Regional;
            Temp.Id_Sitio_Destino = AppSession.Usuario.Id_Consejo_Regional;
            return View(Temp);
        }

        public JsonResult ListarSerie(int vTipoDocumento)
        {
            return Json(new Tb_Correlativos_LN().List(AppSession.Usuario.Id_Consejo_Regional, vTipoDocumento, 0, AppSession.Usuario.Id_Usuario), JsonRequestBehavior.AllowGet);
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

        public ActionResult Listar_Referencia(string vValor)
        {
            return PartialView("_ListarDocumentoReferencia", new Tb_Comprobantecabecera_LN().ListxCliente(vValor));
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
            if (ModelState.IsValid)
                vComprobante = new Tb_Comprobantecabecera_LN().Grabar(vComprobante);
            else if (vComprobante.Tipo_Documentosunat == (int)EnumTipoDocSunat.FACTURA &&
                    (ModelState.Where(X => X.Value.Errors.Count() > 0).Count() <= 4) && ModelState.Where(X => X.Value.Errors.Count() > 0).Where(x => x.Key == "Colegiatura" || x.Key == "Apellidos_Colegiado" || x.Key == "Nombres_Colegiado" || x.Key == "DNI").Count() <= 4)
            {
                vComprobante = new Tb_Comprobantecabecera_LN().Grabar(vComprobante);
                //vComprobante.Apellidos_Colegiado = (vComprobante.Apellidos_Colegiado.Length == 0) ? "NINGUNO" : vComprobante.Apellidos_Colegiado;
                //vComprobante.Nombres_Colegiado = (vComprobante.Nombres_Colegiado.Length == 0) ? "NINGUNO" : vComprobante.Nombres_Colegiado;
                //vComprobante.Colegiatura = (vComprobante.Colegiatura.Length == 0) ? "NINGUNO" : vComprobante.Colegiatura;
                //vComprobante.DNI = (vComprobante.DNI.Length == 0) ? "00000000" : vComprobante.DNI;
            }
                

            LoadCbo(AppSession.Usuario.Usuario, vComprobante.Id_Tipo_Pago);
            if (Request.IsAjaxRequest()) return PartialView("_Cabecera", vComprobante);
            return View(vComprobante);
        }

        public ActionResult Detalle(string vServicios = "", int vId = 0, string documento = "", string TipoArticulo = "")
        {
            try
            {
                if (string.IsNullOrEmpty(vServicios)) return Json(new { rpta = "0", mensaje = "Debe seleccionar los articulo" }, JsonRequestBehavior.AllowGet);
                if (vId <= 0) return Json(new { rpta = "0", mensaje = "No se ha seleccionado el comprobante" }, JsonRequestBehavior.AllowGet);
                //var vResp = new Tb_Comprobantedetalle_LN().Procesar_Pedido(vServicios, vId, AppSession.Usuario.Consejo_Regional.Substring(4, 2));
                var vResp = new Tb_Comprobantedetalle_LN().Procesar_Pedido(vServicios, vId, "", documento, TipoArticulo);
                if (vResp == 1) return Json(new { rpta = "0", mensaje = "Ya existe una Matricula, no puede volver a matricularse" }, JsonRequestBehavior.AllowGet);
                else if (vResp == 2) return Json(new { rpta = "0", mensaje = "La cantidad no debe exceder " + Variables.MaxUnidades }, JsonRequestBehavior.AllowGet);
                //if (vResp > 0) return Json(new { rpta = "0", mensaje = "Ya existe una Matricula, no puede volver a matricularse" }, JsonRequestBehavior.AllowGet);
                //else if (vResp == 2) return Json(new { rpta = "0", mensaje = "La cantidad no debe exceder " + Variables.MaxUnidades }, JsonRequestBehavior.AllowGet);
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

        public JsonResult Listar_Chequera(int vTtipo)
        {
            return Json(new Recepcion_LN().List_Chequera(AppSession.Usuario.Consejo_Regional, AppSession.Usuario.Usuario, vTtipo), JsonRequestBehavior.AllowGet);
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
        public void LoadCbo(string usuario,int tipo)
        {
            if (tipo==0) {
                tipo = (int)EnumTipoPago.EFECTIVO;
            }
            ViewBag.LstDocumento = (from x in new Tb_Maestras_LN().List(EnumMaestras.TIPO_DOCUMENTOSUNAT)
                                    where x.Id_Maestras == (int)EnumTipoDocSunat.BOLETA 
                                    || x.Id_Maestras == (int)EnumTipoDocSunat.FACTURA
                                    || x.Id_Maestras == (int)EnumTipoDocSunat.NOTACREDITO
                                    || x.Id_Maestras == (int)EnumTipoDocSunat.NOTADEBITO
                                    select x).ToList();
            ViewBag.LstMoneda = new Tb_Maestras_LN().List(EnumMaestras.TIPO_MONEDA);
            //ViewBag.LstSitio = new Tb_Maestras_LN().List(EnumMaestras.CONSEJO_REGIONAL);
            ViewBag.LstSitio = new Tb_Maestras_LN().ListConsejo(usuario); 
            ViewBag.LstPago = new Tb_Maestras_LN().List(EnumMaestras.TIPO_PAGO);
            ViewBag.LstCondicionPago = new Recepcion_LN().List_CondicionPago();
            ViewBag.LstChequera = new Recepcion_LN().List_Chequera(AppSession.Usuario.Consejo_Regional,usuario, tipo);
            //ViewBag.LstChequera = new Recepcion_LN().List_Chequera(AppSession.Usuario.Consejo_Regional.Substring(4, 2));
        }

        #endregion

        #region Comprobante de Deuda Cuotas

        public ActionResult ComprobanteFull(int vComprobante = 0)
        {
            
            var Temp = new Tb_Comprobantecabecera_LN().GetRegistry(vComprobante);
            LoadCbo(AppSession.Usuario.Usuario,Temp.Id_Tipo_Pago);
            Temp.Id_Sitio_Origen = AppSession.Usuario.Id_Consejo_Regional;
            Temp.Id_Sitio_Destino = AppSession.Usuario.Id_Consejo_Regional;
            return View(Temp);
        }

        #endregion

        #region Modal de Personas Juridicas

        public ActionResult CuotasAdelantadas()
        {
            List<Tb_Maestras> Meses = new List<Tb_Maestras>();
            DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;
            for (int i = 1; i <= 12; i++)
            {
                Meses.Add(new Tb_Maestras() { Id_Maestras = i, Descripcion = dtinfo.GetMonthName(i).ToUpper() });
            }
            ViewBag.LstHasta = Meses;
            ViewBag.LstDesde = Meses;
            return PartialView("_CuotasAdelantadas", 10);
        }

        [HttpPost]
        public ActionResult CuotasAdelantadas(string vValor)
        {
            return PartialView("_ListarPersonaJDetalle", new Tb_Persona_LN().List_Persona(vValor, "J"));
        }

        #endregion

        #region Comprobante de Cuotas Adelantadas

        public ActionResult Comprobante2(int vComprobante)
        {
            var Temp = new Tb_Comprobantecabecera_LN().GetRegistry(vComprobante);
            LoadCbo(AppSession.Usuario.Usuario,Temp.Id_Tipo_Pago);
            
            Temp.Id_Sitio_Origen = AppSession.Usuario.Id_Consejo_Regional;
            Temp.Id_Sitio_Destino = AppSession.Usuario.Id_Consejo_Regional;
            return View(Temp);
        }

        [HttpPost]
        public ActionResult Comprobante2(Tb_Comprobantecabecera vComprobante)
        {
            vComprobante.Usu_Ingreso = vComprobante.Usu_Modifica = AppSession.Usuario.Usuario;
            vComprobante.Equipo = System.Net.Dns.GetHostEntry(Request.UserHostAddress).HostName;
            if (vComprobante.Id_Sitio_Origen == 0) vComprobante.Id_Sitio_Origen = vComprobante.Id_Sitio_Destino;
            if (ModelState.IsValid) vComprobante = new Tb_Comprobantecabecera_LN().Grabar(vComprobante);
            LoadCbo(AppSession.Usuario.Usuario, vComprobante.Id_Tipo_Pago);
            if (Request.IsAjaxRequest()) return PartialView("_Cabecera2", vComprobante);
            return View(vComprobante);
        }

        public ActionResult Procesar2(int vId, int vId_Comprobante)
        {
            return Json(new Tb_Persona_Natural_LN().ProcesarCuota(vId, vId_Comprobante, AppSession.Usuario.Usuario), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Gestion de Comprobantes

        public ActionResult Gestion_Comprobante()
        {
            LoadCbo(AppSession.Usuario.Usuario,0);
            return View();
        }

        public ActionResult GetCabecera(int vIdCab = 0)
        {
            
            var Temp = new Tb_Comprobantecabecera_LN().GetRegistry(vIdCab);
            LoadCbo(AppSession.Usuario.Usuario,Temp.Id_Tipo_Pago);
            Temp.Id_Sitio_Origen = AppSession.Usuario.Id_Consejo_Regional;
            Temp.Id_Sitio_Destino = AppSession.Usuario.Id_Consejo_Regional;
            return PartialView("_Cabecera3", Temp);
        }

        public ActionResult GetDetalle(int vIdDet = 0)
        {
            var Temp = new Tb_Comprobantecabecera_LN().GetRegistry(vIdDet);
            return PartialView("_Detalle3", Temp);
        }

        #endregion
    }
}
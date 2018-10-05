﻿using Cmp02.Entities;
using Cmp04.BusinessLogic;
using Cmp01.Utilities;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace Cmp08.WebCaja.Controllers
{
    public class PagosController : Controller
    {
        Cuentas_Cobrar_LN vObj1 = new Cuentas_Cobrar_LN();
        Recepcion_LN vObj2 = new Recepcion_LN();
        Orden_Compra_LN vObj3 = new Orden_Compra_LN();
        Pagos_Manuales_LN vObj4 = new Pagos_Manuales_LN();

        #region Nota de Debito del Cliente

        public ActionResult NotaDebito()
        {
            List<string> vCodigos = new List<string>() { "2", "3", "5" };
            ViewBag.LstDocumento = (from x in vObj1.List_TipoDocumento() where vCodigos.Contains(x.Id_Maestras.ToString()) select x).ToList();

            ViewBag.NroGuia = vObj1.Get_Nro_Documento();
            ViewBag.LstCondicionPago = vObj2.List_CondicionPago();
            ViewBag.LstSunat = vObj2.List_SunatDocumento();
            ViewBag.LstDetraccion = vObj2.List_Detracciones();
            ViewBag.LstMoneda = vObj3.List_Moneda();
            ViewBag.LstPlanImpuesto = vObj3.List_PlanImpuesto();
            ViewBag.LstConceptoGastos = vObj1.List_ConceptoGastos(0);

            return View(new TransaccionesCobros());
        }

        //public JsonResult Listar_Ordenes(string vProveedor)
        //{
        //    return Json(vObj1.List_Direccion(vProveedor), JsonRequestBehavior.AllowGet);
        //}

        public ActionResult GrabarNotaDebito(Transacciones vTransacciones)
        {
            vTransacciones.Fechadocref = null;
            vTransacciones.IdConsejo = AppSession.Usuario.Consejo_Regional;
            //return Json(vObj1.GrabarCaja(vTransacciones), JsonRequestBehavior.AllowGet);
            return Json(1, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Nota de Credito  del Cliente

        public ActionResult NotaCredito()
        {
            //List<string> vCodigos = new List<string>() { "3", "4", "5" };
            //ViewBag.LstDocumento = (from x in vObj1.List_TipoDocumento() where vCodigos.Contains(x.Id_Maestras.ToString()) select x).ToList();

            ViewBag.LstDocumento = vObj1.List_TipoDocumento().Where(x => x.Id_Maestras == 4).ToList();

            ViewBag.NroGuia = vObj1.Get_Nro_Documento();
            ViewBag.LstCondicionPago = vObj2.List_CondicionPago();
            ViewBag.LstSunat = vObj2.List_SunatDocumento();
            ViewBag.LstDetraccion = vObj2.List_Detracciones();
            ViewBag.LstMoneda = vObj3.List_Moneda();
            ViewBag.LstPlanImpuesto = vObj3.List_PlanImpuesto();
            ViewBag.LstConceptoGastos = vObj1.List_ConceptoGastos(0);

            return View(new TransaccionesCobros());
        }

        //public JsonResult Listar_Ordenes(string vProveedor)
        //{
        //    return Json(vObj1.List_Direccion(vProveedor), JsonRequestBehavior.AllowGet);
        //}

        public ActionResult GrabarNotaCredito(TransaccionesCobros vTransacciones)
        {
            //vTransacciones.Fechadocref = null;
            //vTransacciones.IdConsejo = AppSession.Usuario.Consejo_Regional;

            return Json(vObj1.Grabar(vTransacciones), JsonRequestBehavior.AllowGet);
        }

        #endregion


        #region Entrada de Transacciones

        public ActionResult Transacciones()
        {
            List<string> vCodigos = new List<string>() { "2", "3" };
            ViewBag.LstDocumento = (from x in vObj1.List_TipoDocumento() where vCodigos.Contains(x.Id_Maestras.ToString()) select x).ToList();

            ViewBag.NroGuia = vObj1.Get_Nro_Documento();
            ViewBag.LstCondicionPago = vObj2.List_CondicionPago();
            ViewBag.LstSunat = vObj2.List_SunatDocumento();
            ViewBag.LstDetraccion = vObj2.List_Detracciones();
            ViewBag.LstMoneda = vObj3.List_Moneda();
            ViewBag.LstPlanImpuesto = vObj3.List_PlanImpuesto();
            ViewBag.LstConceptoGastos = vObj1.List_ConceptoGastos(0);

            return View(new Transacciones());
        }

        public JsonResult Listar_Direcciones(string vCliente)
        {
            return Json(new Cliente_LN().List_Direccion(vCliente), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Listar_Conceptos(int vTtipo)
        {
            return Json(new Cuentas_Cobrar_LN().List_ConceptoGastos(vTtipo), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GrabarTransaccion(TransaccionesCobros vTransacciones)
        {
            //vTransacciones.Fechadocref = null;
            //vTransacciones.IdConsejo = AppSession.Usuario.Consejo_Regional;
            //return Jsonm(vObj1.Grabar(vTransacciones), JsonRequestBehavior.AllowGet);
            return Json(vObj1.Grabar(vTransacciones), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Pagos Manuales

        public ActionResult PagosManuales()
        {
            ViewBag.LstMoneda = vObj3.List_Moneda();
            ViewBag.LstSunat = vObj4.List_SunatDocumento();
            ViewBag.NroGuia = vObj4.Get_Nro_Documento();
            ViewBag.LstChequera = vObj4.List_Chequera();
            return View(new Pagos_Manuales());
        }

        public ActionResult GrabarPagosManuales(Pagos_Manuales vPagos_Manuales)
        {
            vPagos_Manuales.IdConsejo = AppSession.Usuario.Consejo_Regional;
            return Json(vObj4.Grabar(vPagos_Manuales), JsonRequestBehavior.AllowGet);
        }

        #endregion
	}
}
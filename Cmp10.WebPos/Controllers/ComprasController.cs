using Cmp02.Entities;
using Cmp04.BusinessLogic;
using Cmp01.Utilities;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace Cmp10.WebPos.Controllers
{
    [SessionExpire]
    [OutputCache(NoStore = true, Duration = 0)]
    public class ComprasController : Controller
    {
        Orden_Compra_LN vObj = new Orden_Compra_LN();
        Recepcion_LN vObj2 = new Recepcion_LN();
        Transacciones_LN vObj3 = new Transacciones_LN();

        #region Proceso de Orden de Compra

        public ActionResult OrdenCompra()
        {
            ViewBag.LstDocumento = vObj.List_TipoDocumento();
            ViewBag.LstMoneda = vObj.List_Moneda();
            ViewBag.LstPlanImpuesto = vObj.List_PlanImpuesto();
            ViewBag.LstResponsable = vObj.List_Responsable();
            ViewBag.NroGuia = vObj.Get_Nro_Documento();
            //ViewBag.NroGuia = vObj.Get_Nro_Documento();
            return View(new OrdenCompra() { Cabecera = new Oc_Cabecera(), Detalle = new System.Collections.Generic.List<Oc_Detalle>() });
        }

        public ActionResult GrabarCompra(OrdenCompra vOrdenCompra)
        {
            vOrdenCompra.Cabecera.IdConsejo = AppSession.Usuario.Consejo_Regional;
            return Json(vObj.Grabar(vOrdenCompra), JsonRequestBehavior.AllowGet);
        }

        public ActionResult BuscarModal()
        {
            return PartialView("_BuscarModal");
        }

        public JsonResult BuscarJSON(string vDescripcion, string vImpuesto)
        {
            var lista = vObj.List_Servicios(vDescripcion, vImpuesto, "COMPRA");
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Listar()
        {
            if (Request.IsAjaxRequest()) return PartialView("_Detalle", new Tb_Servicios_LN().List(""));
            return View(new Tb_Servicios_LN().List(""));
        }

        #endregion

        #region Proceso de Recepción de Transacciones

        public ActionResult Entrada()
        {
            ViewBag.LstDocumento = vObj2.List_TipoDocumento();
            ViewBag.LstSunat = vObj2.List_SunatDocumento();
            ViewBag.LstMoneda = vObj.List_Moneda();
            ViewBag.Lote = AppSession.Usuario.Consejo_Regional.Substring(AppSession.Usuario.Consejo_Regional.Length - 2, 2)+AppSession.Usuario.Usuario.ToString();
            //ViewBag.LstResponsable = vObj.List_Responsable();
            ViewBag.NroGuia = vObj2.Get_Nro_Documento();
            ViewBag.LstDetraccion = vObj2.List_Detracciones();
            ViewBag.LstCondicionPago = vObj2.List_CondicionPago();

            return View(new Recepcion() { Cabecera = new Re_Cabecera(), Detalle = new List<Re_Detalle>(), Orden = new List<Oc_Transaccion>() });
        }

        public JsonResult Listar_Ordenes(string vProveedor)
        {
            return Json(vObj2.List_Ordenes(vProveedor), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Listar_Orden(string vOrden)
        {
            return PartialView("_TRDetalle", vObj2.List_OrdenesDetalle(vOrden));
        }

        public ActionResult GrabarRecepcion(Recepcion vRecepcion)
        {
            vRecepcion.Cabecera.IdConsejo = AppSession.Usuario.Consejo_Regional;
            return Json(vObj2.Grabar(vRecepcion), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Entrada de Transacciones

        public ActionResult Transacciones()
        {
            ViewBag.LstMoneda = vObj.List_Moneda();
            ViewBag.NroDiario = vObj3.Get_Nro_Documento();
            return View(new EntradaTransaccion() { Cabecera = new CaEntradaTransaccion(), Detalle = new List<DeEntradaTransaccion>() });
        }

        public ActionResult BuscarDocOrigen()
        {
            return PartialView("_BuscarDocOrigen");
        }

        public JsonResult BuscarDocOrigenJSON(string vDescripcion)
        {
            var lista = (from vTemp in vObj3.List_DocumentoOrigen() where vTemp.Descripcion.ToUpper().Contains(vDescripcion.ToUpper()) select vTemp).ToList();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BuscarLinea()
        {
            return PartialView("_BuscarLinea");
        }

        public JsonResult BuscarLineaJSON(string vDescripcion)
        {
            var lista = vObj3.List_CuentaContable(vDescripcion);
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GrabarTransaccion(EntradaTransaccion vTransaccion)
        {
            
            vTransaccion.Cabecera.IdConsejo = AppSession.Usuario.Consejo_Regional;
            return Json(vObj3.Grabar(vTransaccion), JsonRequestBehavior.AllowGet);
            //return Json(1, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Entrada Factura Compras

        public ActionResult EntradaFactura()
        {
            ViewBag.LstDocumento = vObj2.List_TipoDocumento();
            ViewBag.LstSunat = vObj2.List_SunatDocumento();
            ViewBag.LstMoneda = vObj.List_Moneda();
            //ViewBag.LstResponsable = vObj.List_Responsable();
            ViewBag.NroGuia = vObj2.Get_Nro_Documento();
            ViewBag.LstDetraccion = vObj2.List_Detracciones();
            ViewBag.LstCondicionPago = vObj2.List_CondicionPago();

            return View(new Recepcion() { Cabecera = new Re_Cabecera(), Detalle = new List<Re_Detalle>(), Orden = new List<Oc_Transaccion>() });
        }

        
        #endregion
	}
}
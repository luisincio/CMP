using Cmp02.Entities;
using Cmp04.BusinessLogic;
using Cmp01.Utilities;
using System.Web.Mvc;

namespace Cmp10.WebPos.Controllers
{
    public class PagosController : Controller
    {
        Cuentas_Pagar_LN vObj1 = new Cuentas_Pagar_LN();
        Recepcion_LN vObj2 = new Recepcion_LN();
        Orden_Compra_LN vObj3 = new Orden_Compra_LN();
        Pagos_Manuales_LN vObj4 = new Pagos_Manuales_LN();
        
        #region Entrada de Transacciones

        public ActionResult Transacciones()
        {
            ViewBag.LstDocumento = vObj1.List_TipoDocumento();
            ViewBag.NroGuia = vObj1.Get_Nro_Documento();
            ViewBag.LstCondicionPago = vObj2.List_CondicionPago();
            ViewBag.LstSunat = vObj2.List_SunatDocumento();
            ViewBag.LstDetraccion = vObj2.List_Detracciones();
            ViewBag.LstMoneda = vObj3.List_Moneda();
            ViewBag.LstPlanImpuesto = vObj3.List_PlanImpuesto();
            ViewBag.LstConceptoGastos = vObj1.List_ConceptoGastos(0);
            ViewBag.Lote = AppSession.Usuario.Consejo_Regional.Substring(AppSession.Usuario.Consejo_Regional.Length - 2, 2) + AppSession.Usuario.Usuario;

            return View(new Transacciones());
        }

        public JsonResult Listar_Ordenes(string vProveedor)
        {
            return Json(vObj1.List_Direccion(vProveedor), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GrabarTransaccion(Transacciones vTransacciones)
        {
            vTransacciones.Fechadocref = null;
            vTransacciones.IdConsejo = AppSession.Usuario.Consejo_Regional;
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
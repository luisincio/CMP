#region Espacios de Nombres
using Cmp02.Entities;
using Cmp04.BusinessLogic;
using Cmp01.Utilities;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System.Web;
using System;
#endregion


namespace Cmp08.WebCaja.Controllers
{
    public class DetraccionController : Controller
    {
        public ActionResult Listar(int vId_Cliente)
        {
            var Temp = new Detraccion_LN().List(vId_Cliente);
            if (Request.IsAjaxRequest()) return PartialView("_Detalle", Temp);
            return View(Temp);
        }
    }
}
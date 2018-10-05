#region Espacios de Nombres
using Cmp02.Entities;
using Cmp04.BusinessLogic;
using Cmp01.Utilities;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System.Web;
#endregion

namespace Cmp11.WebSistemas.Controllers
{
    [Authorize]
    [SessionExpire]
    [OutputCache(NoStore = true, Duration = 0)]
    public class EmpresaController : Controller
    {

        public ActionResult Listar(string vNombre, int vConsejo = 0)
        {
            ViewBag.LstConsejo = new Tb_Maestras_LN().List(EnumMaestras.CONSEJO_REGIONAL);
            if (vConsejo == 0) vConsejo = AppSession.Usuario.Id_Consejo_Regional;
            var Temp = new Tb_Persona_LN().List_EmpresaBandeja(vNombre, vConsejo);
            if (Request.IsAjaxRequest()) return PartialView("_Detalle", Temp);
            return View(Temp);
        }

        public ActionResult Editar(int vId)
        {
            EmpresaMin Temp;
            ViewBag.LstConsejo = new Tb_Maestras_LN().List(EnumMaestras.CONSEJO_REGIONAL);
            ViewBag.LstSector = new Tb_Maestras_LN().List(EnumMaestras.SECTOR);
            
            if (vId == 0)
            {
                Temp = new EmpresaMin() { Id_Consejo_Juridico = AppSession.Usuario.Id_Consejo_Regional };
                ViewBag.LstGrupo = new Tb_Maestras_LN().List(EnumMaestras.GRUPO_OCUPACIONALPUBLICO);
            }
            else
            {
                Temp = (from x in new Tb_Persona_LN().List_EmpresaBandeja("", 0) where x.Id_Persona == vId select x).ToList()[0];
                ViewBag.LstGrupo = (Temp.Id_Origen_Juridico == (int)EnumSector.PUBLICO) ? new Tb_Maestras_LN().List(EnumMaestras.GRUPO_OCUPACIONALPUBLICO) : new Tb_Maestras_LN().List(EnumMaestras.GRUPO_OCUPACIONAL);
            }
            
            return PartialView("_EditarEmpresa", Temp);
        }

        [HttpPost]
        public ActionResult Editar(EmpresaMin Empresa)
        {
            Empresa.Usu_Ingreso = Empresa.Usu_Modifica = AppSession.Usuario.Usuario;
            if (ModelState.IsValid) new Tb_Persona_Juridica_LN().Grabar(Empresa);
            ViewBag.LstSector = new Tb_Maestras_LN().List(EnumMaestras.SECTOR);
            ViewBag.LstGrupo = (Empresa.Id_Origen_Juridico == (int)EnumSector.PUBLICO) ? new Tb_Maestras_LN().List(EnumMaestras.GRUPO_OCUPACIONALPUBLICO) : new Tb_Maestras_LN().List(EnumMaestras.GRUPO_OCUPACIONAL);
            ViewBag.LstConsejo = new Tb_Maestras_LN().List(EnumMaestras.CONSEJO_REGIONAL);
            return PartialView("_EditarEmpresa", Empresa);
        }

        public JsonResult ListarGrupo(int vSector)
        {
            if (vSector == (int)EnumSector.PUBLICO)
            {
                return Json((from x in new Tb_Maestras_LN().List(EnumMaestras.GRUPO_OCUPACIONALPUBLICO) select new { id = x.Id_Maestras, label = x.Descripcion }).ToList(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json((from x in new Tb_Maestras_LN().List(EnumMaestras.GRUPO_OCUPACIONAL) select new { id = x.Id_Maestras, label = x.Descripcion }).ToList(), JsonRequestBehavior.AllowGet);
            }
        }

	}
}
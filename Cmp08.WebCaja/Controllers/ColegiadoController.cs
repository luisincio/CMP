#region Espacios de Nombres
using Cmp02.Entities;
using Cmp04.BusinessLogic;
using Cmp01.Utilities;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System;
using System.Web;
using System.Configuration;
#endregion

namespace Cmp08.WebCaja.Controllers
{
    [Authorize]
    [SessionExpire]
    [OutputCache(NoStore = true, Duration = 0)]
    public class ColegiadoController : Controller
    {
        Tb_Maestras_LN OMaestra = new Tb_Maestras_LN();

        #region Datos Personales

        public ActionResult Registrar(int vId = 1)
        {
            LoadCombos();
            ColegiadoMicro Temp = new Tb_Persona_Natural_LN().GetColegiadoCaja(vId);
            ViewBag.Colegiado = Temp.Colegiado;
            return View(Temp);
        }

        [HttpPost]
        public ActionResult Registrar(ColegiadoMicro vPersona)
        {
            vPersona.Usu_Ingreso = vPersona.Usu_Modifica = AppSession.Usuario.Usuario;
            if (ModelState.IsValid) vPersona = new Tb_Persona_Natural_LN().ActualizarColegiado(vPersona);

            LoadCombos();
            if (Request.IsAjaxRequest()) return PartialView("accordion", vPersona);
            return View(vPersona);
            //Cliente vCliente = new Cliente();
            //if (vPersona.Id_Persona == 0)
            //{
            //    vCliente.Persona = vPersona;
            //    if (vCliente.Domicilio == null) vCliente.Domicilio = new Tb_Domicilio();
            //    if (vCliente.Medios == null) vCliente.Medios = new List<Tb_Medio_Contacto>();
            //}
            //else
            //{
            //    vCliente = new Tb_Persona_Natural_LN().GetCliente(vPersona.Id_Persona);
            //    vCliente.Persona = vPersona;
            //}
            //return View(vCliente);
        }
        
        #endregion

        #region Domicilio

        [HttpPost]
        public ActionResult Direccion(Tb_Domicilio vDomicilio)
        {
            vDomicilio.Usu_Ingreso = vDomicilio.Usu_Modifica = AppSession.Usuario.Usuario;
            ModelState["Id_Tipo_Zona"].Errors.Clear();

            if (ModelState.IsValid) vDomicilio = new Tb_Domicilio_LN().Grabar(vDomicilio);

            LoadCombos();
            return PartialView("_Direccion", vDomicilio);
        }

        #endregion

        #region Medio de Contacto

        public ActionResult ListaMedios(int vId = 0)
        {
            var Temp = new Tb_Medio_Contacto_LN().List(vId);
            return PartialView("_ListaMedios", Temp);
        }

        public ActionResult Medios(int vId_Persona, int vId = 0)
        {
            ViewBag.LstMedio = OMaestra.List(EnumMaestras.MEDIO_CONTACTO);
            Tb_Medio_Contacto Temp;
            if (vId == 0)
            {
                Temp = new Tb_Medio_Contacto() { Id_Persona = vId_Persona };
            }
            else
            {
                Temp = new Tb_Medio_Contacto_LN().GetRegistry(vId);
            }
            return PartialView("_EditarMedio", Temp);
        }

        [HttpPost]
        public ActionResult Medios(Tb_Medio_Contacto vMedioContacto)
        {
            vMedioContacto.Usu_Ingreso = vMedioContacto.Usu_Modifica = AppSession.Usuario.Usuario;
            if (ModelState.IsValid)
            {
                vMedioContacto = new Tb_Medio_Contacto_LN().Grabar(vMedioContacto);
                vMedioContacto.Opcional = "OK";
            }
            ViewBag.LstMedio = OMaestra.List(EnumMaestras.MEDIO_CONTACTO);
            return PartialView("_EditarMedio", vMedioContacto);
        }

        public ActionResult Eliminae_Medio(int vId)
        {
            return Json(new Tb_Medio_Contacto_LN().Delete(vId, AppSession.Usuario.Usuario, Variables.Hoy), JsonRequestBehavior.AllowGet);
        }

        #endregion
        
        //#region Consejo

        //public ActionResult ListaConsejos(int vId = 0)
        //{
        //    var Temp = new Tb_Colegiado_Consejo_LN().List(vId);
        //    return PartialView("_ListaConsejos", Temp);
        //}

        //public ActionResult Consejo(int vId_Persona, int vId = 0)
        //{
        //    ViewBag.LstConsejo = OMaestra.List(EnumMaestras.CONSEJO_REGIONAL);
        //    Tb_Colegiado_Consejo Temp;
        //    if (vId == 0)
        //    {
        //        Temp = new Tb_Colegiado_Consejo() { Id_Persona = vId_Persona, Fec_Ingreso = Variables.Hoy };
        //    }
        //    else
        //    {
        //        Temp = new Tb_Colegiado_Consejo_LN().GetRegistry(vId);
        //    }
        //    return PartialView("_EditarConsejo", Temp);
        //}

        //[HttpPost]
        //public ActionResult Consejo(Tb_Colegiado_Consejo vConsejo)
        //{
        //    vConsejo.Usu_Ingreso = vConsejo.Usu_Modifica = AppSession.Usuario.Usuario;
        //    if (ModelState.IsValid)
        //    {
        //        vConsejo = new Tb_Colegiado_Consejo_LN().Grabar(vConsejo);
        //        vConsejo.Opcional = "OK";
        //    }
        //    ViewBag.LstConsejo = OMaestra.List(EnumMaestras.CONSEJO_REGIONAL);
        //    return PartialView("_EditarConsejo", vConsejo);
        //}

        //public ActionResult Elimina_Consejo(int vId)
        //{
        //    return Json(new Tb_Colegiado_Consejo_LN().Delete(vId, AppSession.Usuario.Usuario, Variables.Hoy), JsonRequestBehavior.AllowGet);
        //}

        //#endregion

        //#region Estado

        //public ActionResult ListaEstados(int vId = 0)
        //{
        //    var Temp = new Tb_Colegiado_Estado_LN().List(vId);
        //    return PartialView("_ListaEstados", Temp);
        //}

        //public ActionResult Estado(int vId_Persona, int vId = 0)
        //{
        //    ViewBag.LstEstado = OMaestra.List(EnumMaestras.ESTADO_MATRICULA);
        //    Tb_Colegiado_Estado Temp;
        //    if (vId == 0)
        //    {
        //        Temp = new Tb_Colegiado_Estado() { Id_Persona = vId_Persona, Fec_Ingreso = Variables.Hoy };
        //    }
        //    else
        //    {
        //        Temp = new Tb_Colegiado_Estado_LN().GetRegistry(vId);
        //    }
        //    return PartialView("_EditarEstado", Temp);
        //}

        //[HttpPost]
        //public ActionResult Estado(Tb_Colegiado_Estado vEstado)
        //{
        //    vEstado.Usu_Ingreso = vEstado.Usu_Modifica = AppSession.Usuario.Usuario;
        //    if (ModelState.IsValid)
        //    {
        //        vEstado = new Tb_Colegiado_Estado_LN().Grabar(vEstado);
        //        vEstado.Opcional = "OK";
        //    }
        //    ViewBag.LstEstado = OMaestra.List(EnumMaestras.ESTADO_MATRICULA);
        //    Tb_Colegiado_Estado Temp;
        //    if (vEstado.Id_Estado == 0)
        //    {
        //        Temp = new Tb_Colegiado_Estado() { Id_Persona = vEstado.Id_Persona, Fec_Ingreso = Variables.Hoy };
        //    }
        //    else
        //    {
        //        Temp = new Tb_Colegiado_Estado_LN().GetRegistry(vEstado.Id_Persona);
        //    }
        //    return PartialView("_EditarEstado", vEstado);
        //}

        //#endregion

        #region Fotografia

        public ActionResult Obtener_Imagen(int vId)
        {
            var Temp = new Tb_Persona_Imagen_LN().GetRegistry(vId, 1);
            if (Temp != null) if (Temp.Foto != null) return File(Temp.Foto, "image/jpg");
            return File(Server.MapPath("~/Content/Img/") + "FotoNoEncontrada.png", "image/jpg");
        }

        #endregion

        #region Firma
        
        public ActionResult Obtener_Firma(int vId)
        {
            var Temp = new Tb_Persona_Imagen_LN().GetRegistry(vId, 2);
            if (Temp != null) if (Temp.Foto != null) return File(Temp.Foto, "image/jpg");
            return File(Server.MapPath("~/Content/Img/") + "FotoNoEncontrada.png", "image/jpg");
        }

        #endregion

        #region Otros Métodos

        public JsonResult ListarUniversidad(int vOrigen, string vValor = "")
        {
            //if (vOrigen == (int)EnumOrigen.NACIONAL)
            if (vOrigen == Variables.Peru)
            {
                return Json((from x in OMaestra.List(EnumMaestras.UNIVERSIDAD) where x.Valor1 == "1" && x.Descripcion.ToUpper().Contains(vValor.ToUpper()) select new { id = x.Id_Maestras, label = x.Descripcion }).ToList(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json((from x in OMaestra.List(EnumMaestras.UNIVERSIDAD) where x.Valor1 == "2" && x.Descripcion.ToUpper().Contains(vValor.ToUpper()) select new { id = x.Id_Maestras, label = x.Descripcion }).ToList(), JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ListarEspecialidad(int vTipo, string vValor = "")
        {
            return Json((from x in OMaestra.List(EnumMaestras.ESPECIALIDAD) where x.Valor1 == vTipo.ToString() && x.Descripcion.ToUpper().Contains(vValor.ToUpper()) select new { id = x.Id_Maestras, label = x.Descripcion }).ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarEmpresa(string vValor = "")
        {
            return Json((from x in new Tb_Persona_LN().List_EmpresaBandeja(vValor, 0) select new { id = x.Id_Persona, label = x.Razon_Social }).ToList(), JsonRequestBehavior.AllowGet);
        }

        private void LoadCombos()
        {
            ViewBag.LstSanguineo = OMaestra.List(EnumMaestras.GRUPO_SANGUINEO);
            ViewBag.LstDocumento = OMaestra.List(EnumMaestras.TIPO_DOCUMENTO);
            ViewBag.LstEstCivil = OMaestra.List(EnumMaestras.ESTADO_CIVIL);
            ViewBag.LstGenero = OMaestra.List(EnumMaestras.GENERO);
            ViewBag.LstOrigen = OMaestra.List(EnumMaestras.ORIGEN);
            ViewBag.LstVia = OMaestra.List(EnumMaestras.TIPOS_VIA);
            ViewBag.LstZona = OMaestra.List(EnumMaestras.TIPOS_ZONA);
            ViewBag.LstSituacion = OMaestra.List(EnumMaestras.SITUACION_ESTUDIO);

            ViewBag.LstPais = new Tb_Pais_LN().List();
        }

        #endregion


        public ActionResult ListarAuxiliar(string vNombre)
        {
            var Temp = new Tb_Persona_LN().List_Bandeja(vNombre, (int)EnumEstado.ACTIVO, AppSession.Usuario.Id_Consejo_Regional);
            if (Request.IsAjaxRequest()) return PartialView("_DetalleAx", Temp);
            return View(Temp);
        }
    }
}
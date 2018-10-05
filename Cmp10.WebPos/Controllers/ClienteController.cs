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

namespace Cmp10.WebPos.Controllers
{
    [Authorize]
    [SessionExpire]
    [OutputCache(NoStore = true, Duration = 0)]
    public class ClienteController : Controller
    {
        Tb_Maestras_LN OMaestra = new Tb_Maestras_LN();
        Tb_Persona_Natural_LN OCliente = new Tb_Persona_Natural_LN();

        #region Datos Personales

        public ActionResult Registrar(int vId = 0)
        {
            LoadCombos();
            Cliente Temp = OCliente.GetCliente(vId);
            if (Temp.Persona.Nro_Documento == null)
            {
                Session["vNumero"] = Convert.ToString(Session["vNumero"]);
                Session["vDocumento"] = Convert.ToString(Session["vDocumento"]);
            }
            else
            {
                Session["vNumero"] = Session["vDocumento"] = "";
            }
            
            return View(Temp);
        }

        [HttpPost]
        public ActionResult Registrar(Tb_Persona_Natural vPersona)
        {
            vPersona.Usu_Ingreso = vPersona.Usu_Modifica = AppSession.Usuario.Usuario;
            if (ModelState.IsValid)
            {
                if (OCliente.GetRegistry(vPersona.Id_Tipo_Documento, vPersona.Nro_Documento) == null)
                {
                    vPersona = OCliente.Grabar(vPersona);
                    Session["vNumero"] = Session["vDocumento"] = "";
                }
                else
                {
                    vPersona.Opcional = "EXIST";
                }
            }

            LoadCombos();
            if (Request.IsAjaxRequest()) return PartialView("_DatosPrincipales", vPersona);

            Cliente vCliente = new Cliente();
            if (vPersona.Id_Persona == 0)
            {
                vCliente.Persona = vPersona;
                if (vCliente.Domicilio == null) vCliente.Domicilio = new Tb_Domicilio();
                if (vCliente.Medios == null) vCliente.Medios = new List<Tb_Medio_Contacto>();
            }
            else
            {
                vCliente = OCliente.GetCliente(vPersona.Id_Persona);
                vCliente.Persona = vPersona;
            }
            return View(vCliente);
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

        #region Medios de Contacto

        public ActionResult ListaMedios(int vId_Persona)
        {
            var Temp = new Tb_Medio_Contacto_LN().List(vId_Persona);
            return PartialView("_ListaMedios", Temp);
        }

        public ActionResult Medios(int vId_Persona, int vId = 0)
        {
            ViewBag.LstMedio = OMaestra.List(EnumMaestras.MEDIO_CONTACTO).OrderBy(x => x.Descripcion).ToList();
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
            if (ModelState.IsValid) vMedioContacto = new Tb_Medio_Contacto_LN().Grabar(vMedioContacto);
            ViewBag.LstMedio = OMaestra.List(EnumMaestras.MEDIO_CONTACTO);
            return PartialView("_EditarMedio", vMedioContacto);

        }

        public ActionResult Eliminae_Medio(int vId)
        {
            return Json(new Tb_Medio_Contacto_LN().Delete(vId, AppSession.Usuario.Usuario, Variables.Hoy), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Estudio Principal

        [HttpPost]
        public ActionResult Estudio(Tb_Colegiado_Estudio vEstudio)
        {
            vEstudio.Usu_Ingreso = vEstudio.Usu_Modifica = AppSession.Usuario.Usuario;
            if (ModelState.IsValid) vEstudio = new Tb_Colegiado_Estudio_LN().Grabar(vEstudio);
            LoadCombos();
            return PartialView("_Estudio", vEstudio);
        }

        #endregion

        #region Fotografia

        public ActionResult Actualizar_Imagen(int vId)
        {
            var Temp = new Tb_Persona_Imagen_LN().GetRegistry(vId, 1);
            if (vId > 0 && Temp == null) Temp = new Tb_Persona_Imagen() { Id_Persona = vId, Id_Tipo_Imagen = 1 };
            return PartialView("_Actualizar_Imagen", Temp);
        }

        [HttpPost]
        public ActionResult Actualizar_Imagen(Tb_Persona_Imagen vImage, HttpPostedFileBase files)
        {
            if (files != null)
            {
                var tempFile = new byte[files.ContentLength];
                files.InputStream.Read(tempFile, 0, files.ContentLength);
                vImage.Foto = tempFile;
                new Tb_Persona_Imagen_LN().Grabar(vImage);
            }
            return RedirectToAction("Registrar", "Cliente", new { vId = vImage.Id_Persona });
        }

        public ActionResult Obtener_Imagen(int vId)
        {
            var Temp = new Tb_Persona_Imagen_LN().GetRegistry(vId, 1);
            if (Temp != null) if (Temp.Foto != null) return File(Temp.Foto, "image/jpg");
            return File(Server.MapPath("~/Content/Img/") + "FotoNoEncontrada.png", "image/jpg");
        }

        #endregion

        #region Firma

        public ActionResult Actualizar_Firma(int vId)
        {
            var Temp = new Tb_Persona_Imagen_LN().GetRegistry(vId, 2);
            if (vId > 0 && Temp == null) Temp = new Tb_Persona_Imagen() { Id_Persona = vId, Id_Tipo_Imagen = 2 };
            return PartialView("_Actualizar_Firma", Temp);
        }

        [HttpPost]
        public ActionResult Actualizar_Firma(Tb_Persona_Imagen vImage, HttpPostedFileBase files)
        {
            if (files != null)
            {
                var tempFile = new byte[files.ContentLength];
                files.InputStream.Read(tempFile, 0, files.ContentLength);
                vImage.Foto = tempFile;
                new Tb_Persona_Imagen_LN().Grabar(vImage);
            }
            return RedirectToAction("Registrar", "Cliente", new { vId = vImage.Id_Persona });
        }

        public ActionResult Obtener_Firma(int vId)
        {
            var Temp = new Tb_Persona_Imagen_LN().GetRegistry(vId, 2);
            if (Temp != null) if (Temp.Foto != null) return File(Temp.Foto, "image/jpg");
            return File(Server.MapPath("~/Content/Img/") + "FotoNoEncontrada.png", "image/jpg");
        }

        #endregion

        #region Otros Métodos

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

        public JsonResult ListarUbigeo(int vOrigen, string vValor = "")
        {
            if (vOrigen == (int)EnumOrigen.EXTRANJERO)
            {
                return Json((from x in new Tb_Pais_LN().List() where x.Descripcion.ToUpper().Contains(vValor.ToUpper()) select new { id = x.Id_Pais, label = x.Descripcion }).ToList(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json((from x in new Tb_Ubigeo_LN().List(vValor) select new { id = x.Id_Ubigeo, label = x.Nombre_Ubigeo }).ToList(), JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ListarUbigeoPeru(string term = "")
        {
            return Json((from x in new Tb_Ubigeo_LN().List(term) select new { id = x.Id_Ubigeo, label = x.Nombre_Ubigeo }).ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult BuscarCliente(int vDocumento, string vNumero)
        {
            var vTemp = OCliente.GetRegistry(vDocumento, vNumero);
            if (vDocumento > 0 && vNumero.Trim().Length > 0)
            {
                Session["vNumero"] = vNumero;
                Session["vDocumento"] = vDocumento;
            }
            
            return Json((vTemp == null) ? 0 : vTemp.Id_Persona, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}
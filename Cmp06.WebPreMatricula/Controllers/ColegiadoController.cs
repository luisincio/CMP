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

namespace Cmp06.WebPreMatricula.Controllers
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
            Colegiado Temp = new Tb_Persona_Natural_LN().GetColegiado(vId);
            ViewBag.Comprobante = new Tb_Comprobantecabecera_LN().GetRegistry_Matricula(vId);
            ViewBag.Colegiado = Temp.Persona.Colegiado;
            return View(Temp);
        }

        [HttpPost]
        public ActionResult Registrar(Tb_Persona_Natural vPersona)
        {
            vPersona.Usu_Ingreso = vPersona.Usu_Modifica = AppSession.Usuario.Usuario;
            if (ModelState.IsValid) vPersona = new Tb_Persona_Natural_LN().Grabar(vPersona);

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
                vCliente = new Tb_Persona_Natural_LN().GetCliente(vPersona.Id_Persona);
                vCliente.Persona = vPersona;
            }
            return View(vCliente);
        }

        public JsonResult Matricular(int vId)
        {
            return Json(new Tb_Persona_Natural_LN().GenerarMatricula(vId, AppSession.Usuario.Usuario), JsonRequestBehavior.AllowGet);
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

        #region Especialidad

        public ActionResult ListaEspecialidad(int vId = 0)
        {
            ViewBag.Colegiado = new Tb_Persona_Natural_LN().GetRegistry(vId).Colegiado;
            var Temp = new Tb_Colegiado_Especialidad_LN().List(vId);
            return PartialView("_ListaEspecialidad", Temp);
        }

        public ActionResult Especialidad(int vId_Persona, int vId = 0)
        {
            ViewBag.LstTipoEspecialidad = OMaestra.List(EnumMaestras.TIPO_ESPECIALIDAD);
            //ViewBag.LstOrigen = OMaestra.List(EnumMaestras.ORIGEN);
            ViewBag.LstPais = new Tb_Pais_LN().List();
            ViewBag.LstSituacion = OMaestra.List(EnumMaestras.SITUACION_ESTUDIO);
            ViewBag.LstTramite = OMaestra.List(EnumMaestras.CONSEJO_REGIONAL);
            Tb_Colegiado_Especialidad Temp;
            if (vId == 0)
            {
                Temp = new Tb_Colegiado_Especialidad() { Id_Persona = vId_Persona };
            }
            else
            {
                Temp = new Tb_Colegiado_Especialidad_LN().GetRegistry(vId);
            }
            return PartialView("_EditarEspecialidad", Temp);
        }

        [HttpPost]
        public ActionResult Especialidad(Tb_Colegiado_Especialidad vEspecialidad)
        {
            vEspecialidad.Usu_Ingreso = vEspecialidad.Usu_Modifica = AppSession.Usuario.Usuario;
            if (ModelState.IsValid) vEspecialidad = new Tb_Colegiado_Especialidad_LN().Grabar(vEspecialidad);
            ViewBag.LstTipoEspecialidad = OMaestra.List(EnumMaestras.TIPO_ESPECIALIDAD);
            ViewBag.LstOrigen = OMaestra.List(EnumMaestras.ORIGEN);
            ViewBag.LstSituacion = OMaestra.List(EnumMaestras.SITUACION_ESTUDIO);
            ViewBag.LstTramite = OMaestra.List(EnumMaestras.CONSEJO_REGIONAL);
            return PartialView("_EditarEspecialidad", vEspecialidad);
        }

        public ActionResult Elimina_Especialidad(int vId)
        {
            return Json(new Tb_Colegiado_Especialidad_LN().Delete(vId, AppSession.Usuario.Usuario, Variables.Hoy), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Nro_Especialidad(int vId_TipoEspecialidad)
        {
            return Json(new Tb_Correlativos_LN().GetNumeroEspecialidad(vId_TipoEspecialidad), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Trabajos

        public ActionResult ListaTrabajos(int vId = 0)
        {
            var Temp = new Tb_Colegiado_Laboral_LN().List(vId);
            return PartialView("_ListaTrabajos", Temp);
        }

        public ActionResult Trabajo(int vId_Persona, int vId = 0)
        {
            ViewBag.LstSector = OMaestra.List(EnumMaestras.SECTOR);
            ViewBag.LstPunto = OMaestra.List(EnumMaestras.TIPO_ESPECIALIDAD);
            Tb_Colegiado_Laboral Temp;
            if (vId == 0)
            {
                Temp = new Tb_Colegiado_Laboral() { Id_Persona = vId_Persona };
                ViewBag.LstGrupo = OMaestra.List(EnumMaestras.GRUPO_OCUPACIONALPUBLICO);
            }
            else
            {
                Temp = new Tb_Colegiado_Laboral_LN().GetRegistry(vId);
                ViewBag.LstGrupo = (Temp.Id_Sector == (int)EnumSector.PUBLICO) ? new Tb_Maestras_LN().List(EnumMaestras.GRUPO_OCUPACIONALPUBLICO) : new Tb_Maestras_LN().List(EnumMaestras.GRUPO_OCUPACIONAL);
            }
            return PartialView("_EditarTrabajo", Temp);
        }

        [HttpPost]
        public ActionResult Trabajo(Tb_Colegiado_Laboral vTrabajo)
        {
            vTrabajo.Usu_Ingreso = vTrabajo.Usu_Modifica = AppSession.Usuario.Usuario;
            if (ModelState.IsValid)
            {
                vTrabajo = new Tb_Colegiado_Laboral_LN().Grabar(vTrabajo);
                return PartialView("_EditarTrabajo", vTrabajo);
            }
            ViewBag.LstSector = OMaestra.List(EnumMaestras.SECTOR);
            ViewBag.LstGrupo = (vTrabajo.Id_Sector == (int)EnumSector.PUBLICO) ? new Tb_Maestras_LN().List(EnumMaestras.GRUPO_OCUPACIONALPUBLICO) : new Tb_Maestras_LN().List(EnumMaestras.GRUPO_OCUPACIONAL);
            ViewBag.LstPunto = OMaestra.List(EnumMaestras.TIPO_ESPECIALIDAD);
            return PartialView("_EditarTrabajo2", vTrabajo);
        }

        public ActionResult Elimina_Trabajo(int vId)
        {
            return Json(new Tb_Colegiado_Laboral_LN().Delete(vId, AppSession.Usuario.Usuario, Variables.Hoy), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Consejo

        public ActionResult ListaConsejos(int vId = 0)
        {
            var Temp = new Tb_Colegiado_Consejo_LN().List(vId);
            return PartialView("_ListaConsejos", Temp);
        }

        public ActionResult Consejo(int vId_Persona, int vId = 0)
        {
            ViewBag.LstConsejo = OMaestra.List(EnumMaestras.CONSEJO_REGIONAL);
            Tb_Colegiado_Consejo Temp;
            if (vId == 0)
            {
                Temp = new Tb_Colegiado_Consejo() { Id_Persona = vId_Persona, Fec_Ingreso = Variables.Hoy };
            }
            else
            {
                Temp = new Tb_Colegiado_Consejo_LN().GetRegistry(vId);
            }
            return PartialView("_EditarConsejo", Temp);
        }

        [HttpPost]
        public ActionResult Consejo(Tb_Colegiado_Consejo vConsejo)
        {
            vConsejo.Usu_Ingreso = vConsejo.Usu_Modifica = AppSession.Usuario.Usuario;
            if (ModelState.IsValid)
            {
                vConsejo = new Tb_Colegiado_Consejo_LN().Grabar(vConsejo);
                vConsejo.Opcional = "OK";
            }
            ViewBag.LstConsejo = OMaestra.List(EnumMaestras.CONSEJO_REGIONAL);
            return PartialView("_EditarConsejo", vConsejo);
        }

        public ActionResult Elimina_Consejo(int vId)
        {
            return Json(new Tb_Colegiado_Consejo_LN().Delete(vId, AppSession.Usuario.Usuario, Variables.Hoy), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Estado

        public ActionResult ListaEstados(int vId = 0)
        {
            var Temp = new Tb_Colegiado_Estado_LN().List(vId);
            return PartialView("_ListaEstados", Temp);
        }

        public ActionResult Estado(int vId_Persona, int vId = 0)
        {
            ViewBag.LstEstado = OMaestra.List(EnumMaestras.ESTADO_MATRICULA);
            Tb_Colegiado_Estado Temp;
            if (vId == 0)
            {
                Temp = new Tb_Colegiado_Estado() { Id_Persona = vId_Persona, Fec_Ingreso = Variables.Hoy };
            }
            else
            {
                Temp = new Tb_Colegiado_Estado_LN().GetRegistry(vId);
            }
            return PartialView("_EditarEstado", Temp);
        }

        [HttpPost]
        public ActionResult Estado(Tb_Colegiado_Estado vEstado)
        {
            vEstado.Usu_Ingreso = vEstado.Usu_Modifica = AppSession.Usuario.Usuario;
            if (ModelState.IsValid)
            {
                vEstado = new Tb_Colegiado_Estado_LN().Grabar(vEstado);
                vEstado.Opcional = "OK";
            }
            ViewBag.LstEstado = OMaestra.List(EnumMaestras.ESTADO_MATRICULA);
            Tb_Colegiado_Estado Temp;
            if (vEstado.Id_Estado == 0)
            {
                Temp = new Tb_Colegiado_Estado() { Id_Persona = vEstado.Id_Persona, Fec_Ingreso = Variables.Hoy };
            }
            else
            {
                Temp = new Tb_Colegiado_Estado_LN().GetRegistry(vEstado.Id_Persona);
            }
            return PartialView("_EditarEstado", vEstado);
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
            return RedirectToAction("Registrar", "Colegiado", new { vId = vImage.Id_Persona });
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
            return RedirectToAction("Registrar", "Colegiado", new { vId = vImage.Id_Persona });
        }

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

    }
}
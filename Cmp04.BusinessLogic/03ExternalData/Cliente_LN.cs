/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Cliente_LN.cs
Objetivo          : Clase referida a los métodos de Lógica de Negocio de la clase GP
Autor             : CMP-SISTEMAS (FRR)
Fecha Creación    : 09/06/2018 
----------------------------------------------------------------------------------------*/
#region Espacios de Nombres
using Cmp03.DataAccess;
using Cmp02.Entities;
using Cmp01.Utilities;
using System;
using System.Collections.Generic;
using System.Transactions;
#endregion

namespace Cmp04.BusinessLogic
{
    public partial class Cliente_LN : Base
    {
        #region Métodos Públicos Generales

        public int Grabar(ClienteNJ vCliente)
        {
            try
            {
                return new Cliente_AD().Grabar(vCliente);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public ClienteClover GrabarDatos(ClienteClover vCliente)
        {
            using (var vTrans = new TransactionScope(TransactionScopeOption.Suppress))
            {
                try
                {
                    if (vCliente.TipoPersona == (int)EnumTipoPersonaGP.NATURAL)
                    {
                        var vPersonaN = new Tb_Persona_Natural_AD().GetRegistry(0, vCliente.NroDocumento.Trim());
                        //Datos para GP
                        #region Registrar en GP
                        vCliente.NombreCompleto = (vCliente.ApellidoPaterno.Trim() + " " + vCliente.ApellidoMaterno.Trim() + ", " + vCliente.PrimerNombre.Trim() + " " + vCliente.SegundoNombre.Trim()).ToUpper();
                        var Temp = new Tb_Ubigeo_AD().GetRegistry(vCliente.Id_Ubigeo);
                        vCliente.Distrito = Temp.Distrito;
                        vCliente.Provincia = Temp.Provincia;
                        vCliente.Departamento = Temp.Departamento;
                        vCliente.Pais = Variables.Pais;
                        vCliente.Direccion1 = vCliente.Direccion1.Trim().ToUpper();
                        vCliente.Direccion2 = vCliente.Direccion1.Trim().ToUpper();
                        vCliente.TipoDocumento = vCliente.TipoDocumento;
                        vCliente.Colegiado = (vPersonaN != null) ? vPersonaN.Colegiado : Variables.Colegiado;
                        vCliente.Total_Reg = new Cliente_AD().GrabarDatos(vCliente);
                        vCliente.Opcional = (vCliente.Total_Reg == 1) ? "OK" : "ERROR";
                        #endregion
                        //Datos para BD LOCAL
                        if (vCliente.Total_Reg == 1)
                        {
                            if (vPersonaN == null)
                            {
                                #region Insertar en Persona
                                var vPersona = new Tb_Persona();
                                vPersona.Fec_Ingreso = Variables.Hoy;
                                vPersona.Fec_Modifica = Variables.Hoy;
                                vPersona.Usu_Ingreso = vCliente.Usu_Ingreso;
                                vPersona.Usu_Modifica = vCliente.Usu_Ingreso;
                                vPersona.Flg_Activo = Variables.Activo;
                                vPersona.Flg_Nacionalidad = Variables.Activo;
                                vPersona.Id_Tipo_Persona = Variables.Natural;
                                vPersona.Nombre_Comercial = vCliente.NombreCompleto;
                                vPersona.Nombre_Completo = vCliente.NombreCompleto;
                                vPersona.Ruc = "";
                                new Tb_Persona_AD().Insert(vPersona);
                                #endregion

                                #region Insertar en Persona Natural
                                var vPersonaNat = new Tb_Persona_Natural();
                                vPersonaNat.Id_Persona = vPersona.Id_Persona;
                                vPersonaNat.Colegiado = Variables.Colegiado;
                                vPersonaNat.Apellido_Paterno = vCliente.ApellidoPaterno.Trim();
                                vPersonaNat.Apellido_Materno = vCliente.ApellidoMaterno.Trim();
                                vPersonaNat.Nombres = vCliente.PrimerNombre.Trim() + " " + vCliente.SegundoNombre.Trim();
                                vPersonaNat.Id_Grupo_Sanguineo = 0;
                                vPersonaNat.Id_Tipo_Documento = vCliente.TipoDocumento;
                                vPersonaNat.Nro_Documento = vCliente.NroDocumento;
                                vPersonaNat.Id_Tipo_Estado_Civil = 0;
                                vPersonaNat.Sexo = "";
                                vPersonaNat.Lugar_Nacimiento = "";
                                vPersonaNat.Observacion = "";
                                vPersonaNat.Id_Estado_Actual = 0;
                                vPersonaNat.Id_Carnet = null;
                                vPersonaNat.Id_Habilidad = null;
                                vPersonaNat.Id_Entidad_Paga = null;
                                vPersonaNat.Fec_Fallecio = null;
                                vPersonaNat.Fec_Ingreso = Variables.Hoy;
                                vPersonaNat.Fec_Modifica = Variables.Hoy;
                                vPersonaNat.Fec_Colegiado = Variables.Hoy;
                                vPersonaNat.Fecha_Nacio = Variables.Hoy;
                                vPersonaNat.Usu_Ingreso = vCliente.Usu_Ingreso;
                                vPersonaNat.Usu_Modifica = vCliente.Usu_Modifica;
                                vPersonaNat = new Tb_Persona_Natural_AD().Insert(vPersonaNat);
                                #endregion

                                #region Insertar en Domicilio
                                var vPersonaDir = new Tb_Domicilio();
                                vPersonaDir.Id_Domicilio = 0;
                                vPersonaDir.Id_Persona = vPersona.Id_Persona;
                                vPersonaDir.Id_Pais = Variables.Peru;
                                vPersonaDir.Id_Tipo_Via = 0;
                                vPersonaDir.Nombre_Via = "";
                                vPersonaDir.Nro_Via = "";
                                vPersonaDir.Nro_Km = "";
                                vPersonaDir.Manzana = "";
                                vPersonaDir.Lote = "";
                                vPersonaDir.Nro_Interior = "";
                                vPersonaDir.Nro_Departamento = "";
                                vPersonaDir.Id_Tipo_Zona = 0;
                                vPersonaDir.Nombre_Zona = "";
                                vPersonaDir.Referencia = "";
                                vPersonaDir.Domicilio_Completo = vCliente.Direccion1;
                                vPersonaDir.Id_Ubigeo = vCliente.Id_Ubigeo;
                                vPersonaDir.Flg_Domicilio_Fiscal = Variables.Activo;
                                vPersonaDir.Seccion = "";
                                vPersonaDir.Flg_Activo = Variables.Activo;
                                vPersonaDir.Fec_Ingreso = Variables.Hoy;
                                vPersonaDir.Fec_Modifica = Variables.Hoy;
                                vPersonaDir.Usu_Ingreso = vCliente.Usu_Ingreso;
                                vPersonaDir.Usu_Modifica = vCliente.Usu_Modifica;
                                vPersonaDir = new Tb_Domicilio_AD().Insert(vPersonaDir);
                                #endregion

                                #region Insertar Celular y Correo electronico

                                new Tb_Medio_Contacto_AD().Insert(new Tb_Medio_Contacto()
                                {
                                    Fec_Ingreso = Variables.Hoy,
                                    Fec_Modifica = Variables.Hoy,
                                    Flg_Activo = Variables.Activo,
                                    Id_Medio_Contacto = 0,
                                    Id_Persona = vPersona.Id_Persona,
                                    Id_Tipo_Medio_Contacto = (int)EnumMedioContacto.CORREO,
                                    Nombre_Medio_Contacto = vCliente.Email,
                                    Usu_Ingreso = vCliente.Usu_Ingreso,
                                    Usu_Modifica = vCliente.Usu_Ingreso
                                });

                                new Tb_Medio_Contacto_AD().Insert(new Tb_Medio_Contacto()
                                {
                                    Fec_Ingreso = Variables.Hoy,
                                    Fec_Modifica = Variables.Hoy,
                                    Flg_Activo = Variables.Activo,
                                    Id_Medio_Contacto = 0,
                                    Id_Persona = vPersona.Id_Persona,
                                    Id_Tipo_Medio_Contacto = (int)EnumMedioContacto.CELULAR,
                                    Nombre_Medio_Contacto = vCliente.Celular,
                                    Usu_Ingreso = vCliente.Usu_Ingreso,
                                    Usu_Modifica = vCliente.Usu_Ingreso
                                });
                                #endregion
                            }
                            else
                            {
                                #region Actualizar Persona
                                var vPersona = new Tb_Persona_AD().GetRegistry(vPersonaN.Id_Persona);
                                vPersona.Fec_Ingreso = Variables.Hoy;
                                vPersona.Fec_Modifica = Variables.Hoy;
                                vPersona.Usu_Ingreso = vCliente.Usu_Ingreso;
                                vPersona.Usu_Modifica = vCliente.Usu_Ingreso;
                                vPersona.Flg_Activo = Variables.Activo;
                                vPersona.Id_Tipo_Persona = Variables.Natural;
                                vPersona.Nombre_Comercial = vCliente.NombreCompleto;
                                vPersona.Nombre_Completo = vCliente.NombreCompleto;
                                new Tb_Persona_AD().Update(vPersona);
                                #endregion

                                #region Actualiza la Persona Natural
                                vPersonaN.Apellido_Paterno = vCliente.ApellidoPaterno.Trim();
                                vPersonaN.Apellido_Materno = vCliente.ApellidoMaterno.Trim();
                                vPersonaN.Nombres = vCliente.PrimerNombre.Trim() + " " + vCliente.SegundoNombre.Trim();
                                vPersonaN.Fec_Ingreso = Variables.Hoy;
                                vPersonaN.Fec_Modifica = Variables.Hoy;
                                vPersonaN.Fec_Colegiado = Variables.Hoy;
                                vPersonaN.Fecha_Nacio = Variables.Hoy;
                                vPersonaN.Usu_Ingreso = vCliente.Usu_Ingreso;
                                vPersonaN.Usu_Modifica = vCliente.Usu_Modifica;
                                vPersonaN = new Tb_Persona_Natural_AD().Update(vPersonaN);
                                #endregion

                                #region Actualiza el Domicilio
                                var vPersonaDir = new Tb_Domicilio_AD().GetRegistry(vPersonaN.Id_Persona);
                                vPersonaDir.Domicilio_Completo = vCliente.Direccion1;
                                vPersonaDir.Id_Ubigeo = vCliente.Id_Ubigeo;
                                vPersonaDir.Flg_Domicilio_Fiscal = Variables.Activo;
                                vPersonaDir.Flg_Activo = Variables.Activo;
                                vPersonaDir.Fec_Ingreso = Variables.Hoy;
                                vPersonaDir.Fec_Modifica = Variables.Hoy;
                                vPersonaDir.Usu_Ingreso = vCliente.Usu_Ingreso;
                                vPersonaDir.Usu_Modifica = vCliente.Usu_Modifica;
                                vPersonaDir = new Tb_Domicilio_AD().Update(vPersonaDir);
                                #endregion

                                #region Insertar Celular y Correo electronico

                                new Tb_Medio_Contacto_AD().Insert(new Tb_Medio_Contacto()
                                {
                                    Fec_Ingreso = Variables.Hoy,
                                    Fec_Modifica = Variables.Hoy,
                                    Flg_Activo = Variables.Activo,
                                    Id_Medio_Contacto = 0,
                                    Id_Persona = vPersona.Id_Persona,
                                    Id_Tipo_Medio_Contacto = (int)EnumMedioContacto.CORREO,
                                    Nombre_Medio_Contacto = vCliente.Email,
                                    Usu_Ingreso = vCliente.Usu_Ingreso,
                                    Usu_Modifica = vCliente.Usu_Ingreso
                                });

                                new Tb_Medio_Contacto_AD().Insert(new Tb_Medio_Contacto()
                                {
                                    Fec_Ingreso = Variables.Hoy,
                                    Fec_Modifica = Variables.Hoy,
                                    Flg_Activo = Variables.Activo,
                                    Id_Medio_Contacto = 0,
                                    Id_Persona = vPersona.Id_Persona,
                                    Id_Tipo_Medio_Contacto = (int)EnumMedioContacto.CELULAR,
                                    Nombre_Medio_Contacto = vCliente.Celular,
                                    Usu_Ingreso = vCliente.Usu_Ingreso,
                                    Usu_Modifica = vCliente.Usu_Ingreso
                                });
                                #endregion
                            }
                        }
                    }
                    else
                    {
                        var vPersonaJ = new Tb_Persona_Juridica_AD().GetRegistry("", vCliente.NroDocumento);
                        //Datos para GP
                        #region Registrar en GP
                        vCliente.NombreCompleto = vCliente.PrimerNombre.Trim().ToUpper();
                        var Temp = new Tb_Ubigeo_AD().GetRegistry(vCliente.Id_Ubigeo);
                        vCliente.Distrito = Temp.Distrito;
                        vCliente.Provincia = Temp.Provincia;
                        vCliente.Departamento = Temp.Departamento;
                        vCliente.Pais = Variables.Pais;
                        vCliente.Direccion1 = vCliente.Direccion1.Trim().ToUpper();
                        vCliente.Direccion2 = vCliente.Direccion1.Trim().ToUpper();
                        vCliente.TipoDocumento = vCliente.TipoDocumento;
                        vCliente.Colegiado = Variables.Colegiado;
                        vCliente.Total_Reg = new Cliente_AD().GrabarDatos(vCliente);
                        vCliente.Opcional = (vCliente.Total_Reg == 1) ? "OK" : "ERROR";
                        #endregion
                        //Datos para BD LOCAL
                        if (vCliente.Total_Reg == 1)
                        {
                            if (vPersonaJ == null)
                            {
                                #region Insertar en Persona
                                var vPersona = new Tb_Persona();
                                vPersona.Fec_Ingreso = Variables.Hoy;
                                vPersona.Fec_Modifica = Variables.Hoy;
                                vPersona.Usu_Ingreso = vCliente.Usu_Ingreso;
                                vPersona.Usu_Modifica = vCliente.Usu_Ingreso;
                                vPersona.Flg_Activo = Variables.Activo;
                                vPersona.Flg_Nacionalidad = Variables.Activo;
                                vPersona.Id_Tipo_Persona = Variables.Juridico;
                                vPersona.Nombre_Comercial = vCliente.NombreCompleto;
                                vPersona.Nombre_Completo = vCliente.NombreCompleto;
                                vPersona.Ruc = vCliente.NroDocumento;
                                new Tb_Persona_AD().Insert(vPersona);
                                #endregion

                                #region Insertar Persona Juridica

                                vPersonaJ = new Tb_Persona_Juridica();
                                vPersonaJ.Id_Persona = vPersona.Id_Persona;
                                vPersonaJ.Razon_Social = vCliente.PrimerNombre.Trim();
                                vPersonaJ.Direccion = vCliente.Direccion1;
                                vPersonaJ.Id_Consejo_Juridico = vCliente.Id_Consejo;
                                vPersonaJ.Id_Grupo_Juridico = vCliente.Id_Grupo;
                                vPersonaJ.Id_Origen_Juridico = vCliente.Id_Sector;
                                vPersonaJ.Id_Ubigeo = vCliente.Id_Ubigeo;
                                vPersonaJ.Fec_Ingreso = Variables.Hoy;
                                vPersonaJ.Fec_Modifica = Variables.Hoy;
                                vPersonaJ.Usu_Ingreso = vCliente.Usu_Ingreso;
                                vPersonaJ.Usu_Modifica = vCliente.Usu_Modifica;
                                vPersonaJ.Flg_Activo = Variables.Activo;
                                vPersonaJ = new Tb_Persona_Juridica_AD().Insert(vPersonaJ);
                                #endregion

                                #region Insertar en Domicilio
                                var vPersonaDir = new Tb_Domicilio();
                                vPersonaDir.Id_Domicilio = 0;
                                vPersonaDir.Id_Persona = vPersona.Id_Persona;
                                vPersonaDir.Id_Pais = Variables.Peru;
                                vPersonaDir.Id_Tipo_Via = 0;
                                vPersonaDir.Nombre_Via = "";
                                vPersonaDir.Nro_Via = "";
                                vPersonaDir.Nro_Km = "";
                                vPersonaDir.Manzana = "";
                                vPersonaDir.Lote = "";
                                vPersonaDir.Nro_Interior = "";
                                vPersonaDir.Nro_Departamento = "";
                                vPersonaDir.Id_Tipo_Zona = 0;
                                vPersonaDir.Nombre_Zona = "";
                                vPersonaDir.Referencia = "";
                                vPersonaDir.Domicilio_Completo = vCliente.Direccion1;
                                vPersonaDir.Id_Ubigeo = vCliente.Id_Ubigeo;
                                vPersonaDir.Flg_Domicilio_Fiscal = Variables.Activo;
                                vPersonaDir.Seccion = "";
                                vPersonaDir.Flg_Activo = Variables.Activo;
                                vPersonaDir.Fec_Ingreso = Variables.Hoy;
                                vPersonaDir.Fec_Modifica = Variables.Hoy;
                                vPersonaDir.Usu_Ingreso = vCliente.Usu_Ingreso;
                                vPersonaDir.Usu_Modifica = vCliente.Usu_Modifica;
                                vPersonaDir = new Tb_Domicilio_AD().Insert(vPersonaDir);
                                #endregion
                            }
                            else
                            {
                                #region Actualizar Persona
                                var vPersona = new Tb_Persona_AD().GetRegistry(vPersonaJ.Id_Persona);
                                vPersona.Fec_Ingreso = Variables.Hoy;
                                vPersona.Fec_Modifica = Variables.Hoy;
                                vPersona.Usu_Ingreso = vCliente.Usu_Ingreso;
                                vPersona.Usu_Modifica = vCliente.Usu_Ingreso;
                                vPersona.Flg_Activo = Variables.Activo;
                                vPersona.Id_Tipo_Persona = Variables.Juridico;
                                vPersona.Nombre_Comercial = vCliente.NombreCompleto;
                                vPersona.Nombre_Completo = vCliente.NombreCompleto;
                                new Tb_Persona_AD().Update(vPersona);
                                #endregion

                                #region Actualizar Persona Juridica
                                vPersonaJ.Razon_Social = vCliente.PrimerNombre.Trim();
                                vPersonaJ.Direccion = vCliente.Direccion1;
                                vPersonaJ.Id_Consejo_Juridico = vCliente.Id_Consejo;
                                vPersonaJ.Id_Grupo_Juridico = vCliente.Id_Grupo;
                                vPersonaJ.Id_Origen_Juridico = vCliente.Id_Sector;
                                vPersonaJ.Id_Ubigeo = vCliente.Id_Ubigeo;
                                vPersonaJ.Fec_Ingreso = Variables.Hoy;
                                vPersonaJ.Fec_Modifica = Variables.Hoy;
                                vPersonaJ.Usu_Ingreso = vCliente.Usu_Ingreso;
                                vPersonaJ.Usu_Modifica = vCliente.Usu_Modifica;
                                vPersonaJ = new Tb_Persona_Juridica_AD().Update(vPersonaJ);
                                #endregion

                                #region Actualiza el Domicilio
                                var vPersonaDir = new Tb_Domicilio_AD().GetRegistry(vPersonaJ.Id_Persona);
                                vPersonaDir.Domicilio_Completo = vCliente.Direccion1;
                                vPersonaDir.Id_Ubigeo = vCliente.Id_Ubigeo;
                                vPersonaDir.Flg_Domicilio_Fiscal = Variables.Activo;
                                vPersonaDir.Flg_Activo = Variables.Activo;
                                vPersonaDir.Fec_Ingreso = Variables.Hoy;
                                vPersonaDir.Fec_Modifica = Variables.Hoy;
                                vPersonaDir.Usu_Ingreso = vCliente.Usu_Ingreso;
                                vPersonaDir.Usu_Modifica = vCliente.Usu_Modifica;
                                vPersonaDir = new Tb_Domicilio_AD().Update(vPersonaDir);
                                #endregion
                            }
                        }
                    }

                    vTrans.Complete();
                    vTrans.Dispose();
                    vCliente.Opcional = "OK";
                    return vCliente;
                }
                catch (Exception ex)
                {
                    vTrans.Dispose();
                    vCliente.Opcional = "CANCEL";
                    Log.Error(ex.Message, ex);
                    throw;
                }
            }
        }

        public ClienteClover Obtener(string vId, int vTipo)
        {
            try
            {
                return new ClienteClover() { TipoPersona = vTipo };
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public List<ClienteClover> Listar(string vValor)
        {
            try
            {
                return new Cliente_AD().List_Cliente(vValor);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public List<Tb_Maestras> List_Direccion(string vIdCliente)
        {
            try
            {
                return new Cliente_AD().List_Direccion(vIdCliente);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        #endregion
    }
}
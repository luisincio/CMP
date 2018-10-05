/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Persona_Juridica_LN.cs
Objetivo          : Clase referida a los métodos de Lógica de Negocio de la clase Tb_Persona_Juridica
Autor             : CMP-SISTEMAS (FRR)
Fecha Creación    : 09/06/2018
Métodos           : List, GetRegistry, Insert, Update, Delete   
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
    public class Tb_Persona_Juridica_LN : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Persona_Juridica
        /// </summary>
        /// <returns>Retorna una lista de objetos de tipo Tb_Persona_Juridica</returns>
        public List<Tb_Persona_Juridica> List(int vId_Consejo = 0)
        {
            try
            {
                return new Tb_Persona_Juridica_AD().List(vId_Consejo);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Método que recupera un regustro del tipo Tb_Persona_Juridica basado en su clave primaria
        /// </summary>
        /// <param name="Id_Persona">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Persona_Juridica GetRegistry(int vId_Persona)
        {
            try
            {
                return new Tb_Persona_Juridica_AD().GetRegistry(vId_Persona);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Inserta un Objeto del tipo Tb_Persona_Juridica
        /// </summary>
        /// <param name="Tb_Persona_Juridica">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizado</returns>
        public Tb_Persona_Juridica Insert(Tb_Persona_Juridica vTb_Persona_Juridica)
        {
            try
            {
                return new Tb_Persona_Juridica_AD().Insert(vTb_Persona_Juridica);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Persona_Juridica
        /// </summary>
        /// <param name="Tb_Persona_Juridica">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Persona_Juridica Update(Tb_Persona_Juridica vTb_Persona_Juridica)
        {
            try
            {
                return new Tb_Persona_Juridica_AD().Update(vTb_Persona_Juridica);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Método que eliminara un registo del tipo Tb_Persona_Juridica en base a su clave primaria
        /// </summary>
        /// <param name="Id_Persona">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Persona, string vUsuario, DateTime vFecha)
        {
            try
            {
                return new Tb_Persona_Juridica_AD().Delete(vId_Persona, vUsuario, vFecha);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        #endregion

        #region Métodos Extendidos

        public EmpresaMin Grabar(EmpresaMin vEmpresa)
        {
            using (var Full = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                try
                {
                    vEmpresa.Fec_Ingreso = vEmpresa.Fec_Modifica = Variables.Hoy;
                    vEmpresa.Flg_Activo = Variables.Activo;

                    if (vEmpresa.Id_Persona == 0)
                    {
                        Tb_Persona Temp = new Tb_Persona_AD().Insert(new Tb_Persona()
                        {
                            Fec_Ingreso = Variables.Hoy,
                            Fec_Modifica = Variables.Hoy,
                            Flg_Activo = Variables.Activo,
                            Flg_Nacionalidad = "1",
                            Id_Tipo_Persona = Variables.Juridico,
                            Nombre_Comercial = vEmpresa.Razon_Social,
                            Nombre_Completo = vEmpresa.Razon_Social,
                            Ruc = vEmpresa.Ruc,
                            Usu_Ingreso = vEmpresa.Usu_Ingreso,
                            Usu_Modifica = vEmpresa.Usu_Modifica
                        });
                        vEmpresa.Id_Persona = Temp.Id_Persona;

                        new Tb_Persona_Juridica_AD().Insert(new Tb_Persona_Juridica()
                        {
                            Id_Origen_Juridico = vEmpresa.Id_Origen_Juridico,
                            Id_Grupo_Juridico = vEmpresa.Id_Grupo_Juridico,
                            Id_Consejo_Juridico = vEmpresa.Id_Consejo_Juridico,
                            Direccion = vEmpresa.Direccion,
                            Fec_Ingreso = vEmpresa.Fec_Ingreso,
                            Fec_Modifica = vEmpresa.Fec_Ingreso,
                            Flg_Activo = Variables.Activo,
                            Id_Persona = Temp.Id_Persona,
                            Id_Ubigeo = vEmpresa.Id_Ubigeo,
                            Razon_Social = vEmpresa.Razon_Social,
                            Usu_Ingreso = vEmpresa.Usu_Ingreso,
                            Usu_Modifica = vEmpresa.Usu_Ingreso
                        });
                    }
                    else
                    {
                        Tb_Persona Temp = new Tb_Persona_AD().GetRegistry(vEmpresa.Id_Persona);
                        Temp.Fec_Modifica = Variables.Hoy;
                        Temp.Flg_Activo = Variables.Activo;
                        Temp.Flg_Nacionalidad = "1";
                        Temp.Id_Tipo_Persona = Variables.Juridico;
                        Temp.Nombre_Comercial = vEmpresa.Razon_Social;
                        Temp.Nombre_Completo = vEmpresa.Razon_Social;
                        Temp.Usu_Modifica = vEmpresa.Usu_Modifica;
                        Temp = new Tb_Persona_AD().Update(Temp);

                        Tb_Persona_Juridica Temp2 = new Tb_Persona_Juridica_AD().GetRegistry(vEmpresa.Id_Persona);
                        Temp2.Id_Origen_Juridico = vEmpresa.Id_Origen_Juridico;
                        Temp2.Id_Grupo_Juridico = vEmpresa.Id_Grupo_Juridico;
                        Temp2.Id_Consejo_Juridico = vEmpresa.Id_Consejo_Juridico;
                        Temp2.Direccion = vEmpresa.Direccion;
                        Temp2.Fec_Modifica = vEmpresa.Fec_Modifica;
                        Temp2.Flg_Activo = Variables.Activo;
                        Temp2.Id_Ubigeo = vEmpresa.Id_Ubigeo;
                        Temp2.Razon_Social = vEmpresa.Razon_Social;

                        Temp2 = new Tb_Persona_Juridica_AD().Update(Temp2);
                    }

                    var Ubigeo = new Tb_Ubigeo_AD().GetRegistry(vEmpresa.Id_Ubigeo);

                    var y = new Cliente_AD().Grabar(new ClienteNJ()
                    {
                        ApellidoMaterno = "",
                        ApellidoPaterno = "",
                        Departamento = Ubigeo.Departamento,
                        Direccion = vEmpresa.Direccion,
                        Distrito = Ubigeo.Distrito,
                        NroDocumento = vEmpresa.Ruc,
                        PrimerNombre = "",
                        Provincia = Ubigeo.Provincia,
                        RazonSocial = vEmpresa.Razon_Social,
                        SegundoNombre = "",
                        TipoDocumento = (int)EnumTipoDocumentoGP.RUC,
                        TipoPersona = (int)EnumTipoPersonaGP.JURIDICA
                    });

                    if (y <= 1)
                    {
                        vEmpresa.Opcional = "OK";
                        Full.Complete();
                    }
                    else
                    {
                        vEmpresa.Opcional = "ERR";
                    }
                    Full.Dispose();
                    return vEmpresa;
                }
                catch (Exception ex)
                {
                    vEmpresa.Opcional = "ERR";
                    Log.Error(ex.Message, ex);
                    Full.Dispose();
                    throw;
                }
            }
        }

        #endregion
    }
}

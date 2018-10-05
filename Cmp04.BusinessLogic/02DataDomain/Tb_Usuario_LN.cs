/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Usuario_LN.cs
Objetivo          : Clase referida a los métodos de Lógica de Negocio de la clase Tb_Usuario
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
#endregion

namespace Cmp04.BusinessLogic
{
    public class Tb_Usuario_LN : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Usuario
        /// </summary>
        /// <returns>Retorna una lista de objetos de tipo Tb_Usuario</returns>
        public List<Tb_Usuario> List()
        {
            try
            {
                return new Tb_Usuario_AD().List();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Método que recupera un regustro del tipo Tb_Usuario basado en su clave primaria
        /// </summary>
        /// <param name="Id_Usuario">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Usuario GetRegistry(int vId_Usuario)
        {
            try
            {
                return (vId_Usuario == 0)? new Tb_Usuario():  new Tb_Usuario_AD().GetRegistry(vId_Usuario);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }
        
        /// <summary>
        /// Inserta un Objeto del tipo Tb_Usuario
        /// </summary>
        /// <param name="Tb_Usuario">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizado</returns>
        public Tb_Usuario Insert(Tb_Usuario vTb_Usuario)
        {
            try
            {
                return new Tb_Usuario_AD().Insert(vTb_Usuario);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Usuario
        /// </summary>
        /// <param name="Tb_Usuario">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Usuario Update(Tb_Usuario vTb_Usuario)
        {
            try
            {
                return new Tb_Usuario_AD().Update(vTb_Usuario);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }
                
        /// <summary>
        /// Método que eliminara un registo del tipo Tb_Usuario en base a su clave primaria
        /// </summary>
        /// <param name="Id_Usuario">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Usuario, string vUsuario, DateTime vFecha)
        {
            try
            {
                return new Tb_Usuario_AD().Delete(vId_Usuario, vUsuario, vFecha);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }
        
        #endregion

        public List<Tb_Usuario> List(string vValor)
        {
            try
            {
                return new Tb_Usuario_AD().List(vValor);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public Tb_Usuario Grabar(Tb_Usuario vTb_Usuario)
        {
            vTb_Usuario.Fec_Ingreso = vTb_Usuario.Fec_Modifica = Variables.Hoy;
            vTb_Usuario.Flg_Activo = Variables.Activo;
            try
            {
                if (new Tb_Usuario_AD().GetRegistry(vTb_Usuario.Id_Usuario) == null)
                {
                    new Tb_Usuario_AD().Insert(vTb_Usuario);
                    new Tb_Colegiado_Consejo_AD().Insert(new Tb_Colegiado_Consejo() { Id_Persona = vTb_Usuario.Id_Usuario, Id_Consejo_Regional = vTb_Usuario.Id_Consejo_Regional, Flg_Activo = Variables.Activo, Usu_Ingreso = vTb_Usuario.Usu_Ingreso, Usu_Modifica = vTb_Usuario.Usu_Modifica, Fec_Ingreso = Variables.Hoy, Fec_Modifica = Variables.Hoy });
                }
                else
                {
                    new Tb_Usuario_AD().Update(vTb_Usuario);
                    if (new Tb_Usuario_AD().GetRegistry(vTb_Usuario.Id_Usuario).Id_Consejo_Regional != vTb_Usuario.Id_Consejo_Regional) new Tb_Colegiado_Consejo_AD().Insert(new Tb_Colegiado_Consejo() { Id_Persona = vTb_Usuario.Id_Usuario, Id_Consejo_Regional = vTb_Usuario.Id_Consejo_Regional, Flg_Activo = Variables.Activo, Usu_Ingreso = vTb_Usuario.Usu_Ingreso, Usu_Modifica = vTb_Usuario.Usu_Modifica, Fec_Ingreso = Variables.Hoy, Fec_Modifica = Variables.Hoy });
                }
                vTb_Usuario.Opcional = "OK";
                return vTb_Usuario;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }
        public Tb_Usuario GetRegistry_Perfil(int vId_Usuario)
        {
            try
            {
                return (vId_Usuario == 0) ? new Tb_Usuario() : new Tb_Usuario_AD().GetRegistry_Perfil(vId_Usuario);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public Tb_Usuario GetRegistry(string vUsuario, string vClave)
        {
            try
            {
                return new Tb_Usuario_AD().GetRegistry(vUsuario, vClave);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }
    }
}

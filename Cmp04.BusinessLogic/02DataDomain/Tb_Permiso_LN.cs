/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Permiso_LN.cs
Objetivo          : Clase referida a los métodos de Lógica de Negocio de la clase Tb_Permiso
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
    public class Tb_Permiso_LN : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Permiso
        /// </summary>
        /// <returns>Retorna una lista de objetos de tipo Tb_Permiso</returns>
        public List<Tb_Permiso> List()
        {
            try
            {
                return new Tb_Permiso_AD().List();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Método que recupera un regustro del tipo Tb_Permiso basado en su clave primaria
        /// </summary>
        /// <param name="Id_Permiso">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Permiso GetRegistry(int vId_Permiso)
        {
            try
            {
                return (vId_Permiso == 0) ? new Tb_Permiso() : new Tb_Permiso_AD().GetRegistry(vId_Permiso);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }
        
        /// <summary>
        /// Inserta un Objeto del tipo Tb_Permiso
        /// </summary>
        /// <param name="Tb_Permiso">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizado</returns>
        public Tb_Permiso Insert(Tb_Permiso vTb_Permiso)
        {
            try
            {
                return new Tb_Permiso_AD().Insert(vTb_Permiso);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Permiso
        /// </summary>
        /// <param name="Tb_Permiso">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Permiso Update(Tb_Permiso vTb_Permiso)
        {
            try
            {
                return new Tb_Permiso_AD().Update(vTb_Permiso);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }
                
        /// <summary>
        /// Método que eliminara un registo del tipo Tb_Permiso en base a su clave primaria
        /// </summary>
        /// <param name="Id_Permiso">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Permiso, string vUsuario, DateTime vFecha)
        {
            try
            {
                return new Tb_Permiso_AD().Delete(vId_Permiso, vUsuario, vFecha);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }
        
        #endregion

        public List<Tb_Permiso> List(string vValor, int vId_Perfil = 0)
        {
            try
            {
                return new Tb_Permiso_AD().List(vValor, vId_Perfil);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public List<Tb_Permiso> List(int vId_Usuario)
        {
            try
            {
                return new Tb_Permiso_AD().List(vId_Usuario);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public Tb_Permiso Grabar(Tb_Permiso vTb_Permiso)
        {
            vTb_Permiso.Fec_Ingreso = vTb_Permiso.Fec_Modifica = Variables.Hoy;
            vTb_Permiso.Flg_Activo = Variables.Activo;
            try
            {
                if (new Tb_Permiso_AD().GetRegistry(vTb_Permiso.Id_Permiso) == null)
                {
                    new Tb_Permiso_AD().Insert(vTb_Permiso);
                }
                else
                {
                    new Tb_Permiso_AD().Update(vTb_Permiso);
                }
                vTb_Permiso.Opcional = "OK";
                return vTb_Permiso;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }
    }
}

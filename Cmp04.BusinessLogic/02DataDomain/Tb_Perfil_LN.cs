/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Perfil_LN.cs
Objetivo          : Clase referida a los métodos de Lógica de Negocio de la clase Tb_Perfil
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
    public class Tb_Perfil_LN : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Perfil
        /// </summary>
        /// <returns>Retorna una lista de objetos de tipo Tb_Perfil</returns>
        public List<Tb_Perfil> List()
        {
            try
            {
                return new Tb_Perfil_AD().List();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Método que recupera un regustro del tipo Tb_Perfil basado en su clave primaria
        /// </summary>
        /// <param name="Id_Perfil">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Perfil GetRegistry(int vId_Perfil)
        {
            try
            {
                return (vId_Perfil == 0) ? new Tb_Perfil() : new Tb_Perfil_AD().GetRegistry(vId_Perfil);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }
        
        /// <summary>
        /// Inserta un Objeto del tipo Tb_Perfil
        /// </summary>
        /// <param name="Tb_Perfil">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizado</returns>
        public Tb_Perfil Insert(Tb_Perfil vTb_Perfil)
        {
            try
            {
                return new Tb_Perfil_AD().Insert(vTb_Perfil);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Perfil
        /// </summary>
        /// <param name="Tb_Perfil">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Perfil Update(Tb_Perfil vTb_Perfil)
        {
            try
            {
                return new Tb_Perfil_AD().Update(vTb_Perfil);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }
                
        /// <summary>
        /// Método que eliminara un registo del tipo Tb_Perfil en base a su clave primaria
        /// </summary>
        /// <param name="Id_Perfil">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Perfil, string vUsuario, DateTime vFecha)
        {
            try
            {
                return new Tb_Perfil_AD().Delete(vId_Perfil, vUsuario, vFecha);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }
        
        #endregion

        public List<Tb_Perfil> List(string vValor)
        {
            try
            {
                return new Tb_Perfil_AD().List(vValor);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }
        public Tb_Perfil Grabar(Tb_Perfil vTb_Perfil)
        {
            vTb_Perfil.Fec_Ingreso = vTb_Perfil.Fec_Modifica = Variables.Hoy;
            vTb_Perfil.Flg_Activo = Variables.Activo;
            try
            {
                if (new Tb_Perfil_AD().GetRegistry(vTb_Perfil.Id_Perfil) == null)
                {
                    new Tb_Perfil_AD().Insert(vTb_Perfil);
                }
                else
                {
                    new Tb_Perfil_AD().Update(vTb_Perfil);
                }
                vTb_Perfil.Opcional = "OK";
                return vTb_Perfil;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }
    }
}

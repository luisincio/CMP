/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Servicios_LN.cs
Objetivo          : Clase referida a los métodos de Lógica de Negocio de la clase Tb_Servicios
Autor             : CMP-SISTEMAS (FRR)
Fecha Creación    : 09/06/2018
Métodos           : List, GetRegistry, Insert, Update, Delete   
----------------------------------------------------------------------------------------*/
#region Espacios de Nombres
using Cmp03.DataAccess;
using Cmp02.Entities;
using System;
using System.Collections.Generic;
#endregion

namespace Cmp04.BusinessLogic
{
    public class Tb_Servicios_LN : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Servicios
        /// </summary>
        /// <returns>Retorna una lista de objetos de tipo Tb_Servicios</returns>
        public List<Tb_Servicios> List()
        {
            try
            {
                return new Tb_Servicios_AD().List();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Método que recupera un regustro del tipo Tb_Servicios basado en su clave primaria
        /// </summary>
        /// <param name="Id_Servicio">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Servicios GetRegistry(int vId_Servicio)
        {
            try
            {
                return new Tb_Servicios_AD().GetRegistry(vId_Servicio);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }
        
        /// <summary>
        /// Inserta un Objeto del tipo Tb_Servicios
        /// </summary>
        /// <param name="Tb_Servicios">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizado</returns>
        public Tb_Servicios Insert(Tb_Servicios vTb_Servicios)
        {
            try
            {
                return new Tb_Servicios_AD().Insert(vTb_Servicios);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Servicios
        /// </summary>
        /// <param name="Tb_Servicios">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Servicios Update(Tb_Servicios vTb_Servicios)
        {
            try
            {
                return new Tb_Servicios_AD().Update(vTb_Servicios);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }
                
        /// <summary>
        /// Método que eliminara un registo del tipo Tb_Servicios en base a su clave primaria
        /// </summary>
        /// <param name="Id_Servicio">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Servicio, string vUsuario, DateTime vFecha)
        {
            try
            {
                return new Tb_Servicios_AD().Delete(vId_Servicio, vUsuario, vFecha);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }
        
        #endregion

        #region Métodos Extendidos

        public List<Tb_Servicios> List(string vDescripcion)
        {
            try
            {
                return new Tb_Servicios_AD().List(vDescripcion);
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

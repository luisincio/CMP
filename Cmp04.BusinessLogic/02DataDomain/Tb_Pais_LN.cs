/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Pais_LN.cs
Objetivo          : Clase referida a los métodos de Lógica de Negocio de la clase Tb_Pais
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
    public class Tb_Pais_LN : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Pais
        /// </summary>
        /// <returns>Retorna una lista de objetos de tipo Tb_Pais</returns>
        public List<Tb_Pais> List()
        {
            try
            {
                return new Tb_Pais_AD().List();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Método que recupera un regustro del tipo Tb_Pais basado en su clave primaria
        /// </summary>
        /// <param name="Id_Pais">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Pais GetRegistry(int vId_Pais)
        {
            try
            {
                return new Tb_Pais_AD().GetRegistry(vId_Pais);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }
        
        /// <summary>
        /// Inserta un Objeto del tipo Tb_Pais
        /// </summary>
        /// <param name="Tb_Pais">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizado</returns>
        public Tb_Pais Insert(Tb_Pais vTb_Pais)
        {
            try
            {
                return new Tb_Pais_AD().Insert(vTb_Pais);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Pais
        /// </summary>
        /// <param name="Tb_Pais">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Pais Update(Tb_Pais vTb_Pais)
        {
            try
            {
                return new Tb_Pais_AD().Update(vTb_Pais);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }
                
        /// <summary>
        /// Método que eliminara un registo del tipo Tb_Pais en base a su clave primaria
        /// </summary>
        /// <param name="Id_Pais">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Pais, string vUsuario, DateTime vFecha)
        {
            try
            {
                return new Tb_Pais_AD().Delete(vId_Pais, vUsuario, vFecha);
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

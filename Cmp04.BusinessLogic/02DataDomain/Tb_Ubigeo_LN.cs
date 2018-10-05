/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Ubigeo_LN.cs
Objetivo          : Clase referida a los métodos de Lógica de Negocio de la clase Tb_Ubigeo
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
    public class Tb_Ubigeo_LN : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Ubigeo
        /// </summary>
        /// <returns>Retorna una lista de objetos de tipo Tb_Ubigeo</returns>
        public List<Tb_Ubigeo> List()
        {
            try
            {
                return new Tb_Ubigeo_AD().List();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Método que recupera un regustro del tipo Tb_Ubigeo basado en su clave primaria
        /// </summary>
        /// <param name="Id_Ubigeo">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Ubigeo GetRegistry(string vId_Ubigeo)
        {
            try
            {
                return new Tb_Ubigeo_AD().GetRegistry(vId_Ubigeo);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Inserta un Objeto del tipo Tb_Ubigeo
        /// </summary>
        /// <param name="Tb_Ubigeo">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizado</returns>
        public Tb_Ubigeo Insert(Tb_Ubigeo vTb_Ubigeo)
        {
            try
            {
                return new Tb_Ubigeo_AD().Insert(vTb_Ubigeo);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Ubigeo
        /// </summary>
        /// <param name="Tb_Ubigeo">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Ubigeo Update(Tb_Ubigeo vTb_Ubigeo)
        {
            try
            {
                return new Tb_Ubigeo_AD().Update(vTb_Ubigeo);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Método que eliminara un registo del tipo Tb_Ubigeo en base a su clave primaria
        /// </summary>
        /// <param name="Id_Ubigeo">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(string vId_Ubigeo, string vUsuario, DateTime vFecha)
        {
            try
            {
                return new Tb_Ubigeo_AD().Delete(vId_Ubigeo, vUsuario, vFecha);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        #endregion


        public Tb_Ubigeo GetRegistry(int vId)
        {
            throw new NotImplementedException();
        }

        public int Delete(int vId, string vUsuario, DateTime vFecha)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método que lista los registros de Tb_Ubigeo
        /// </summary>
        /// <returns>Retorna una lista de objetos de tipo Tb_Ubigeo</returns>
        public List<Tb_Ubigeo> List(string vData)
        {
            try
            {
                return new Tb_Ubigeo_AD().List(vData);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }
    }
}

/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Colegiado_Carnet_LN.cs
Objetivo          : Clase referida a los métodos de Lógica de Negocio de la clase Tb_Colegiado_Carnet
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
    public class Tb_Colegiado_Carnet_LN : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Colegiado_Carnet
        /// </summary>
        /// <returns>Retorna una lista de objetos de tipo Tb_Colegiado_Carnet</returns>
        public List<Tb_Colegiado_Carnet> List()
        {
            try
            {
                return new Tb_Colegiado_Carnet_AD().List();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Método que recupera un regustro del tipo Tb_Colegiado_Carnet basado en su clave primaria
        /// </summary>
        /// <param name="Id_Carnet">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Colegiado_Carnet GetRegistry(int vId_Carnet)
        {
            try
            {
                return new Tb_Colegiado_Carnet_AD().GetRegistry(vId_Carnet);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }
        
        /// <summary>
        /// Inserta un Objeto del tipo Tb_Colegiado_Carnet
        /// </summary>
        /// <param name="Tb_Colegiado_Carnet">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizado</returns>
        public Tb_Colegiado_Carnet Insert(Tb_Colegiado_Carnet vTb_Colegiado_Carnet)
        {
            try
            {
                return new Tb_Colegiado_Carnet_AD().Insert(vTb_Colegiado_Carnet);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Colegiado_Carnet
        /// </summary>
        /// <param name="Tb_Colegiado_Carnet">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Colegiado_Carnet Update(Tb_Colegiado_Carnet vTb_Colegiado_Carnet)
        {
            try
            {
                return new Tb_Colegiado_Carnet_AD().Update(vTb_Colegiado_Carnet);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }
                
        /// <summary>
        /// Método que eliminara un registo del tipo Tb_Colegiado_Carnet en base a su clave primaria
        /// </summary>
        /// <param name="Id_Carnet">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Carnet, string vUsuario, DateTime vFecha)
        {
            try
            {
                return new Tb_Colegiado_Carnet_AD().Delete(vId_Carnet, vUsuario, vFecha);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }
        
        #endregion

        public DateTime Actualizar_Emision(int vId_Carnet, bool vAccion, string vUsuario)
        {
            try
            {
                return new Tb_Colegiado_Carnet_AD().Actualizar_Emision(vId_Carnet, vAccion, vUsuario, Variables.Hoy);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public DateTime Actualizar_Entrega(int vId_Carnet, bool vAccion, string vUsuario)
        {
            try
            {
                return new Tb_Colegiado_Carnet_AD().Actualizar_Entrega(vId_Carnet, vAccion, vUsuario, Variables.Hoy);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }
    }
}

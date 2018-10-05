/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Persona_Directivo_LN.cs
Objetivo          : Clase referida a los métodos de Lógica de Negocio de la clase Tb_Persona_Directivo
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
    public class Tb_Persona_Directivo_LN : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Persona_Directivo
        /// </summary>
        /// <returns>Retorna una lista de objetos de tipo Tb_Persona_Directivo</returns>
        public List<Tb_Persona_Directivo> List(int vConsejo, string vPeriodo)
        {
            try
            {
                return new Tb_Persona_Directivo_AD().List(vConsejo, vPeriodo);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Método que recupera un regustro del tipo Tb_Persona_Directivo basado en su clave primaria
        /// </summary>
        /// <param name="Id_Directivo">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Persona_Directivo GetRegistry(int vId_Directivo)
        {
            try
            {
                return (vId_Directivo == 0) ? new Tb_Persona_Directivo() { Id_Directivo = 0 } : new Tb_Persona_Directivo_AD().GetRegistry(vId_Directivo);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }
        
        /// <summary>
        /// Inserta un Objeto del tipo Tb_Persona_Directivo
        /// </summary>
        /// <param name="Tb_Persona_Directivo">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizado</returns>
        public Tb_Persona_Directivo Save(Tb_Persona_Directivo vTb_Persona_Directivo)
        {
            try
            {
                vTb_Persona_Directivo.Fec_Ingreso = vTb_Persona_Directivo.Fec_Modifica = Variables.Hoy;
                vTb_Persona_Directivo.Fec_Inicio = Convert.ToDateTime( "01/01/" + vTb_Persona_Directivo.Periodo.Substring(0, 4));
                vTb_Persona_Directivo.Fec_Termino = Convert.ToDateTime("31/12/" + vTb_Persona_Directivo.Periodo.Substring(vTb_Persona_Directivo.Periodo.Length - 4, 4));
                vTb_Persona_Directivo.Flg_Activo = Variables.Activo;
                vTb_Persona_Directivo = (vTb_Persona_Directivo.Id_Directivo == 0) ? new Tb_Persona_Directivo_AD().Insert(vTb_Persona_Directivo) : new Tb_Persona_Directivo_AD().Update(vTb_Persona_Directivo);
                vTb_Persona_Directivo.Opcional = "OK";
                return vTb_Persona_Directivo;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }
                
        /// <summary>
        /// Método que eliminara un registo del tipo Tb_Persona_Directivo en base a su clave primaria
        /// </summary>
        /// <param name="Id_Directivo">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Directivo, string vUsuario)
        {
            try
            {
                return new Tb_Persona_Directivo_AD().Delete(vId_Directivo, vUsuario, Variables.Hoy);
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

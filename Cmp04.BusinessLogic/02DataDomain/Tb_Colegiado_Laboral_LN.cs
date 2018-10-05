/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Colegiado_Laboral_LN.cs
Objetivo          : Clase referida a los métodos de Lógica de Negocio de la clase Tb_Colegiado_Laboral
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
    public class Tb_Colegiado_Laboral_LN : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Colegiado_Laboral
        /// </summary>
        /// <returns>Retorna una lista de objetos de tipo Tb_Colegiado_Laboral</returns>
        public List<Tb_Colegiado_Laboral> List()
        {
            try
            {
                return new Tb_Colegiado_Laboral_AD().List();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Método que recupera un regustro del tipo Tb_Colegiado_Laboral basado en su clave primaria
        /// </summary>
        /// <param name="Id_Informacion_Laboral">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Colegiado_Laboral GetRegistry(int vId_Informacion_Laboral)
        {
            try
            {
                return new Tb_Colegiado_Laboral_AD().GetRegistry(vId_Informacion_Laboral);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Inserta un Objeto del tipo Tb_Colegiado_Laboral
        /// </summary>
        /// <param name="Tb_Colegiado_Laboral">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizado</returns>
        public Tb_Colegiado_Laboral Insert(Tb_Colegiado_Laboral vTb_Colegiado_Laboral)
        {
            try
            {
                return new Tb_Colegiado_Laboral_AD().Insert(vTb_Colegiado_Laboral);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Colegiado_Laboral
        /// </summary>
        /// <param name="Tb_Colegiado_Laboral">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Colegiado_Laboral Update(Tb_Colegiado_Laboral vTb_Colegiado_Laboral)
        {
            try
            {
                return new Tb_Colegiado_Laboral_AD().Update(vTb_Colegiado_Laboral);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Método que eliminara un registo del tipo Tb_Colegiado_Laboral en base a su clave primaria
        /// </summary>
        /// <param name="Id_Informacion_Laboral">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Informacion_Laboral, string vUsuario, DateTime vFecha)
        {
            try
            {
                return new Tb_Colegiado_Laboral_AD().Delete(vId_Informacion_Laboral, vUsuario, vFecha);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        #endregion


        #region Métodos Extendidos

        public List<Tb_Colegiado_Laboral> List(int vId)
        {
            try
            {
                return new Tb_Colegiado_Laboral_AD().List(vId);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public Tb_Colegiado_Laboral Grabar(Tb_Colegiado_Laboral vTb_Colegiado_Laboral)
        {
            try
            {
                vTb_Colegiado_Laboral.Fec_Ingreso = vTb_Colegiado_Laboral.Fec_Modifica = Variables.Hoy;
                vTb_Colegiado_Laboral.Flg_Activo = Variables.Activo;
                if (vTb_Colegiado_Laboral.Id_Informacion_Laboral == 0)
                {
                    vTb_Colegiado_Laboral = new Tb_Colegiado_Laboral_AD().Insert(vTb_Colegiado_Laboral);
                }
                else
                {
                    vTb_Colegiado_Laboral = new Tb_Colegiado_Laboral_AD().Update(vTb_Colegiado_Laboral);
                }
                vTb_Colegiado_Laboral.Opcional = "OK";
                return vTb_Colegiado_Laboral;
            }
            catch (Exception ex)
            {
                vTb_Colegiado_Laboral.Opcional = "ERR";
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        #endregion
    }
}

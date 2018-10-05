/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Colegiado_Consejo_LN.cs
Objetivo          : Clase referida a los métodos de Lógica de Negocio de la clase Tb_Colegiado_Consejo
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
    public class Tb_Colegiado_Consejo_LN : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Colegiado_Consejo
        /// </summary>
        /// <returns>Retorna una lista de objetos de tipo Tb_Colegiado_Consejo</returns>
        public List<Tb_Colegiado_Consejo> List()
        {
            try
            {
                return new Tb_Colegiado_Consejo_AD().List();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Método que recupera un regustro del tipo Tb_Colegiado_Consejo basado en su clave primaria
        /// </summary>
        /// <param name="Id_Consejo">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Colegiado_Consejo GetRegistry(int vId_Consejo)
        {
            try
            {
                return new Tb_Colegiado_Consejo_AD().GetRegistry(vId_Consejo);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Inserta un Objeto del tipo Tb_Colegiado_Consejo
        /// </summary>
        /// <param name="Tb_Colegiado_Consejo">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizado</returns>
        public Tb_Colegiado_Consejo Insert(Tb_Colegiado_Consejo vTb_Colegiado_Consejo)
        {
            try
            {
                return new Tb_Colegiado_Consejo_AD().Insert(vTb_Colegiado_Consejo);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Colegiado_Consejo
        /// </summary>
        /// <param name="Tb_Colegiado_Consejo">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Colegiado_Consejo Update(Tb_Colegiado_Consejo vTb_Colegiado_Consejo)
        {
            try
            {
                return new Tb_Colegiado_Consejo_AD().Update(vTb_Colegiado_Consejo);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Método que eliminara un registo del tipo Tb_Colegiado_Consejo en base a su clave primaria
        /// </summary>
        /// <param name="Id_Consejo">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Consejo, string vUsuario, DateTime vFecha)
        {
            try
            {
                return new Tb_Colegiado_Consejo_AD().Delete(vId_Consejo, vUsuario, vFecha);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        #endregion

        #region Métodos Extendidos

        public List<Tb_Colegiado_Consejo> List(int vId)
        {
            try
            {
                return new Tb_Colegiado_Consejo_AD().List(vId);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public Tb_Colegiado_Consejo Grabar(Tb_Colegiado_Consejo vTb_Colegiado_Consejo)
        {
            try
            {
                vTb_Colegiado_Consejo.Fec_Ingreso = vTb_Colegiado_Consejo.Fec_Modifica = Variables.Hoy;
                vTb_Colegiado_Consejo.Flg_Activo = "1";
                if (vTb_Colegiado_Consejo.Id_Consejo == 0)
                {
                    vTb_Colegiado_Consejo = new Tb_Colegiado_Consejo_AD().Insert(vTb_Colegiado_Consejo);
                }
                else
                {
                    vTb_Colegiado_Consejo = new Tb_Colegiado_Consejo_AD().Update(vTb_Colegiado_Consejo);
                }
                return vTb_Colegiado_Consejo;
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

/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Colegiado_Estudio_LN.cs
Objetivo          : Clase referida a los métodos de Lógica de Negocio de la clase Tb_Colegiado_Estudio
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
    public class Tb_Colegiado_Estudio_LN : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Colegiado_Estudio
        /// </summary>
        /// <returns>Retorna una lista de objetos de tipo Tb_Colegiado_Estudio</returns>
        public List<Tb_Colegiado_Estudio> List()
        {
            try
            {
                return new Tb_Colegiado_Estudio_AD().List();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Método que recupera un regustro del tipo Tb_Colegiado_Estudio basado en su clave primaria
        /// </summary>
        /// <param name="Id_Persona">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Colegiado_Estudio GetRegistry(int vId_Persona)
        {
            try
            {
                return new Tb_Colegiado_Estudio_AD().GetRegistry(vId_Persona);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Inserta un Objeto del tipo Tb_Colegiado_Estudio
        /// </summary>
        /// <param name="Tb_Colegiado_Estudio">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizado</returns>
        public Tb_Colegiado_Estudio Insert(Tb_Colegiado_Estudio vTb_Colegiado_Estudio)
        {
            try
            {
                return new Tb_Colegiado_Estudio_AD().Insert(vTb_Colegiado_Estudio);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Colegiado_Estudio
        /// </summary>
        /// <param name="Tb_Colegiado_Estudio">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Colegiado_Estudio Update(Tb_Colegiado_Estudio vTb_Colegiado_Estudio)
        {
            try
            {
                return new Tb_Colegiado_Estudio_AD().Update(vTb_Colegiado_Estudio);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Método que eliminara un registo del tipo Tb_Colegiado_Estudio en base a su clave primaria
        /// </summary>
        /// <param name="Id_Persona">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Persona, string vUsuario, DateTime vFecha)
        {
            try
            {
                return new Tb_Colegiado_Estudio_AD().Delete(vId_Persona, vUsuario, vFecha);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        #endregion

        #region Métodos Extendidos

        public Tb_Colegiado_Estudio Grabar(Tb_Colegiado_Estudio vEstudio)
        {
            try
            {
                vEstudio.Flg_Activo = "1";
                vEstudio.Fec_Ingreso = vEstudio.Fec_Modifica = vEstudio.Fecha_Egreso = Variables.Hoy;
                vEstudio.Opcional = "OK";
                if (vEstudio.Id_Estudio == 0)
                {
                    return new Tb_Colegiado_Estudio_AD().Insert(vEstudio);
                }
                else
                {
                    return new Tb_Colegiado_Estudio_AD().Update(vEstudio);
                }
            }
            catch (Exception ex)
            {
                vEstudio.Opcional = "ERR";
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        #endregion
    }
}

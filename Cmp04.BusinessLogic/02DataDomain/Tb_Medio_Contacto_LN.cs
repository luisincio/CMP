/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Medio_Contacto_LN.cs
Objetivo          : Clase referida a los métodos de Lógica de Negocio de la clase Tb_Medio_Contacto
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
    public class Tb_Medio_Contacto_LN : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Medio_Contacto
        /// </summary>
        /// <returns>Retorna una lista de objetos de tipo Tb_Medio_Contacto</returns>
        public List<Tb_Medio_Contacto> List()
        {
            try
            {
                return new Tb_Medio_Contacto_AD().List();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Método que recupera un regustro del tipo Tb_Medio_Contacto basado en su clave primaria
        /// </summary>
        /// <param name="Id_Medio_Contacto">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Medio_Contacto GetRegistry(int vId_Medio_Contacto)
        {
            try
            {
                return (vId_Medio_Contacto == 0)? new Tb_Medio_Contacto(): new Tb_Medio_Contacto_AD().GetRegistry(vId_Medio_Contacto);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Inserta un Objeto del tipo Tb_Medio_Contacto
        /// </summary>
        /// <param name="Tb_Medio_Contacto">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizado</returns>
        public Tb_Medio_Contacto Insert(Tb_Medio_Contacto vTb_Medio_Contacto)
        {
            try
            {
                return new Tb_Medio_Contacto_AD().Insert(vTb_Medio_Contacto);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Medio_Contacto
        /// </summary>
        /// <param name="Tb_Medio_Contacto">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Medio_Contacto Update(Tb_Medio_Contacto vTb_Medio_Contacto)
        {
            try
            {
                return new Tb_Medio_Contacto_AD().Update(vTb_Medio_Contacto);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Método que eliminara un registo del tipo Tb_Medio_Contacto en base a su clave primaria
        /// </summary>
        /// <param name="Id_Medio_Contacto">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Medio_Contacto, string vUsuario, DateTime vFecha)
        {
            try
            {
                return new Tb_Medio_Contacto_AD().Delete(vId_Medio_Contacto, vUsuario, vFecha);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        #endregion

        #region Métodos Extendidos

        public List<Tb_Medio_Contacto> List(int vId)
        {
            try
            {
                return new Tb_Medio_Contacto_AD().List(vId);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public Tb_Medio_Contacto Grabar(Tb_Medio_Contacto vTb_Medio_Contacto)
        {
            try
            {
                vTb_Medio_Contacto.Fec_Ingreso = vTb_Medio_Contacto.Fec_Modifica = Variables.Hoy;
                vTb_Medio_Contacto.Flg_Activo = Variables.Activo;
                if (vTb_Medio_Contacto.Id_Medio_Contacto == 0)
                {
                    vTb_Medio_Contacto = new Tb_Medio_Contacto_AD().Insert(vTb_Medio_Contacto);
                }
                else
                {
                    vTb_Medio_Contacto = new Tb_Medio_Contacto_AD().Update(vTb_Medio_Contacto);
                }
                vTb_Medio_Contacto.Opcional = "OK";
                return vTb_Medio_Contacto;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                vTb_Medio_Contacto.Opcional = "ERR";
                throw;
            }
        }

        #endregion
    }
}

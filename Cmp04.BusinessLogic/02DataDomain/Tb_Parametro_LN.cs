/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Parametro_LN.cs
Objetivo          : Clase referida a los métodos de Lógica de Negocio de la clase Tb_Parametro
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
    public class Tb_Parametro_LN : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Parametro
        /// </summary>
        /// <returns>Retorna una lista de objetos de tipo Tb_Parametro</returns>
        public List<Tb_Parametro> List()
        {
            try
            {
                return new Tb_Parametro_AD().List();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Método que recupera un regustro del tipo Tb_Parametro basado en su clave primaria
        /// </summary>
        /// <param name="Id_Parametro">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Parametro GetRegistry(int vId_Parametro)
        {
            try
            {
                return (vId_Parametro == 0) ? new Tb_Parametro() : new Tb_Parametro_AD().GetRegistry(vId_Parametro);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }
        
        /// <summary>
        /// Inserta un Objeto del tipo Tb_Parametro
        /// </summary>
        /// <param name="Tb_Parametro">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizado</returns>
        public Tb_Parametro Insert(Tb_Parametro vTb_Parametro)
        {
            try
            {
                return new Tb_Parametro_AD().Insert(vTb_Parametro);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Parametro
        /// </summary>
        /// <param name="Tb_Parametro">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Parametro Update(Tb_Parametro vTb_Parametro)
        {
            try
            {
                return new Tb_Parametro_AD().Update(vTb_Parametro);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }
                
        /// <summary>
        /// Método que eliminara un registo del tipo Tb_Parametro en base a su clave primaria
        /// </summary>
        /// <param name="Id_Parametro">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Parametro, string vUsuario, DateTime vFecha)
        {
            try
            {
                return new Tb_Parametro_AD().Delete(vId_Parametro, vUsuario, vFecha);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }
        
        #endregion

        public List<Tb_Parametro> List(string vValor)
        {
            try
            {
                return new Tb_Parametro_AD().List(vValor);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public Tb_Parametro Grabar(Tb_Parametro vTb_Parametro)
        {
            vTb_Parametro.Fec_Ingreso = vTb_Parametro.Fec_Modifica = Variables.Hoy;
            vTb_Parametro.Flg_Activo = Variables.Activo;
            try
            {
                if (new Tb_Parametro_AD().GetRegistry(vTb_Parametro.Id_Parametro) == null)
                {
                    new Tb_Parametro_AD().Insert(vTb_Parametro);
                }
                else
                {
                    new Tb_Parametro_AD().Update(vTb_Parametro);
                }
                vTb_Parametro.Opcional = "OK";
                return vTb_Parametro;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }
    }
}

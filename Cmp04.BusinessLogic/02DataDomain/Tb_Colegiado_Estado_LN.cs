/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Colegiado_Estado_LN.cs
Objetivo          : Clase referida a los métodos de Lógica de Negocio de la clase Tb_Colegiado_Estado
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
    public class Tb_Colegiado_Estado_LN : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Colegiado_Estado
        /// </summary>
        /// <returns>Retorna una lista de objetos de tipo Tb_Colegiado_Estado</returns>
        public List<Tb_Colegiado_Estado> List()
        {
            try
            {
                return new Tb_Colegiado_Estado_AD().List();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Método que recupera un regustro del tipo Tb_Colegiado_Estado basado en su clave primaria
        /// </summary>
        /// <param name="Id_Estado">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Colegiado_Estado GetRegistry(int vId_Estado)
        {
            try
            {
                return new Tb_Colegiado_Estado_AD().GetRegistry(vId_Estado);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Inserta un Objeto del tipo Tb_Colegiado_Estado
        /// </summary>
        /// <param name="Tb_Colegiado_Estado">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizado</returns>
        public Tb_Colegiado_Estado Insert(Tb_Colegiado_Estado vTb_Colegiado_Estado)
        {
            try
            {
                return new Tb_Colegiado_Estado_AD().Insert(vTb_Colegiado_Estado);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Colegiado_Estado
        /// </summary>
        /// <param name="Tb_Colegiado_Estado">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Colegiado_Estado Update(Tb_Colegiado_Estado vTb_Colegiado_Estado)
        {
            try
            {
                return new Tb_Colegiado_Estado_AD().Update(vTb_Colegiado_Estado);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Método que eliminara un registo del tipo Tb_Colegiado_Estado en base a su clave primaria
        /// </summary>
        /// <param name="Id_Estado">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Estado, string vUsuario, DateTime vFecha)
        {
            try
            {
                return new Tb_Colegiado_Estado_AD().Delete(vId_Estado, vUsuario, vFecha);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        #endregion

        #region Métodos Extendidos

        public List<Tb_Colegiado_Estado> List(int vId)
        {
            try
            {
                return new Tb_Colegiado_Estado_AD().List(vId);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public Tb_Colegiado_Estado Grabar(Tb_Colegiado_Estado vTb_Colegiado_Estado)
        {
            try
            {
                vTb_Colegiado_Estado.Fec_Ingreso = vTb_Colegiado_Estado.Fec_Modifica = Variables.Hoy;
                vTb_Colegiado_Estado.Flg_Activo = "1";
                if (vTb_Colegiado_Estado.Id_Estado == 0)
                {
                    vTb_Colegiado_Estado = new Tb_Colegiado_Estado_AD().Insert(vTb_Colegiado_Estado);
                }
                else
                {
                    vTb_Colegiado_Estado = new Tb_Colegiado_Estado_AD().Update(vTb_Colegiado_Estado);
                }

                Tb_Persona_Natural Temp = new Tb_Persona_Natural_AD().GetRegistry(vTb_Colegiado_Estado.Id_Persona);
                Temp.Id_Estado_Actual = vTb_Colegiado_Estado.Id_Estado_Colegiado;
                Temp.Usu_Modifica = vTb_Colegiado_Estado.Usu_Modifica;
                Temp.Fec_Modifica = Variables.Hoy;

                if (vTb_Colegiado_Estado.Id_Estado_Colegiado == Convert.ToInt32( EnumEstado.FALLECIDO ))
                {
                    Temp.Fec_Fallecio = vTb_Colegiado_Estado.Fec_Fallecio;
                }
                new Tb_Persona_Natural_AD().Update(Temp);
                return vTb_Colegiado_Estado;
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

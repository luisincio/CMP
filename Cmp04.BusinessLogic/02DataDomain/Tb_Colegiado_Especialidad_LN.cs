/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Colegiado_Especialidad_LN.cs
Objetivo          : Clase referida a los métodos de Lógica de Negocio de la clase Tb_Colegiado_Especialidad
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
    public class Tb_Colegiado_Especialidad_LN : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Colegiado_Especialidad
        /// </summary>
        /// <returns>Retorna una lista de objetos de tipo Tb_Colegiado_Especialidad</returns>
        public List<Tb_Colegiado_Especialidad> List()
        {
            try
            {
                return new Tb_Colegiado_Especialidad_AD().List();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Método que recupera un regustro del tipo Tb_Colegiado_Especialidad basado en su clave primaria
        /// </summary>
        /// <param name="Id_Especialidad">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Colegiado_Especialidad GetRegistry(int vId_Especialidad)
        {
            try
            {
                return new Tb_Colegiado_Especialidad_AD().GetRegistry(vId_Especialidad);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Inserta un Objeto del tipo Tb_Colegiado_Especialidad
        /// </summary>
        /// <param name="Tb_Colegiado_Especialidad">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizado</returns>
        public Tb_Colegiado_Especialidad Insert(Tb_Colegiado_Especialidad vTb_Colegiado_Especialidad)
        {
            try
            {
                return new Tb_Colegiado_Especialidad_AD().Insert(vTb_Colegiado_Especialidad);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Colegiado_Especialidad
        /// </summary>
        /// <param name="Tb_Colegiado_Especialidad">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Colegiado_Especialidad Update(Tb_Colegiado_Especialidad vTb_Colegiado_Especialidad)
        {
            try
            {
                return new Tb_Colegiado_Especialidad_AD().Update(vTb_Colegiado_Especialidad);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Método que eliminara un registo del tipo Tb_Colegiado_Especialidad en base a su clave primaria
        /// </summary>
        /// <param name="Id_Especialidad">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Especialidad, string vUsuario, DateTime vFecha)
        {
            try
            {
                return new Tb_Colegiado_Especialidad_AD().Delete(vId_Especialidad, vUsuario, vFecha);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        #endregion

        #region Métodos Extendidos

        public List<Tb_Colegiado_Especialidad> List(int vId)
        {
            try
            {
                return new Tb_Colegiado_Especialidad_AD().List(vId);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public Tb_Colegiado_Especialidad Grabar(Tb_Colegiado_Especialidad vTb_Colegiado_Especialidad)
        {
            try
            {
                vTb_Colegiado_Especialidad.Fec_Ingreso = vTb_Colegiado_Especialidad.Fec_Modifica = Variables.Hoy;
                vTb_Colegiado_Especialidad.Flg_Activo = Variables.Activo;
                if (vTb_Colegiado_Especialidad.Id_Tipo == (int)EnumTipoEspecialidad.ESPECIALIDAD)
                {
                    vTb_Colegiado_Especialidad.Fecha_Caducidad = vTb_Colegiado_Especialidad.Fecha_Registro.AddYears(Variables.TiempoAñosRecertificacion);
                }

                if (vTb_Colegiado_Especialidad.Id_Especialidad == 0)
                {
                    vTb_Colegiado_Especialidad = new Tb_Colegiado_Especialidad_AD().Insert(vTb_Colegiado_Especialidad);
                    new Tb_Colegiado_Especialidad_AD().Update_NumeroEspecialidad(vTb_Colegiado_Especialidad.Id_Tipo);
                }
                else
                {
                    vTb_Colegiado_Especialidad = new Tb_Colegiado_Especialidad_AD().Update(vTb_Colegiado_Especialidad);
                }
                vTb_Colegiado_Especialidad.Opcional = "OK";
                return vTb_Colegiado_Especialidad;
            }
            catch (Exception ex)
            {
                vTb_Colegiado_Especialidad.Opcional = "ERR";
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        #endregion

    }
}

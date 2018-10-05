/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Domicilio_LN.cs
Objetivo          : Clase referida a los métodos de Lógica de Negocio de la clase Tb_Domicilio
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
    public class Tb_Domicilio_LN : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Domicilio
        /// </summary>
        /// <returns>Retorna una lista de objetos de tipo Tb_Domicilio</returns>
        public List<Tb_Domicilio> List()
        {
            try
            {
                return new Tb_Domicilio_AD().List();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Método que recupera un regustro del tipo Tb_Domicilio basado en su clave primaria
        /// </summary>
        /// <param name="Id_Domicilio">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Domicilio GetRegistry(int vId_Domicilio)
        {
            try
            {
                return new Tb_Domicilio_AD().GetRegistry(vId_Domicilio);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Inserta un Objeto del tipo Tb_Domicilio
        /// </summary>
        /// <param name="Tb_Domicilio">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizado</returns>
        public Tb_Domicilio Insert(Tb_Domicilio vTb_Domicilio)
        {
            try
            {
                return new Tb_Domicilio_AD().Insert(vTb_Domicilio);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Domicilio
        /// </summary>
        /// <param name="Tb_Domicilio">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Domicilio Update(Tb_Domicilio vTb_Domicilio)
        {
            try
            {
                return new Tb_Domicilio_AD().Update(vTb_Domicilio);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Método que eliminara un registo del tipo Tb_Domicilio en base a su clave primaria
        /// </summary>
        /// <param name="Id_Domicilio">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Domicilio, string vUsuario, DateTime vFecha)
        {
            try
            {
                return new Tb_Domicilio_AD().Delete(vId_Domicilio, vUsuario, vFecha);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        #endregion

        #region Métodos Extendidos

        public Tb_Domicilio Grabar(Tb_Domicilio vTb_Domicilio)
        {
            try
            {
                vTb_Domicilio.Flg_Activo = vTb_Domicilio.Flg_Domicilio_Fiscal = Variables.Activo;
                vTb_Domicilio.Id_Pais = Variables.Peru;
                //vTb_Domicilio.Nro_Departamento = "";
                //vTb_Domicilio.Domicilio_Completo = "";
                vTb_Domicilio.Fec_Ingreso = vTb_Domicilio.Fec_Modifica = Variables.Hoy;
                if (vTb_Domicilio.Id_Domicilio == 0)
                {
                    vTb_Domicilio = new Tb_Domicilio_AD().Insert(vTb_Domicilio);
                }
                else
                {
                    vTb_Domicilio = new Tb_Domicilio_AD().Update(vTb_Domicilio);
                }
                vTb_Domicilio.Opcional = "OK";
                return vTb_Domicilio;
            }
            catch (Exception ex)
            {
                vTb_Domicilio.Opcional = "ERR";
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        #endregion

    }
}

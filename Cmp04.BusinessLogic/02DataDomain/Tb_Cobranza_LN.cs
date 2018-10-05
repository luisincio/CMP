/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Cobranza_LN.cs
Objetivo          : Clase referida a los métodos de Lógica de Negocio de la clase Tb_Cobranza
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
    public class Tb_Cobranza_LN : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Cobranza
        /// </summary>
        /// <returns>Retorna una lista de objetos de tipo Tb_Cobranza</returns>
        public List<Tb_Cobranza> List(string vValor, int vTipo)
        {
            try
            {
                return new Tb_Cobranza_AD().List(vValor, vTipo, true);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);

                throw;
            }
        }

        /// <summary>
        /// Método que recupera un regustro del tipo Tb_Cobranza basado en su clave primaria
        /// </summary>
        /// <param name="Id_Cobro">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Cobranza GetRegistry(int vId_Cobro)
        {
            try
            {
                return new Tb_Cobranza_AD().GetRegistry(vId_Cobro);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Inserta un Objeto del tipo Tb_Cobranza
        /// </summary>
        /// <param name="Tb_Cobranza">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizado</returns>
        public Tb_Cobranza Insert(Tb_Cobranza vTb_Cobranza)
        {
            try
            {
                return new Tb_Cobranza_AD().Insert(vTb_Cobranza);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Cobranza
        /// </summary>
        /// <param name="Tb_Cobranza">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Cobranza Update(Tb_Cobranza vTb_Cobranza)
        {
            try
            {
                return new Tb_Cobranza_AD().Update(vTb_Cobranza);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Método que eliminara un registo del tipo Tb_Cobranza en base a su clave primaria
        /// </summary>
        /// <param name="Id_Cobro">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Cobro, string vUsuario, DateTime vFecha)
        {
            try
            {
                return new Tb_Cobranza_AD().Delete(vId_Cobro, vUsuario, vFecha);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        #endregion

        /// <summary>
        /// Método que lista los registros de Tb_Cobranza
        /// </summary>
        /// <returns>Retorna una lista de objetos de tipo Tb_Cobranza</returns>
        public List<Tb_Cobranza> List()
        {
            throw new NotImplementedException();
        }

        //public int Generar_Comprobante(int vId_Cobro, string vUsuario)
        //{
        //    try
        //    {
        //        return new Tb_Cobranza_AD().Generar_Comprobante(vId_Cobro, vUsuario, Variables.Hoy);
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(ex.Message, ex);
        //        throw;
        //    }
        //}

        public int Generar_Comprobante(string vIds_Cobro, string vUsuario, int vId_Persona)
        {
            try
            {
                return new Tb_Cobranza_AD().Generar_Comprobante(vIds_Cobro, vUsuario, Variables.Hoy, vId_Persona);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Método que lista los registros de Tb_Cobranza por parámetros
        /// </summary>
        /// <returns>Retorna una lista de objetos de tipo Tb_Cobranza</returns>
        public List<Tb_Cobranza> ListPlanilla(string vValor, string vPeriodo, int vIdConsejo, int vId_Entidad)
        {
            try
            {
                if (!string.IsNullOrEmpty(vPeriodo))
                    return new Tb_Cobranza_AD().ListPlanilla(vValor, Convert.ToDateTime(vPeriodo), vIdConsejo, vId_Entidad);
                else
                    return new Tb_Cobranza_AD().ListPlanilla(vValor, null, vIdConsejo, vId_Entidad);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

    }
}

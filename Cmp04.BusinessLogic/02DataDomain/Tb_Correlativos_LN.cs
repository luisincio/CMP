/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Correlativos_LN.cs
Objetivo          : Clase referida a los métodos de Lógica de Negocio de la clase Tb_Correlativos
Autor             : CMP-SISTEMAS (FRR)
Fecha Creación    : 09/06/2018
Métodos           : List, GetRegistry, Insert, Update, Delete   
----------------------------------------------------------------------------------------*/
#region Espacios de Nombres
using Cmp03.DataAccess;
using Cmp02.Entities;
using System;
using System.Collections.Generic;
using Cmp01.Utilities;
#endregion

namespace Cmp04.BusinessLogic
{
    public class Tb_Correlativos_LN : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Correlativos
        /// </summary>
        /// <returns>Retorna una lista de objetos de tipo Tb_Correlativos</returns>
        public List<Tb_Correlativos> List(int vId_Sucursal, int vId_TipoDocumento, int vSerie, int vId_Persona = 0)
        {
            try
            {
                return new Tb_Correlativos_AD().List(vId_Sucursal, vId_TipoDocumento, vSerie, vId_Persona);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Método que recupera un regustro del tipo Tb_Correlativos basado en su clave primaria
        /// </summary>
        /// <param name="Id_Sucursal">Clave primaria del registro a eliminar</param>/// <param name="Id_Tidodocumento">Clave primaria del registro a eliminar</param>/// <param name="Serie">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Correlativos GetRegistry(int vId_Sucursal, int vId_Tidodocumento, int vSerie)
        {
            try
            {
                return (vId_Sucursal == 0 && vId_Tidodocumento == 0 && vSerie == 0) ? new Tb_Correlativos() { Accion = true } : new Tb_Correlativos_AD().GetRegistry(vId_Sucursal, vId_Tidodocumento, vSerie);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }
        
        /// <summary>
        /// Inserta un Objeto del tipo Tb_Correlativos
        /// </summary>
        /// <param name="Tb_Correlativos">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizado</returns>
        public Tb_Correlativos Insert(Tb_Correlativos vTb_Correlativos)
        {
            try
            {
                vTb_Correlativos.Fec_Ingreso = vTb_Correlativos.Fec_Modifica = Variables.Hoy;
                return new Tb_Correlativos_AD().Insert(vTb_Correlativos);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Correlativos
        /// </summary>
        /// <param name="Tb_Correlativos">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Correlativos Update(Tb_Correlativos vTb_Correlativos)
        {
            try
            {
                vTb_Correlativos.Fec_Ingreso = vTb_Correlativos.Fec_Modifica = Variables.Hoy;
                return new Tb_Correlativos_AD().Update(vTb_Correlativos);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }
                
        /// <summary>
        /// Método que eliminara un registo del tipo Tb_Correlativos en base a su clave primaria
        /// </summary>
        /// <param name="Id_Sucursal">Clave primaria del registro a eliminar</param>/// <param name="Id_Tidodocumento">Clave primaria del registro a eliminar</param>/// <param name="Serie">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Sucursal, int vId_Tidodocumento, int vSerie, string vUsuario, DateTime vFecha)
        {
            try
            {
                return new Tb_Correlativos_AD().Delete(vId_Sucursal,  vId_Tidodocumento,  vSerie, vUsuario, vFecha);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }
        
        public string GetNumero(int vId_Sucursal, int vId_Tidodocumento, int vSerie)
        {
            try
            {
                return new Tb_Correlativos_AD().GetNumero(vId_Sucursal, vId_Tidodocumento, vSerie);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public string GetNumeroEspecialidad(int vId_TipoEspecialidad)
        {
            try
            {
                return new Tb_Correlativos_AD().GetNumeroEspecialidad(vId_TipoEspecialidad);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public List<Tb_Maestras> List_PeriodoCobro()
        {
            try
            {
                return new Tb_Correlativos_AD().List_PeriodoCobro();
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

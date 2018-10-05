/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Persona_LN.cs
Objetivo          : Clase referida a los métodos de Lógica de Negocio de la clase Tb_Persona
Autor             : CMP-SISTEMAS (FRR)
Fecha Creación    : 09/06/2018
Métodos           : List, GetRegistry, Insert, Update, Delete   
----------------------------------------------------------------------------------------*/
#region Espacios de Nombres
using Cmp03.DataAccess;
using Cmp02.Entities;
using System;
using System.Collections.Generic;
#endregion

namespace Cmp04.BusinessLogic
{
    public class Tb_Persona_LN : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Persona
        /// </summary>
        /// <returns>Retorna una lista de objetos de tipo Tb_Persona</returns>
        public List<Tb_Persona> List()
        {
            try
            {
                return new Tb_Persona_AD().List();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Método que recupera un regustro del tipo Tb_Persona basado en su clave primaria
        /// </summary>
        /// <param name="Id_Persona">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Persona GetRegistry(int vId_Persona)
        {
            try
            {
                return new Tb_Persona_AD().GetRegistry(vId_Persona);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Inserta un Objeto del tipo Tb_Persona
        /// </summary>
        /// <param name="Tb_Persona">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizado</returns>
        public Tb_Persona Insert(Tb_Persona vTb_Persona)
        {
            try
            {
                return new Tb_Persona_AD().Insert(vTb_Persona);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Persona
        /// </summary>
        /// <param name="Tb_Persona">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Persona Update(Tb_Persona vTb_Persona)
        {
            try
            {
                return new Tb_Persona_AD().Update(vTb_Persona);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Método que eliminara un registo del tipo Tb_Persona en base a su clave primaria
        /// </summary>
        /// <param name="Id_Persona">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Persona, string vUsuario, DateTime vFecha)
        {
            try
            {
                return new Tb_Persona_AD().Delete(vId_Persona, vUsuario, vFecha);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        #endregion

        #region Métodos Extendidos

        public List<ColegiadoMin> List_Bandeja(string vValor, int vIdEstado, int vIdConsejo)
        {
            try
            {
                return new Tb_Persona_AD().List_Bandeja(vValor, vIdEstado, vIdConsejo);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public List<EmpresaMin> List_EmpresaBandeja(string vValor, int vId_Consejo)
        {
            try
            {
                return new Tb_Persona_AD().List_EmpresaBandeja(vValor, vId_Consejo);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public List<Tb_Colegiado_Carnet> List_Carnets(string vValor, int vIdConsejo)
        {
            try
            {
                return new Tb_Persona_AD().List_Carnets(vValor, vIdConsejo);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public List<ColegiadoMin> List_Modal(string vValor)
        {
            try
            {
                return new Tb_Persona_AD().List_Modal(vValor);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public List<ColegiadoMin> List_Inactivos(string vValor, int vIdEstado, int vIdConsejo, DateTime vFecha)
        {
            try
            {
                return new Tb_Persona_AD().List_Inactivos(vValor, vIdEstado, vIdConsejo, vFecha);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public List<FullConsulta> List_FullColegiado(int vEstadoCivil, string vCodCmpInicial, string vCodCmpFinal, string vSexo, string vConsejos, string vFecCmpInicial, string vFecCmpFinal, string vEstados, string vTiposDocumentos, int vEdadInicial, int vEdadFinal, string vFecRegInicial, string vFecRegFinal, string vUbigeo, string vUniversidad, string vNombre)
        {
            try
            {
                return new Tb_Persona_AD().List_FullColegiado(vEstadoCivil, vCodCmpInicial, vCodCmpFinal, vSexo, vConsejos, vFecCmpInicial, vFecCmpFinal, vEstados, vTiposDocumentos, vEdadInicial, vEdadFinal, vFecRegInicial, vFecRegFinal, vUbigeo, vUniversidad, vNombre);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public List<ColegiadoMin> List_Persona(string vValor, string vTipo)
        {
            try
            {
                return new Tb_Persona_AD().List_Persona(vValor, vTipo);
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

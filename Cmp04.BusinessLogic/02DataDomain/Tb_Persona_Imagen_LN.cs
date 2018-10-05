/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Persona_Imagen_LN.cs
Objetivo          : Clase referida a los métodos de Lógica de Negocio de la clase Tb_Persona_Imagen
Autor             : CMP-SISTEMAS (FRR)
Fecha Creación    : 09/06/2018
Métodos           : List, GetRegistry, Insert, Update, Delete   
----------------------------------------------------------------------------------------*/
#region Espacios de Nombres
using Cmp03.DataAccess;
using Cmp02.Entities;
using System;
using System.Collections.Generic;
using System.Transactions;
#endregion

namespace Cmp04.BusinessLogic
{
    public class Tb_Persona_Imagen_LN : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Persona_Imagen
        /// </summary>
        /// <returns>Retorna una lista de objetos de tipo Tb_Persona_Imagen</returns>
        public List<Tb_Persona_Imagen> List()
        {
            try
            {
                return new Tb_Persona_Imagen_AD().List();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Método que recupera un regustro del tipo Tb_Persona_Imagen basado en su clave primaria
        /// </summary>
        /// <param name="Id_Persona">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Persona_Imagen GetRegistry(int vId_Persona)
        {
            try
            {
                return (vId_Persona == 0) ? new Tb_Persona_Imagen() { Id_Persona = vId_Persona } : new Tb_Persona_Imagen_AD().GetRegistry(vId_Persona);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Inserta un Objeto del tipo Tb_Persona_Imagen
        /// </summary>
        /// <param name="Tb_Persona_Imagen">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizado</returns>
        public Tb_Persona_Imagen Insert(Tb_Persona_Imagen vTb_Persona_Imagen)
        {
            try
            {
                return new Tb_Persona_Imagen_AD().Insert(vTb_Persona_Imagen);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Persona_Imagen
        /// </summary>
        /// <param name="Tb_Persona_Imagen">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Persona_Imagen Update(Tb_Persona_Imagen vTb_Persona_Imagen)
        {
            try
            {
                return new Tb_Persona_Imagen_AD().Update(vTb_Persona_Imagen);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Método que eliminara un registo del tipo Tb_Persona_Imagen en base a su clave primaria
        /// </summary>
        /// <param name="Id_Persona">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Persona, string vUsuario, DateTime vFecha)
        {
            try
            {
                return new Tb_Persona_Imagen_AD().Delete(vId_Persona, vUsuario, vFecha);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        #endregion

        #region Métodos Extendidos

        public Tb_Persona_Imagen GetRegistry(int vId_Persona, int vId_Tipo)
        {
            try
            {
                return new Tb_Persona_Imagen_AD().GetRegistry(vId_Persona, vId_Tipo);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public Tb_Persona_Imagen Grabar(Tb_Persona_Imagen vTb_Persona_Imagen)
        {
            try
            {
                new Tb_Persona_Imagen_AD().Delete(vTb_Persona_Imagen.Id_Persona, vTb_Persona_Imagen.Id_Tipo_Imagen);
                vTb_Persona_Imagen = new Tb_Persona_Imagen_AD().Insert(vTb_Persona_Imagen);
                return vTb_Persona_Imagen;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }


        //public int Delete(int vId_Persona, int vId_Tipo)
        //{
        //    try
        //    {
        //        return new Tb_Persona_Imagen_AD().Delete(vId_Persona, vId_Tipo);
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(ex.Message, ex);
        //        throw;
        //    }
        //}

        #endregion
    }
}

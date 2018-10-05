/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Perfilusuario_LN.cs
Objetivo          : Clase referida a los métodos de Lógica de Negocio de la clase Tb_Perfilusuario
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
    public class Tb_Perfilusuario_LN : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Perfilusuario
        /// </summary>
        /// <returns>Retorna una lista de objetos de tipo Tb_Perfilusuario</returns>
        public List<Tb_Perfilusuario> List()
        {
            try
            {
                return new Tb_Perfilusuario_AD().List();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Método que recupera un regustro del tipo Tb_Perfilusuario basado en su clave primaria
        /// </summary>
        /// <param name="Id_Perfil">Clave primaria del registro a eliminar</param>/// <param name="Id_Usuario">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Perfilusuario GetRegistry(int vId_Perfil, int vId_Usuario)
        {
            try
            {
                return new Tb_Perfilusuario_AD().GetRegistry(vId_Perfil,  vId_Usuario);
               
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }
        
        /// <summary>
        /// Inserta un Objeto del tipo Tb_Perfilusuario
        /// </summary>
        /// <param name="Tb_Perfilusuario">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizado</returns>
        public Tb_Perfilusuario Insert(Tb_Perfilusuario vTb_Perfilusuario)
        {
            try
            {
                return new Tb_Perfilusuario_AD().Insert(vTb_Perfilusuario);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Perfilusuario
        /// </summary>
        /// <param name="Tb_Perfilusuario">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Perfilusuario Update(Tb_Perfilusuario vTb_Perfilusuario)
        {
            try
            {
                return new Tb_Perfilusuario_AD().Update(vTb_Perfilusuario);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }
                
        /// <summary>
        /// Método que eliminara un registo del tipo Tb_Perfilusuario en base a su clave primaria
        /// </summary>
        /// <param name="Id_Perfil">Clave primaria del registro a eliminar</param>/// <param name="Id_Usuario">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Perfil, int vId_Usuario, string vUsuario, DateTime vFecha)
        {
            try
            {
                return new Tb_Perfilusuario_AD().Delete(vId_Perfil,  vId_Usuario, vUsuario, vFecha);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }
        
        #endregion

        public string Grabar(int vId, int vIdPerfil,string vUsuario)
        {
            Tb_Perfilusuario vTemp = new Tb_Perfilusuario();
            vTemp.Id_Usuario = vId;
            vTemp.Id_Perfil = vIdPerfil;
            vTemp.Usu_Ingreso = vTemp.Usu_Modifica = vUsuario;
            vTemp.Fec_Ingreso = vTemp.Fec_Modifica = Variables.Hoy;
            vTemp.Flg_Activo = Variables.Activo;
            
            try
            {
                if (new Tb_Usuario_AD().GetRegistry_Perfil(vId).Id_Perfil == 0)
                {
                    new Tb_Perfilusuario_AD().Insert(vTemp);
                }
                else
                {
                    new Tb_Perfilusuario_AD().Update(vTemp);
                }
                //vTemp.Opcional = "OK";
                return "OK";
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }
    }
}

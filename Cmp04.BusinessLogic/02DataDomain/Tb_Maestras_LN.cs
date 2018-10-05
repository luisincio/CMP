/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Maestras_LN.cs
Objetivo          : Clase referida a los métodos de Lógica de Negocio de la clase Tb_Maestras
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
    public class Tb_Maestras_LN : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Maestras
        /// </summary>
        /// <returns>Retorna una lista de objetos de tipo Tb_Maestras</returns>
        public List<Tb_Maestras> List(EnumMaestras vTabla)
        {
            try
            {
                return new Tb_Maestras_AD().List(Convert.ToInt32(vTabla));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public List<Tb_Maestras> ListConsejo(string usuario)
        {
            try
            {
                return new Tb_Maestras_AD().ListConsejo(usuario);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }
        

        /// <summary>
        /// Método que recupera un regustro del tipo Tb_Maestras basado en su clave primaria
        /// </summary>
        /// <param name="Id_Maestras">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Maestras GetRegistry(int vId_Maestras)
        {
            try
            {
                return (vId_Maestras == 0) ? new Tb_Maestras() : new Tb_Maestras_AD().GetRegistry(vId_Maestras);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Inserta un Objeto del tipo Tb_Maestras
        /// </summary>
        /// <param name="Tb_Maestras">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizado</returns>
        public Tb_Maestras Insert(Tb_Maestras vTb_Maestras)
        {
            try
            {
                return new Tb_Maestras_AD().Insert(vTb_Maestras);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Maestras
        /// </summary>
        /// <param name="Tb_Maestras">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Maestras Update(Tb_Maestras vTb_Maestras)
        {
            try
            {
                return new Tb_Maestras_AD().Update(vTb_Maestras);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Método que eliminara un registo del tipo Tb_Maestras en base a su clave primaria
        /// </summary>
        /// <param name="Id_Maestras">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Maestras, string vUsuario, DateTime vFecha)
        {
            try
            {
                return new Tb_Maestras_AD().Delete(vId_Maestras, vUsuario, vFecha);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        #endregion

        public List<Tb_Maestras> List()
        {
            throw new NotImplementedException();
        }

        public List<Tb_Maestras> Lista(string vValor, int vPadre = 0)
        {
            try
            {
                return new Tb_Maestras_AD().Lista(vValor, vPadre);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public Tb_Maestras Grabar(Tb_Maestras vTb_Maestra)
        {
            if (vTb_Maestra.Id_General >= 0 && vTb_Maestra.Id_Detalle == 0 && vTb_Maestra.Valor1 == null && vTb_Maestra.Valor2 == null && vTb_Maestra.Valor3 == null)
            {
                vTb_Maestra.Valor1 = vTb_Maestra.Valor2 = vTb_Maestra.Valor3 = vTb_Maestra.Descripcion;
            }

            vTb_Maestra.Fec_Ingreso = vTb_Maestra.Fec_Modifica = Variables.Hoy;
            vTb_Maestra.Flg_Activo = Variables.Activo;
            try
            {
                if (vTb_Maestra.Id_Maestras == 0)
                {
                    new Tb_Maestras_AD().Insert(vTb_Maestra);
                }
                else
                {
                    new Tb_Maestras_AD().Update(vTb_Maestra);
                }
                vTb_Maestra.Opcional = "OK";
                return vTb_Maestra;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public List<Tb_Maestras> ListPeriodo()
        {
            try
            {
                return new Tb_Maestras_AD().ListPeriodo();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

    }
}

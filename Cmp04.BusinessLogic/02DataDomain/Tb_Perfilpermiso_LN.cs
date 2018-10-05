/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Perfilpermiso_LN.cs
Objetivo          : Clase referida a los métodos de Lógica de Negocio de la clase Tb_Perfilpermiso
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
using System.Transactions;
#endregion

namespace Cmp04.BusinessLogic
{
    public class Tb_Perfilpermiso_LN : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Perfilpermiso
        /// </summary>
        /// <returns>Retorna una lista de objetos de tipo Tb_Perfilpermiso</returns>
        public List<Tb_Perfilpermiso> List()
        {
            try
            {
                return new Tb_Perfilpermiso_AD().List();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Método que recupera un regustro del tipo Tb_Perfilpermiso basado en su clave primaria
        /// </summary>
        /// <param name="Id_Perfil">Clave primaria del registro a eliminar</param>/// <param name="Id_Permiso">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Perfilpermiso GetRegistry(int vId_Perfil, int vId_Permiso)
        {
            try
            {
                return new Tb_Perfilpermiso_AD().GetRegistry(vId_Perfil,  vId_Permiso);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }
        
        /// <summary>
        /// Inserta un Objeto del tipo Tb_Perfilpermiso
        /// </summary>
        /// <param name="Tb_Perfilpermiso">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizado</returns>
        public Tb_Perfilpermiso Insert(Tb_Perfilpermiso vTb_Perfilpermiso)
        {
            try
            {
                return new Tb_Perfilpermiso_AD().Insert(vTb_Perfilpermiso);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Perfilpermiso
        /// </summary>
        /// <param name="Tb_Perfilpermiso">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Perfilpermiso Update(Tb_Perfilpermiso vTb_Perfilpermiso)
        {
            try
            {
                return new Tb_Perfilpermiso_AD().Update(vTb_Perfilpermiso);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        
        #endregion

        public int Grabar(int vId_Perfil, string vPermisos, string vUsuario)
        {
            int vResult = 0;
            try
            {
                string[] array = vPermisos.Split('|');
                using (TransactionScope tx = new TransactionScope())
                {
                    new Tb_Perfilpermiso_AD().Delete(vId_Perfil, vUsuario, Variables.Hoy);

                    foreach (var item in array)
                    {
                        if (item.Length > 0)
                        {
                            int vId_Permiso = Convert.ToInt32(item);

                            new Tb_Perfilpermiso_AD().Insert(new Tb_Perfilpermiso()
                            {
                                Fec_Ingreso = Variables.Hoy,
                                Fec_Modifica = Variables.Hoy,
                                Flg_Activo = Variables.Activo,
                                Id_Perfil = vId_Perfil,
                                Id_Permiso = vId_Permiso,
                                Usu_Ingreso = vUsuario,
                                Usu_Modifica = vUsuario
                            });   
                        }
                    }
                    tx.Complete();
                    vResult = 1;
                }
                return vResult;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }
    }
}

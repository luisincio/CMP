/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Perfilpermiso_AD.cs
Objetivo          : Clase referida a los métodos de Acceso a datos de la clase Tb_Perfilpermiso
Autor             : CMP-SISTEMAS (FRR)
Fecha Creación    : 09/06/2018
Métodos           : List, GetRegistry, Insert, Update, Delete
----------------------------------------------------------------------------------------*/
#region Espacios de Nombres
using Cmp02.Entities;
using Utildatatool;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
#endregion

namespace Cmp03.DataAccess
{
    public partial class Tb_Perfilpermiso_AD : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Perfilpermiso
        /// </summary>
        /// <returns>Listado de Tb_Perfilpermiso</returns>
        public List<Tb_Perfilpermiso> List()
        {
            List<Tb_Perfilpermiso> vLista = new List<Tb_Perfilpermiso>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_PERFILPERMISO"))
            {
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Perfilpermiso(vRdr));
                        }
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        /// <summary>
        /// Método que recupera un registro de tipo Tb_Perfilpermiso basado en su clave primaria
        /// </summary>
        /// <param name="ID_PERFIL">Clave primaria del registro a eliminar</param>/// <param name="ID_PERMISO">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Perfilpermiso GetRegistry(int vId_Perfil, int vId_Permiso)
        {
            Tb_Perfilpermiso vTb_Perfilpermiso = null;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_OBTENER_PERFILPERMISO"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERFIL", vId_Perfil);
                vCmd.Parameters.AddWithValue("@ID_PERMISO", vId_Permiso);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        vRdr.Read();
                        vTb_Perfilpermiso = new Tb_Perfilpermiso(vRdr);
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Perfilpermiso;
        }

        /// <summary>
        /// Inserta un Objeto de tipo Tb_Perfilpermiso
        /// </summary>
        /// <param name="Tb_Perfilpermiso">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizados</returns>
        public Tb_Perfilpermiso Insert(Tb_Perfilpermiso vTb_Perfilpermiso)
        {
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_INSERTAR_PERFILPERMISO"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERFIL", vTb_Perfilpermiso.Id_Perfil);
                vCmd.Parameters.AddWithValue("@ID_PERMISO", vTb_Perfilpermiso.Id_Permiso);
                vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Perfilpermiso.Flg_Activo);
                vCmd.Parameters.AddWithValue("@USU_INGRESO", vTb_Perfilpermiso.Usu_Ingreso);
                vCmd.Parameters.AddWithValue("@FEC_INGRESO", vTb_Perfilpermiso.Fec_Ingreso);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Perfilpermiso.Usu_Modifica);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Perfilpermiso.Fec_Modifica);
                vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Perfilpermiso;
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Perfilpermiso
        /// </summary>
        /// <param name="Tb_Perfilpermiso">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Perfilpermiso Update(Tb_Perfilpermiso vTb_Perfilpermiso)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ACTUALIZAR_PERFILPERMISO"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERFIL", vTb_Perfilpermiso.Id_Perfil);
                vCmd.Parameters.AddWithValue("@ID_PERMISO", vTb_Perfilpermiso.Id_Permiso);
                vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Perfilpermiso.Flg_Activo);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Perfilpermiso.Usu_Modifica);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Perfilpermiso.Fec_Modifica);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            if (vResp > 0) return vTb_Perfilpermiso; else return null;
        }

        /// <summary>
        /// Elimina un registo de tipo Tb_Perfilpermiso en base a su clave primaria
        /// </summary>
        /// <param name="ID_PERFIL">Clave primaria del registro a eliminar</param>/// <param name="ID_PERMISO">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId, string vUsuario, DateTime vFecha)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ELIMINAR_PERFILPERMISO"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERFIL", vId);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vUsuario);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vFecha);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vResp;
        }

        public Tb_Perfilpermiso GetRegistry(int vId)
        {
            throw new NotImplementedException();
        }



        #endregion

        #region Métodos Extendidos

        #endregion
    }
}
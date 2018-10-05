/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Pais_AD.cs
Objetivo          : Clase referida a los métodos de Acceso a datos de la clase Tb_Pais
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
    public partial class Tb_Pais_AD : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Pais
        /// </summary>
        /// <returns>Listado de Tb_Pais</returns>
        public List<Tb_Pais> List()
        {
            List<Tb_Pais> vLista = new List<Tb_Pais>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_PAIS"))
            {
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Pais(vRdr));
                        }
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        /// <summary>
        /// Método que recupera un registro de tipo Tb_Pais basado en su clave primaria
        /// </summary>
        /// <param name="ID_PAIS">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Pais GetRegistry(int vId_Pais)
        {
            Tb_Pais vTb_Pais = null;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_OBTENER_PAIS"))
            {
                vCmd.Parameters.AddWithValue("@ID_PAIS", vId_Pais);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        vRdr.Read();
                        vTb_Pais = new Tb_Pais(vRdr);
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Pais;
        }

        /// <summary>
        /// Inserta un Objeto de tipo Tb_Pais
        /// </summary>
        /// <param name="Tb_Pais">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizados</returns>
        public Tb_Pais Insert(Tb_Pais vTb_Pais)
        {
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_INSERTAR_PAIS"))
            {
                vCmd.Parameters.AddWithValue("@ISO2", vTb_Pais.Iso2);
                vCmd.Parameters.AddWithValue("@ISO3", vTb_Pais.Iso3);
                vCmd.Parameters.AddWithValue("@DESCRIPCION", vTb_Pais.Descripcion);
                vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Pais.Flg_Activo);
                vCmd.Parameters.AddWithValue("@USU_INGRESO", vTb_Pais.Usu_Ingreso);
                vCmd.Parameters.AddWithValue("@FEC_INGRESO", vTb_Pais.Fec_Ingreso);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Pais.Usu_Modifica);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Pais.Fec_Modifica);
                vTb_Pais.Id_Pais = Convert.ToInt32(vCmd.ExecuteScalar());
                vCmd.Dispose(); AdoNet.Dispose();
            }
            if (vTb_Pais.Id_Pais > 0) return vTb_Pais; else return null;
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Pais
        /// </summary>
        /// <param name="Tb_Pais">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Pais Update(Tb_Pais vTb_Pais)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ACTUALIZAR_PAIS"))
            {
                vCmd.Parameters.AddWithValue("@ID_PAIS", vTb_Pais.Id_Pais);
                vCmd.Parameters.AddWithValue("@ISO2", vTb_Pais.Iso2);
                vCmd.Parameters.AddWithValue("@ISO3", vTb_Pais.Iso3);
                vCmd.Parameters.AddWithValue("@DESCRIPCION", vTb_Pais.Descripcion);
                vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Pais.Flg_Activo);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Pais.Usu_Modifica);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Pais.Fec_Modifica);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            if (vResp > 0) return vTb_Pais; else return null;
        }

        /// <summary>
        /// Elimina un registo de tipo Tb_Pais en base a su clave primaria
        /// </summary>
        /// <param name="ID_PAIS">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Pais, string vUsuario, DateTime vFecha)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ELIMINAR_PAIS"))
            {
                vCmd.Parameters.AddWithValue("@ID_PAIS", vId_Pais);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vUsuario);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vFecha);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vResp;
        }

        #endregion

        #region Métodos Extendidos

        #endregion
    }
}
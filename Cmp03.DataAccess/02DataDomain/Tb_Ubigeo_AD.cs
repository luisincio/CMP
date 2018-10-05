/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Ubigeo_AD.cs
Objetivo          : Clase referida a los métodos de Acceso a datos de la clase Tb_Ubigeo
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
    public partial class Tb_Ubigeo_AD : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Ubigeo
        /// </summary>
        /// <returns>Listado de Tb_Ubigeo</returns>
        public List<Tb_Ubigeo> List()
        {
            List<Tb_Ubigeo> vLista = new List<Tb_Ubigeo>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_UBIGEO"))
            {
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Ubigeo(vRdr));
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
        /// Método que recupera un registro de tipo Tb_Ubigeo basado en su clave primaria
        /// </summary>
        /// <param name="ID_UBIGEO">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Ubigeo GetRegistry(string vId_Ubigeo)
        {
            Tb_Ubigeo vTb_Ubigeo = null;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_OBTENER_UBIGEO"))
            {
                vCmd.Parameters.AddWithValue("@ID_UBIGEO", vId_Ubigeo);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        vRdr.Read();
                        vTb_Ubigeo = new Tb_Ubigeo(vRdr);
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Ubigeo;
        }

        /// <summary>
        /// Inserta un Objeto de tipo Tb_Ubigeo
        /// </summary>
        /// <param name="Tb_Ubigeo">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizados</returns>
        public Tb_Ubigeo Insert(Tb_Ubigeo vTb_Ubigeo)
        {
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_INSERTAR_UBIGEO"))
            {
                vCmd.Parameters.AddWithValue("@ID_UBIGEO", vTb_Ubigeo.Id_Ubigeo);
                vCmd.Parameters.AddWithValue("@ID_PAIS", vTb_Ubigeo.Id_Pais);
                vCmd.Parameters.AddWithValue("@DEPARTAMENTO", vTb_Ubigeo.Departamento);
                vCmd.Parameters.AddWithValue("@PROVINCIA", vTb_Ubigeo.Provincia);
                vCmd.Parameters.AddWithValue("@DISTRITO", vTb_Ubigeo.Distrito);
                vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Ubigeo.Flg_Activo);
                vCmd.Parameters.AddWithValue("@USU_INGRESO", vTb_Ubigeo.Usu_Ingreso);
                vCmd.Parameters.AddWithValue("@FEC_INGRESO", vTb_Ubigeo.Fec_Ingreso);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Ubigeo.Usu_Modifica);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Ubigeo.Fec_Modifica);
                vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Ubigeo;
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Ubigeo
        /// </summary>
        /// <param name="Tb_Ubigeo">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Ubigeo Update(Tb_Ubigeo vTb_Ubigeo)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ACTUALIZAR_UBIGEO"))
            {
                vCmd.Parameters.AddWithValue("@ID_UBIGEO", vTb_Ubigeo.Id_Ubigeo);
                vCmd.Parameters.AddWithValue("@ID_PAIS", vTb_Ubigeo.Id_Pais);
                vCmd.Parameters.AddWithValue("@DEPARTAMENTO", vTb_Ubigeo.Departamento);
                vCmd.Parameters.AddWithValue("@PROVINCIA", vTb_Ubigeo.Provincia);
                vCmd.Parameters.AddWithValue("@DISTRITO", vTb_Ubigeo.Distrito);
                vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Ubigeo.Flg_Activo);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Ubigeo.Usu_Modifica);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Ubigeo.Fec_Modifica);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            if (vResp > 0) return vTb_Ubigeo; else return null;
        }

        /// <summary>
        /// Elimina un registo de tipo Tb_Ubigeo en base a su clave primaria
        /// </summary>
        /// <param name="ID_UBIGEO">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(string vId_Ubigeo, string vUsuario, DateTime vFecha)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ELIMINAR_UBIGEO"))
            {
                vCmd.Parameters.AddWithValue("@ID_UBIGEO", vId_Ubigeo);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vUsuario);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vFecha);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vResp;
        }

        #endregion

        #region Métodos Extendidos

        /// <summary>
        /// Método que lista los registros de Tb_Ubigeo
        /// </summary>
        /// <returns>Listado de Tb_Ubigeo</returns>
        public List<Tb_Ubigeo> List(string vData)
        {
            List<Tb_Ubigeo> vLista = new List<Tb_Ubigeo>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_UBIGEO"))
            {
                vCmd.Parameters.AddWithValue("@PARAMETRO", vData);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Ubigeo(vRdr));
                        }
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        #endregion


        public Tb_Ubigeo GetRegistry(int vId)
        {
            throw new NotImplementedException();
        }

        public int Delete(int vId, string vUsuario, DateTime vFecha)
        {
            throw new NotImplementedException();
        }
    }
}
/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Colegiado_Consejo_AD.cs
Objetivo          : Clase referida a los métodos de Acceso a datos de la clase Tb_Colegiado_Consejo
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
    public partial class Tb_Colegiado_Consejo_AD : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Colegiado_Consejo
        /// </summary>
        /// <returns>Listado de Tb_Colegiado_Consejo</returns>
        public List<Tb_Colegiado_Consejo> List()
        {
            List<Tb_Colegiado_Consejo> vLista = new List<Tb_Colegiado_Consejo>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_COLEGIADO_CONSEJO"))
            {
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Colegiado_Consejo(vRdr));
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
        /// Método que recupera un registro de tipo Tb_Colegiado_Consejo basado en su clave primaria
        /// </summary>
        /// <param name="ID_CONSEJO">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Colegiado_Consejo GetRegistry(int vId_Consejo)
        {
            Tb_Colegiado_Consejo vTb_Colegiado_Consejo = null;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_OBTENER_COLEGIADO_CONSEJO"))
            {
                vCmd.Parameters.AddWithValue("@ID_CONSEJO", vId_Consejo);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        vRdr.Read();
                        vTb_Colegiado_Consejo = new Tb_Colegiado_Consejo(vRdr);
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Colegiado_Consejo;
        }

        /// <summary>
        /// Inserta un Objeto de tipo Tb_Colegiado_Consejo
        /// </summary>
        /// <param name="Tb_Colegiado_Consejo">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizados</returns>
        public Tb_Colegiado_Consejo Insert(Tb_Colegiado_Consejo vTb_Colegiado_Consejo)
        {
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_INSERTAR_COLEGIADO_CONSEJO"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vTb_Colegiado_Consejo.Id_Persona);
                vCmd.Parameters.AddWithValue("@ID_CONSEJO_REGIONAL", vTb_Colegiado_Consejo.Id_Consejo_Regional);
                vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Colegiado_Consejo.Flg_Activo);
                vCmd.Parameters.AddWithValue("@USU_INGRESO", vTb_Colegiado_Consejo.Usu_Ingreso);
                vCmd.Parameters.AddWithValue("@FEC_INGRESO", vTb_Colegiado_Consejo.Fec_Ingreso);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Colegiado_Consejo.Usu_Modifica);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Colegiado_Consejo.Fec_Modifica);
                vTb_Colegiado_Consejo.Id_Consejo = Convert.ToInt32(vCmd.ExecuteScalar());
                vCmd.Dispose(); AdoNet.Dispose();
            }
            if (vTb_Colegiado_Consejo.Id_Consejo > 0) return vTb_Colegiado_Consejo; else return null;
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Colegiado_Consejo
        /// </summary>
        /// <param name="Tb_Colegiado_Consejo">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Colegiado_Consejo Update(Tb_Colegiado_Consejo vTb_Colegiado_Consejo)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ACTUALIZAR_COLEGIADO_CONSEJO"))
            {
                vCmd.Parameters.AddWithValue("@ID_CONSEJO", vTb_Colegiado_Consejo.Id_Consejo);
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vTb_Colegiado_Consejo.Id_Persona);
                vCmd.Parameters.AddWithValue("@ID_CONSEJO_REGIONAL", vTb_Colegiado_Consejo.Id_Consejo_Regional);
                vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Colegiado_Consejo.Flg_Activo);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Colegiado_Consejo.Usu_Modifica);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Colegiado_Consejo.Fec_Modifica);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            if (vResp > 0) return vTb_Colegiado_Consejo; else return null;
        }

        /// <summary>
        /// Elimina un registo de tipo Tb_Colegiado_Consejo en base a su clave primaria
        /// </summary>
        /// <param name="ID_CONSEJO">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Consejo, string vUsuario, DateTime vFecha)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ELIMINAR_COLEGIADO_CONSEJO"))
            {
                vCmd.Parameters.AddWithValue("@ID_CONSEJO", vId_Consejo);
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
        /// Método que lista los registros de Tb_Colegiado_Consejo
        /// </summary>
        /// <returns>Listado de Tb_Colegiado_Consejo</returns>
        public List<Tb_Colegiado_Consejo> List(int vId)
        {
            List<Tb_Colegiado_Consejo> vLista = new List<Tb_Colegiado_Consejo>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_COLEGIADO_CONSEJO"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vId);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Colegiado_Consejo(vRdr));
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
    }
}
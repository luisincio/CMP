/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Colegiado_Estado_AD.cs
Objetivo          : Clase referida a los métodos de Acceso a datos de la clase Tb_Colegiado_Estado
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
    public partial class Tb_Colegiado_Estado_AD : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Colegiado_Estado
        /// </summary>
        /// <returns>Listado de Tb_Colegiado_Estado</returns>
        public List<Tb_Colegiado_Estado> List()
        {
            List<Tb_Colegiado_Estado> vLista = new List<Tb_Colegiado_Estado>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_COLEGIADO_ESTADO"))
            {
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Colegiado_Estado(vRdr));
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
        /// Método que recupera un registro de tipo Tb_Colegiado_Estado basado en su clave primaria
        /// </summary>
        /// <param name="ID_ESTADO">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Colegiado_Estado GetRegistry(int vId_Estado)
        {
            Tb_Colegiado_Estado vTb_Colegiado_Estado = null;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_OBTENER_COLEGIADO_ESTADO"))
            {
                vCmd.Parameters.AddWithValue("@ID_ESTADO", vId_Estado);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        vRdr.Read();
                        vTb_Colegiado_Estado = new Tb_Colegiado_Estado(vRdr);
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Colegiado_Estado;
        }

        /// <summary>
        /// Inserta un Objeto de tipo Tb_Colegiado_Estado
        /// </summary>
        /// <param name="Tb_Colegiado_Estado">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizados</returns>
        public Tb_Colegiado_Estado Insert(Tb_Colegiado_Estado vTb_Colegiado_Estado)
        {
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_INSERTAR_COLEGIADO_ESTADO"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vTb_Colegiado_Estado.Id_Persona);
                vCmd.Parameters.AddWithValue("@ID_ESTADO_COLEGIADO", vTb_Colegiado_Estado.Id_Estado_Colegiado);
                vCmd.Parameters.AddWithValue("@OBSERVACION", vTb_Colegiado_Estado.ObservacionEstado);
                vCmd.Parameters.AddWithValue("@FEC_INICIO", vTb_Colegiado_Estado.Fec_Inicio);
                vCmd.Parameters.AddWithValue("@FEC_FIN", vTb_Colegiado_Estado.Fec_Fin);
                vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Colegiado_Estado.Flg_Activo);
                vCmd.Parameters.AddWithValue("@USU_INGRESO", vTb_Colegiado_Estado.Usu_Ingreso);
                vCmd.Parameters.AddWithValue("@FEC_INGRESO", vTb_Colegiado_Estado.Fec_Ingreso);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Colegiado_Estado.Usu_Modifica);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Colegiado_Estado.Fec_Modifica);
                vTb_Colegiado_Estado.Id_Estado = Convert.ToInt32(vCmd.ExecuteScalar());
                vCmd.Dispose(); AdoNet.Dispose();
            }
            if (vTb_Colegiado_Estado.Id_Estado > 0) return vTb_Colegiado_Estado; else return null;
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Colegiado_Estado
        /// </summary>
        /// <param name="Tb_Colegiado_Estado">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Colegiado_Estado Update(Tb_Colegiado_Estado vTb_Colegiado_Estado)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ACTUALIZAR_COLEGIADO_ESTADO"))
            {
                vCmd.Parameters.AddWithValue("@ID_ESTADO", vTb_Colegiado_Estado.Id_Estado);
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vTb_Colegiado_Estado.Id_Persona);
                vCmd.Parameters.AddWithValue("@ID_ESTADO_COLEGIADO", vTb_Colegiado_Estado.Id_Estado_Colegiado);
                vCmd.Parameters.AddWithValue("@OBSERVACION", vTb_Colegiado_Estado.ObservacionEstado);
                vCmd.Parameters.AddWithValue("@FEC_INICIO", vTb_Colegiado_Estado.Fec_Inicio);
                vCmd.Parameters.AddWithValue("@FEC_FIN", vTb_Colegiado_Estado.Fec_Fin);
                vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Colegiado_Estado.Flg_Activo);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Colegiado_Estado.Usu_Modifica);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Colegiado_Estado.Fec_Modifica);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            if (vResp > 0) return vTb_Colegiado_Estado; else return null;
        }

        /// <summary>
        /// Elimina un registo de tipo Tb_Colegiado_Estado en base a su clave primaria
        /// </summary>
        /// <param name="ID_ESTADO">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Estado, string vUsuario, DateTime vFecha)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ELIMINAR_COLEGIADO_ESTADO"))
            {
                vCmd.Parameters.AddWithValue("@ID_ESTADO", vId_Estado);
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
        /// Método que lista los registros de Tb_Colegiado_Estado
        /// </summary>
        /// <returns>Listado de Tb_Colegiado_Estado</returns>
        public List<Tb_Colegiado_Estado> List(int vId)
        {
            List<Tb_Colegiado_Estado> vLista = new List<Tb_Colegiado_Estado>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_COLEGIADO_ESTADO"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vId);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Colegiado_Estado(vRdr));
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
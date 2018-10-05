/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Colegiado_Carnet_AD.cs
Objetivo          : Clase referida a los métodos de Acceso a datos de la clase Tb_Colegiado_Carnet
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
    public partial class Tb_Colegiado_Carnet_AD : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Colegiado_Carnet
        /// </summary>
        /// <returns>Listado de Tb_Colegiado_Carnet</returns>
        public List<Tb_Colegiado_Carnet> List()
        {
            List<Tb_Colegiado_Carnet> vLista = new List<Tb_Colegiado_Carnet>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_COLEGIADO_CARNET"))
            {
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Colegiado_Carnet(vRdr));
                        }
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        /// <summary>
        /// Método que recupera un registro de tipo Tb_Colegiado_Carnet basado en su clave primaria
        /// </summary>
        /// <param name="ID_CARNET">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Colegiado_Carnet GetRegistry(int vId_Carnet)
        {
            Tb_Colegiado_Carnet vTb_Colegiado_Carnet = null;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_OBTENER_COLEGIADO_CARNET"))
            {
                vCmd.Parameters.AddWithValue("@ID_CARNET", vId_Carnet);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        vRdr.Read();
                        vTb_Colegiado_Carnet = new Tb_Colegiado_Carnet(vRdr);
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Colegiado_Carnet;
        }

        /// <summary>
        /// Inserta un Objeto de tipo Tb_Colegiado_Carnet
        /// </summary>
        /// <param name="Tb_Colegiado_Carnet">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizados</returns>
        public Tb_Colegiado_Carnet Insert(Tb_Colegiado_Carnet vTb_Colegiado_Carnet)
        {
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_INSERTAR_COLEGIADO_CARNET"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vTb_Colegiado_Carnet.Id_Persona);
                vCmd.Parameters.AddWithValue("@CORRELATIVO", vTb_Colegiado_Carnet.Correlativo);
                vCmd.Parameters.AddWithValue("@ID_COLEGIADO", vTb_Colegiado_Carnet.Id_Colegiado);
                vCmd.Parameters.AddWithValue("@ID_TIPOCARNET", vTb_Colegiado_Carnet.Id_Tipocarnet);
                vCmd.Parameters.AddWithValue("@FEC_EMISION", vTb_Colegiado_Carnet.Fec_Emision);
                vCmd.Parameters.AddWithValue("@FEC_ENTREGA", vTb_Colegiado_Carnet.Fec_Entrega);
                vCmd.Parameters.AddWithValue("@ID_CONSEJO", vTb_Colegiado_Carnet.Id_Consejo);
                vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Colegiado_Carnet.Flg_Activo);
                vCmd.Parameters.AddWithValue("@USU_INGRESO", vTb_Colegiado_Carnet.Usu_Ingreso);
                vCmd.Parameters.AddWithValue("@FEC_INGRESO", vTb_Colegiado_Carnet.Fec_Ingreso);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Colegiado_Carnet.Usu_Modifica);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Colegiado_Carnet.Fec_Modifica);
                vTb_Colegiado_Carnet.Id_Carnet = Convert.ToInt32(vCmd.ExecuteScalar());
                vCmd.Dispose(); AdoNet.Dispose();
            }
            if (vTb_Colegiado_Carnet.Id_Carnet > 0) return vTb_Colegiado_Carnet; else return null;
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Colegiado_Carnet
        /// </summary>
        /// <param name="Tb_Colegiado_Carnet">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Colegiado_Carnet Update(Tb_Colegiado_Carnet vTb_Colegiado_Carnet)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ACTUALIZAR_COLEGIADO_CARNET"))
            {
                vCmd.Parameters.AddWithValue("@ID_CARNET", vTb_Colegiado_Carnet.Id_Carnet);
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vTb_Colegiado_Carnet.Id_Persona);
                //vCmd.Parameters.AddWithValue("@CORRELATIVO", vTb_Colegiado_Carnet.Correlativo);
                vCmd.Parameters.AddWithValue("@ID_COLEGIADO", vTb_Colegiado_Carnet.Id_Colegiado);
                vCmd.Parameters.AddWithValue("@ID_TIPOCARNET", vTb_Colegiado_Carnet.Id_Tipocarnet);
                vCmd.Parameters.AddWithValue("@FEC_EMISION", vTb_Colegiado_Carnet.Fec_Emision);
                vCmd.Parameters.AddWithValue("@FEC_ENTREGA", vTb_Colegiado_Carnet.Fec_Entrega);
                vCmd.Parameters.AddWithValue("@ID_CONSEJO", vTb_Colegiado_Carnet.Id_Consejo);
                vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Colegiado_Carnet.Flg_Activo);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Colegiado_Carnet.Usu_Modifica);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Colegiado_Carnet.Fec_Modifica);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            if (vResp > 0) return vTb_Colegiado_Carnet; else return null;
        }

        /// <summary>
        /// Elimina un registo de tipo Tb_Colegiado_Carnet en base a su clave primaria
        /// </summary>
        /// <param name="ID_CARNET">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Carnet, string vUsuario, DateTime vFecha)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ELIMINAR_COLEGIADO_CARNET"))
            {
                vCmd.Parameters.AddWithValue("@ID_CARNET", vId_Carnet);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vUsuario);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vFecha);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vResp;
        }

        #endregion

        #region Métodos Extendidos

        public DateTime Actualizar_Emision(int vId_Carnet, bool vAccion, string vUsuario, DateTime vFecha)
        {
            DateTime vResp;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ACTUALIZAR_CARNET_EMISION"))
            {
                vCmd.Parameters.AddWithValue("@ID_CARNET", vId_Carnet);
                vCmd.Parameters.AddWithValue("@ESTADO", vAccion);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vUsuario);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vFecha);
                vResp = Convert.ToDateTime(vCmd.ExecuteScalar());
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vResp;
        }

        public DateTime Actualizar_Entrega(int vId_Carnet, bool vAccion, string vUsuario, DateTime vFecha)
        {
            DateTime vResp;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ACTUALIZAR_CARNET_ENTREGADO"))
            {
                vCmd.Parameters.AddWithValue("@ID_CARNET", vId_Carnet);
                vCmd.Parameters.AddWithValue("@ESTADO", vAccion);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vUsuario);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vFecha);
                vResp = Convert.ToDateTime(vCmd.ExecuteScalar());
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vResp;
        }

        #endregion
    }
}
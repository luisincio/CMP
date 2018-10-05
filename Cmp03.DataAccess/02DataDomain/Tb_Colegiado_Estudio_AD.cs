/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Colegiado_Estudio_AD.cs
Objetivo          : Clase referida a los métodos de Acceso a datos de la clase Tb_Colegiado_Estudio
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
    public partial class Tb_Colegiado_Estudio_AD : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Colegiado_Estudio
        /// </summary>
        /// <returns>Listado de Tb_Colegiado_Estudio</returns>
        public List<Tb_Colegiado_Estudio> List()
        {
            List<Tb_Colegiado_Estudio> vLista = new List<Tb_Colegiado_Estudio>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_COLEGIADO_ESTUDIO"))
            {
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Colegiado_Estudio(vRdr));
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
        /// Método que recupera un registro de tipo Tb_Colegiado_Estudio basado en su clave primaria
        /// </summary>
        /// <param name="ID_PERSONA">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Colegiado_Estudio GetRegistry(int vId_Persona)
        {
            Tb_Colegiado_Estudio vTb_Colegiado_Estudio = null;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_OBTENER_COLEGIADO_ESTUDIO"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vId_Persona);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        vRdr.Read();
                        vTb_Colegiado_Estudio = new Tb_Colegiado_Estudio(vRdr);
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Colegiado_Estudio;
        }

        /// <summary>
        /// Inserta un Objeto de tipo Tb_Colegiado_Estudio
        /// </summary>
        /// <param name="Tb_Colegiado_Estudio">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizados</returns>
        public Tb_Colegiado_Estudio Insert(Tb_Colegiado_Estudio vTb_Colegiado_Estudio)
        {
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_INSERTAR_COLEGIADO_ESTUDIO"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vTb_Colegiado_Estudio.Id_Persona);
                vCmd.Parameters.AddWithValue("@ID_ORIGEN", vTb_Colegiado_Estudio.Id_Origen);
                vCmd.Parameters.AddWithValue("@UNIVERSIDAD", vTb_Colegiado_Estudio.Universidad);
                vCmd.Parameters.AddWithValue("@NRO_TITULO", vTb_Colegiado_Estudio.Nro_Titulo);
                vCmd.Parameters.AddWithValue("@NRO_RESOLUCION", vTb_Colegiado_Estudio.Nro_Resolucion);
                vCmd.Parameters.AddWithValue("@ID_SITUACION", vTb_Colegiado_Estudio.Id_Situacion);
                vCmd.Parameters.AddWithValue("@FECHA_EGRESO", vTb_Colegiado_Estudio.Fecha_Egreso);
                vCmd.Parameters.AddWithValue("@FECHA_EXP_TITULO", vTb_Colegiado_Estudio.Fecha_Exp_Titulo);
                vCmd.Parameters.AddWithValue("@OBSERVACION", vTb_Colegiado_Estudio.Observacion_Est);
                vCmd.Parameters.AddWithValue("@ENTIDAD_ACREDITADA", vTb_Colegiado_Estudio.Entidad_Acreditada);
                vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Colegiado_Estudio.Flg_Activo);
                vCmd.Parameters.AddWithValue("@USU_INGRESO", vTb_Colegiado_Estudio.Usu_Ingreso);
                vCmd.Parameters.AddWithValue("@FEC_INGRESO", vTb_Colegiado_Estudio.Fec_Ingreso);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Colegiado_Estudio.Usu_Modifica);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Colegiado_Estudio.Fec_Modifica);
                vTb_Colegiado_Estudio.Id_Estudio = Convert.ToInt32(vCmd.ExecuteScalar());
                vCmd.Dispose(); AdoNet.Dispose();
            }
            if (vTb_Colegiado_Estudio.Id_Estudio > 0) return vTb_Colegiado_Estudio; else return null;
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Colegiado_Estudio
        /// </summary>
        /// <param name="Tb_Colegiado_Estudio">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Colegiado_Estudio Update(Tb_Colegiado_Estudio vTb_Colegiado_Estudio)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ACTUALIZAR_COLEGIADO_ESTUDIO"))
            {
                vCmd.Parameters.AddWithValue("@ID_ESTUDIO", vTb_Colegiado_Estudio.Id_Estudio);
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vTb_Colegiado_Estudio.Id_Persona);
                vCmd.Parameters.AddWithValue("@ID_ORIGEN", vTb_Colegiado_Estudio.Id_Origen);
                vCmd.Parameters.AddWithValue("@UNIVERSIDAD", vTb_Colegiado_Estudio.Universidad);
                vCmd.Parameters.AddWithValue("@NRO_TITULO", vTb_Colegiado_Estudio.Nro_Titulo);
                vCmd.Parameters.AddWithValue("@NRO_RESOLUCION", vTb_Colegiado_Estudio.Nro_Resolucion);
                vCmd.Parameters.AddWithValue("@ID_SITUACION", vTb_Colegiado_Estudio.Id_Situacion);
                vCmd.Parameters.AddWithValue("@FECHA_EGRESO", vTb_Colegiado_Estudio.Fecha_Egreso);
                vCmd.Parameters.AddWithValue("@FECHA_EXP_TITULO", vTb_Colegiado_Estudio.Fecha_Exp_Titulo);
                vCmd.Parameters.AddWithValue("@OBSERVACION", vTb_Colegiado_Estudio.Observacion_Est);
                vCmd.Parameters.AddWithValue("@ENTIDAD_ACREDITADA", vTb_Colegiado_Estudio.Entidad_Acreditada);
                vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Colegiado_Estudio.Flg_Activo);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Colegiado_Estudio.Usu_Modifica);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Colegiado_Estudio.Fec_Modifica);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            if (vResp > 0) return vTb_Colegiado_Estudio; else return null;
        }

        /// <summary>
        /// Elimina un registo de tipo Tb_Colegiado_Estudio en base a su clave primaria
        /// </summary>
        /// <param name="ID_PERSONA">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Persona, string vUsuario, DateTime vFecha)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ELIMINAR_COLEGIADO_ESTUDIO"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vId_Persona);
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
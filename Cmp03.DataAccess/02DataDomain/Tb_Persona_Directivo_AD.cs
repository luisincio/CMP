/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Persona_Directivo_AD.cs
Objetivo          : Clase referida a los métodos de Acceso a datos de la clase Tb_Persona_Directivo
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
    public partial class Tb_Persona_Directivo_AD : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Persona_Directivo
        /// </summary>
        /// <returns>Listado de Tb_Persona_Directivo</returns>
        public List<Tb_Persona_Directivo> List(int vConsejo, string vPeriodo)
        {
            List<Tb_Persona_Directivo> vLista = new List<Tb_Persona_Directivo>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_PERSONA_DIRECTIVO"))
            {
                vCmd.Parameters.AddWithValue("@ID_CONSEJO", vConsejo);
                vCmd.Parameters.AddWithValue("@PERIODO", vPeriodo);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Persona_Directivo(vRdr));
                        }
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        /// <summary>
        /// Método que recupera un registro de tipo Tb_Persona_Directivo basado en su clave primaria
        /// </summary>
        /// <param name="ID_DIRECTIVO">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Persona_Directivo GetRegistry(int vId_Directivo)
        {
            Tb_Persona_Directivo vTb_Persona_Directivo = null;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_OBTENER_PERSONA_DIRECTIVO"))
            {
                vCmd.Parameters.AddWithValue("@ID_DIRECTIVO", vId_Directivo);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        vRdr.Read();
                        vTb_Persona_Directivo = new Tb_Persona_Directivo(vRdr);
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Persona_Directivo;
        }

        /// <summary>
        /// Inserta un Objeto de tipo Tb_Persona_Directivo
        /// </summary>
        /// <param name="Tb_Persona_Directivo">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizados</returns>
        public Tb_Persona_Directivo Insert(Tb_Persona_Directivo vTb_Persona_Directivo)
        {
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_INSERTAR_PERSONA_DIRECTIVO"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vTb_Persona_Directivo.Id_Persona);
                vCmd.Parameters.AddWithValue("@ID_CONSEJO", vTb_Persona_Directivo.Id_Consejo);
                vCmd.Parameters.AddWithValue("@COLEGIADO", vTb_Persona_Directivo.Colegiado);
                vCmd.Parameters.AddWithValue("@APELLIDO_PATERNO", vTb_Persona_Directivo.Apellido_Paterno);
                vCmd.Parameters.AddWithValue("@APELLIDO_MATERNO", vTb_Persona_Directivo.Apellido_Materno);
                vCmd.Parameters.AddWithValue("@NOMBRES", vTb_Persona_Directivo.Nombres);
                vCmd.Parameters.AddWithValue("@ID_TIPO_DOCUMENTO", vTb_Persona_Directivo.Id_Tipo_Documento);
                vCmd.Parameters.AddWithValue("@NRO_DOCUMENTO", vTb_Persona_Directivo.Nro_Documento);
                vCmd.Parameters.AddWithValue("@ID_CARGO", vTb_Persona_Directivo.Id_Cargo);
                vCmd.Parameters.AddWithValue("@FEC_INICIO", vTb_Persona_Directivo.Fec_Inicio);
                vCmd.Parameters.AddWithValue("@FEC_TERMINO", vTb_Persona_Directivo.Fec_Termino);
                vCmd.Parameters.AddWithValue("@PERIODO", vTb_Persona_Directivo.Periodo);
                vCmd.Parameters.AddWithValue("@ID_ESTADO", vTb_Persona_Directivo.Id_Estado);
                vCmd.Parameters.AddWithValue("@ID_ESTADO_DIRECTIVO", vTb_Persona_Directivo.Id_Estado_Directivo);
                vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Persona_Directivo.Flg_Activo);
                vCmd.Parameters.AddWithValue("@USU_INGRESO", vTb_Persona_Directivo.Usu_Ingreso);
                vCmd.Parameters.AddWithValue("@FEC_INGRESO", vTb_Persona_Directivo.Fec_Ingreso);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Persona_Directivo.Usu_Modifica);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Persona_Directivo.Fec_Modifica);
                vTb_Persona_Directivo.Id_Directivo = Convert.ToInt32(vCmd.ExecuteScalar());
                vCmd.Dispose(); AdoNet.Dispose();
            }
            if (vTb_Persona_Directivo.Id_Directivo > 0) return vTb_Persona_Directivo; else return null;
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Persona_Directivo
        /// </summary>
        /// <param name="Tb_Persona_Directivo">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Persona_Directivo Update(Tb_Persona_Directivo vTb_Persona_Directivo)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ACTUALIZAR_PERSONA_DIRECTIVO"))
            {
                vCmd.Parameters.AddWithValue("@ID_DIRECTIVO", vTb_Persona_Directivo.Id_Directivo);
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vTb_Persona_Directivo.Id_Persona);
                vCmd.Parameters.AddWithValue("@ID_CONSEJO", vTb_Persona_Directivo.Id_Consejo);
                vCmd.Parameters.AddWithValue("@COLEGIADO", vTb_Persona_Directivo.Colegiado);
                vCmd.Parameters.AddWithValue("@APELLIDO_PATERNO", vTb_Persona_Directivo.Apellido_Paterno);
                vCmd.Parameters.AddWithValue("@APELLIDO_MATERNO", vTb_Persona_Directivo.Apellido_Materno);
                vCmd.Parameters.AddWithValue("@NOMBRES", vTb_Persona_Directivo.Nombres);
                vCmd.Parameters.AddWithValue("@ID_TIPO_DOCUMENTO", vTb_Persona_Directivo.Id_Tipo_Documento);
                vCmd.Parameters.AddWithValue("@NRO_DOCUMENTO", vTb_Persona_Directivo.Nro_Documento);
                vCmd.Parameters.AddWithValue("@ID_CARGO", vTb_Persona_Directivo.Id_Cargo);
                vCmd.Parameters.AddWithValue("@FEC_INICIO", vTb_Persona_Directivo.Fec_Inicio);
                vCmd.Parameters.AddWithValue("@FEC_TERMINO", vTb_Persona_Directivo.Fec_Termino);
                vCmd.Parameters.AddWithValue("@PERIODO", vTb_Persona_Directivo.Periodo);
                vCmd.Parameters.AddWithValue("@ID_ESTADO", vTb_Persona_Directivo.Id_Estado);
                vCmd.Parameters.AddWithValue("@ID_ESTADO_DIRECTIVO", vTb_Persona_Directivo.Id_Estado_Directivo);
                vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Persona_Directivo.Flg_Activo);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Persona_Directivo.Usu_Modifica);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Persona_Directivo.Fec_Modifica);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            if (vResp > 0) return vTb_Persona_Directivo; else return null;
        }

        /// <summary>
        /// Elimina un registo de tipo Tb_Persona_Directivo en base a su clave primaria
        /// </summary>
        /// <param name="ID_DIRECTIVO">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Directivo, string vUsuario, DateTime vFecha)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ELIMINAR_PERSONA_DIRECTIVO"))
            {
                vCmd.Parameters.AddWithValue("@ID_DIRECTIVO", vId_Directivo);
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
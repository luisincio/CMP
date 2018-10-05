/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Colegiado_Especialidad_AD.cs
Objetivo          : Clase referida a los métodos de Acceso a datos de la clase Tb_Colegiado_Especialidad
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
    public partial class Tb_Colegiado_Especialidad_AD : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Colegiado_Especialidad
        /// </summary>
        /// <returns>Listado de Tb_Colegiado_Especialidad</returns>
        public List<Tb_Colegiado_Especialidad> List()
        {
            List<Tb_Colegiado_Especialidad> vLista = new List<Tb_Colegiado_Especialidad>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_COLEGIADO_ESPECIALIDAD"))
            {
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Colegiado_Especialidad(vRdr));
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
        /// Método que recupera un registro de tipo Tb_Colegiado_Especialidad basado en su clave primaria
        /// </summary>
        /// <param name="ID_ESPECIALIDAD">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Colegiado_Especialidad GetRegistry(int vId_Especialidad)
        {
            Tb_Colegiado_Especialidad vTb_Colegiado_Especialidad = null;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_OBTENER_COLEGIADO_ESPECIALIDAD"))
            {
                vCmd.Parameters.AddWithValue("@ID_ESPECIALIDAD", vId_Especialidad);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        vRdr.Read();
                        vTb_Colegiado_Especialidad = new Tb_Colegiado_Especialidad(vRdr);
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Colegiado_Especialidad;
        }

        /// <summary>
        /// Inserta un Objeto de tipo Tb_Colegiado_Especialidad
        /// </summary>
        /// <param name="Tb_Colegiado_Especialidad">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizados</returns>
        public Tb_Colegiado_Especialidad Insert(Tb_Colegiado_Especialidad vTb_Colegiado_Especialidad)
        {
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_INSERTAR_COLEGIADO_ESPECIALIDAD"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vTb_Colegiado_Especialidad.Id_Persona);
                vCmd.Parameters.AddWithValue("@NRO_ESPECIALIDAD", vTb_Colegiado_Especialidad.Nro_Especialidad);
                vCmd.Parameters.AddWithValue("@ID_TIPO", vTb_Colegiado_Especialidad.Id_Tipo);
                vCmd.Parameters.AddWithValue("@ESPECIALIDAD", vTb_Colegiado_Especialidad.Especialidad);
                vCmd.Parameters.AddWithValue("@ID_ORIGEN", vTb_Colegiado_Especialidad.Id_Origen_Especialidad);
                vCmd.Parameters.AddWithValue("@UNIVERSIDAD", vTb_Colegiado_Especialidad.Universidad_Especialidad);
                vCmd.Parameters.AddWithValue("@ID_SITUACION", vTb_Colegiado_Especialidad.Id_Situacion_Especialidad);
                vCmd.Parameters.AddWithValue("@FECHA_REGISTRO", vTb_Colegiado_Especialidad.Fecha_Registro);
                vCmd.Parameters.AddWithValue("@FECHA_CADUCIDAD", vTb_Colegiado_Especialidad.Fecha_Caducidad);
                vCmd.Parameters.AddWithValue("@RESOLUCION", vTb_Colegiado_Especialidad.Resolucion);
                vCmd.Parameters.AddWithValue("@FECHA_RESOLUCION", vTb_Colegiado_Especialidad.Fecha_Resolucion);
                vCmd.Parameters.AddWithValue("@ID_CONS_REG_TRAMITE", vTb_Colegiado_Especialidad.Id_Cons_Reg_Tramite);
                vCmd.Parameters.AddWithValue("@FLG_RECERTIFICADO", vTb_Colegiado_Especialidad.Flg_Recertificado);
                vCmd.Parameters.AddWithValue("@FECHA_ESPECIALIDAD", vTb_Colegiado_Especialidad.Fecha_Especialidad);
                vCmd.Parameters.AddWithValue("@ENTIDAD_ACREDITADA", vTb_Colegiado_Especialidad.Entidad_Acreditada_Esp);
                vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Colegiado_Especialidad.Flg_Activo);
                vCmd.Parameters.AddWithValue("@USU_INGRESO", vTb_Colegiado_Especialidad.Usu_Ingreso);
                vCmd.Parameters.AddWithValue("@FEC_INGRESO", vTb_Colegiado_Especialidad.Fec_Ingreso);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Colegiado_Especialidad.Usu_Modifica);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Colegiado_Especialidad.Fec_Modifica);
                vTb_Colegiado_Especialidad.Id_Especialidad = Convert.ToInt32(vCmd.ExecuteScalar());
                vCmd.Dispose(); AdoNet.Dispose();
            }
            if (vTb_Colegiado_Especialidad.Id_Especialidad > 0) return vTb_Colegiado_Especialidad; else return null;
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Colegiado_Especialidad
        /// </summary>
        /// <param name="Tb_Colegiado_Especialidad">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Colegiado_Especialidad Update(Tb_Colegiado_Especialidad vTb_Colegiado_Especialidad)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ACTUALIZAR_COLEGIADO_ESPECIALIDAD"))
            {
                vCmd.Parameters.AddWithValue("@ID_ESPECIALIDAD", vTb_Colegiado_Especialidad.Id_Especialidad);
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vTb_Colegiado_Especialidad.Id_Persona);
                vCmd.Parameters.AddWithValue("@NRO_ESPECIALIDAD", vTb_Colegiado_Especialidad.Nro_Especialidad);
                vCmd.Parameters.AddWithValue("@ID_TIPO", vTb_Colegiado_Especialidad.Id_Tipo);
                vCmd.Parameters.AddWithValue("@ESPECIALIDAD", vTb_Colegiado_Especialidad.Especialidad);
                vCmd.Parameters.AddWithValue("@ID_ORIGEN", vTb_Colegiado_Especialidad.Id_Origen_Especialidad);
                vCmd.Parameters.AddWithValue("@UNIVERSIDAD", vTb_Colegiado_Especialidad.Universidad_Especialidad);
                vCmd.Parameters.AddWithValue("@ID_SITUACION", vTb_Colegiado_Especialidad.Id_Situacion_Especialidad);
                vCmd.Parameters.AddWithValue("@FECHA_REGISTRO", vTb_Colegiado_Especialidad.Fecha_Registro);
                vCmd.Parameters.AddWithValue("@FECHA_CADUCIDAD", vTb_Colegiado_Especialidad.Fecha_Caducidad);
                vCmd.Parameters.AddWithValue("@RESOLUCION", vTb_Colegiado_Especialidad.Resolucion);
                vCmd.Parameters.AddWithValue("@FECHA_RESOLUCION", vTb_Colegiado_Especialidad.Fecha_Resolucion);
                vCmd.Parameters.AddWithValue("@ID_CONS_REG_TRAMITE", vTb_Colegiado_Especialidad.Id_Cons_Reg_Tramite);
                vCmd.Parameters.AddWithValue("@FLG_RECERTIFICADO", vTb_Colegiado_Especialidad.Flg_Recertificado);
                vCmd.Parameters.AddWithValue("@FECHA_ESPECIALIDAD", vTb_Colegiado_Especialidad.Fecha_Especialidad);
                vCmd.Parameters.AddWithValue("@ENTIDAD_ACREDITADA", vTb_Colegiado_Especialidad.Entidad_Acreditada_Esp);
                vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Colegiado_Especialidad.Flg_Activo);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Colegiado_Especialidad.Usu_Modifica);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Colegiado_Especialidad.Fec_Modifica);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            if (vResp > 0) return vTb_Colegiado_Especialidad; else return null;
        }

        /// <summary>
        /// Elimina un registo de tipo Tb_Colegiado_Especialidad en base a su clave primaria
        /// </summary>
        /// <param name="ID_ESPECIALIDAD">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Especialidad, string vUsuario, DateTime vFecha)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ELIMINAR_COLEGIADO_ESPECIALIDAD"))
            {
                vCmd.Parameters.AddWithValue("@ID_ESPECIALIDAD", vId_Especialidad);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vUsuario);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vFecha);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vResp;
        }

        #endregion

        #region Métodos Extendidos

        public List<Tb_Colegiado_Especialidad> List(int vId)
        {
            List<Tb_Colegiado_Especialidad> vLista = new List<Tb_Colegiado_Especialidad>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_COLEGIADO_ESPECIALIDAD"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vId);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Colegiado_Especialidad(vRdr));
                        }
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        public int Update_NumeroEspecialidad(int vId_TipoEspecialidad)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ACTUALIZAR_PARAMETRO_ESPECIALIDAD"))
            {
                vCmd.Parameters.AddWithValue("@ID_TIPO", vId_TipoEspecialidad);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vResp;
        }

        

        #endregion
    }
}
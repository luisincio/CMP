/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Colegiado_Laboral_AD.cs
Objetivo          : Clase referida a los métodos de Acceso a datos de la clase Tb_Colegiado_Laboral
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
    public partial class Tb_Colegiado_Laboral_AD : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Colegiado_Laboral
        /// </summary>
        /// <returns>Listado de Tb_Colegiado_Laboral</returns>
        public List<Tb_Colegiado_Laboral> List()
        {
            List<Tb_Colegiado_Laboral> vLista = new List<Tb_Colegiado_Laboral>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_COLEGIADO_LABORAL"))
            {
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Colegiado_Laboral(vRdr));
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
        /// Método que recupera un registro de tipo Tb_Colegiado_Laboral basado en su clave primaria
        /// </summary>
        /// <param name="ID_INFORMACION_LABORAL">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Colegiado_Laboral GetRegistry(int vId_Informacion_Laboral)
        {
            Tb_Colegiado_Laboral vTb_Colegiado_Laboral = null;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_OBTENER_COLEGIADO_LABORAL"))
            {
                vCmd.Parameters.AddWithValue("@ID_INFORMACION_LABORAL", vId_Informacion_Laboral);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        vRdr.Read();
                        vTb_Colegiado_Laboral = new Tb_Colegiado_Laboral(vRdr);
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Colegiado_Laboral;
        }

        /// <summary>
        /// Inserta un Objeto de tipo Tb_Colegiado_Laboral
        /// </summary>
        /// <param name="Tb_Colegiado_Laboral">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizados</returns>
        public Tb_Colegiado_Laboral Insert(Tb_Colegiado_Laboral vTb_Colegiado_Laboral)
        {
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_INSERTAR_COLEGIADO_LABORAL"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vTb_Colegiado_Laboral.Id_Persona);
                vCmd.Parameters.AddWithValue("@ID_SECTOR", vTb_Colegiado_Laboral.Id_Sector);
                vCmd.Parameters.AddWithValue("@ID_GRUPO_OCUPACIONAL", vTb_Colegiado_Laboral.Id_Grupo_Ocupacional);
                vCmd.Parameters.AddWithValue("@EMPRESA", vTb_Colegiado_Laboral.Empresa);
                vCmd.Parameters.AddWithValue("@DIRECCION", vTb_Colegiado_Laboral.Direccion);
                vCmd.Parameters.AddWithValue("@ID_UBIGEO", vTb_Colegiado_Laboral.Id_Ubigeo_Laboral);
                //vCmd.Parameters.AddWithValue("@ID_PUNTO_ATENCION", vTb_Colegiado_Laboral.Id_Punto_Atencion);
                vCmd.Parameters.AddWithValue("@TELEFONO", vTb_Colegiado_Laboral.Telefono);
                vCmd.Parameters.AddWithValue("@FAX", vTb_Colegiado_Laboral.Fax);
                vCmd.Parameters.AddWithValue("@TELEFONO2", vTb_Colegiado_Laboral.Telefono2);
                vCmd.Parameters.AddWithValue("@FAX2", vTb_Colegiado_Laboral.Fax2);
                vCmd.Parameters.AddWithValue("@GLOSA", vTb_Colegiado_Laboral.Glosa);
                vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Colegiado_Laboral.Flg_Activo);
                vCmd.Parameters.AddWithValue("@USU_INGRESO", vTb_Colegiado_Laboral.Usu_Ingreso);
                vCmd.Parameters.AddWithValue("@FEC_INGRESO", vTb_Colegiado_Laboral.Fec_Ingreso);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Colegiado_Laboral.Usu_Modifica);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Colegiado_Laboral.Fec_Modifica);
                vTb_Colegiado_Laboral.Id_Informacion_Laboral = Convert.ToInt32(vCmd.ExecuteScalar());
                vCmd.Dispose(); AdoNet.Dispose();
            }
            if (vTb_Colegiado_Laboral.Id_Informacion_Laboral > 0) return vTb_Colegiado_Laboral; else return null;
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Colegiado_Laboral
        /// </summary>
        /// <param name="Tb_Colegiado_Laboral">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Colegiado_Laboral Update(Tb_Colegiado_Laboral vTb_Colegiado_Laboral)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ACTUALIZAR_COLEGIADO_LABORAL"))
            {
                vCmd.Parameters.AddWithValue("@ID_INFORMACION_LABORAL", vTb_Colegiado_Laboral.Id_Informacion_Laboral);
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vTb_Colegiado_Laboral.Id_Persona);
                vCmd.Parameters.AddWithValue("@ID_SECTOR", vTb_Colegiado_Laboral.Id_Sector);
                vCmd.Parameters.AddWithValue("@ID_GRUPO_OCUPACIONAL", vTb_Colegiado_Laboral.Id_Grupo_Ocupacional);
                vCmd.Parameters.AddWithValue("@EMPRESA", vTb_Colegiado_Laboral.Empresa);
                vCmd.Parameters.AddWithValue("@DIRECCION", vTb_Colegiado_Laboral.Direccion);
                vCmd.Parameters.AddWithValue("@ID_UBIGEO", vTb_Colegiado_Laboral.Id_Ubigeo_Laboral);
                //vCmd.Parameters.AddWithValue("@ID_PUNTO_ATENCION", vTb_Colegiado_Laboral.Id_Punto_Atencion);
                vCmd.Parameters.AddWithValue("@TELEFONO", vTb_Colegiado_Laboral.Telefono);
                vCmd.Parameters.AddWithValue("@FAX", vTb_Colegiado_Laboral.Fax);
                vCmd.Parameters.AddWithValue("@TELEFONO2", vTb_Colegiado_Laboral.Telefono2);
                vCmd.Parameters.AddWithValue("@FAX2", vTb_Colegiado_Laboral.Fax2);
                vCmd.Parameters.AddWithValue("@GLOSA", vTb_Colegiado_Laboral.Glosa);
                vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Colegiado_Laboral.Flg_Activo);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Colegiado_Laboral.Usu_Modifica);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Colegiado_Laboral.Fec_Modifica);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            if (vResp > 0) return vTb_Colegiado_Laboral; else return null;
        }

        /// <summary>
        /// Elimina un registo de tipo Tb_Colegiado_Laboral en base a su clave primaria
        /// </summary>
        /// <param name="ID_INFORMACION_LABORAL">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Informacion_Laboral, string vUsuario, DateTime vFecha)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ELIMINAR_COLEGIADO_LABORAL"))
            {
                vCmd.Parameters.AddWithValue("@ID_INFORMACION_LABORAL", vId_Informacion_Laboral);
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
        /// Método que lista los registros de Tb_Colegiado_Laboral
        /// </summary>
        /// <returns>Listado de Tb_Colegiado_Laboral</returns>
        public List<Tb_Colegiado_Laboral> List(int vId)
        {
            List<Tb_Colegiado_Laboral> vLista = new List<Tb_Colegiado_Laboral>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_COLEGIADO_LABORAL"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vId);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Colegiado_Laboral(vRdr));
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
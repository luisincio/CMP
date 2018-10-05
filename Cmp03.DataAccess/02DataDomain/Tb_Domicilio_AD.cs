/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Domicilio_AD.cs
Objetivo          : Clase referida a los métodos de Acceso a datos de la clase Tb_Domicilio
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
    public partial class Tb_Domicilio_AD : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Domicilio
        /// </summary>
        /// <returns>Listado de Tb_Domicilio</returns>
        public List<Tb_Domicilio> List()
        {
            List<Tb_Domicilio> vLista = new List<Tb_Domicilio>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_DOMICILIO"))
            {
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Domicilio(vRdr));
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
        /// Método que recupera un registro de tipo Tb_Domicilio basado en su clave primaria
        /// </summary>
        /// <param name="ID_DOMICILIO">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Domicilio GetRegistry(int vId_Persona)
        {
            Tb_Domicilio vTb_Domicilio = null;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_OBTENER_DOMICILIO"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vId_Persona);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        vRdr.Read();
                        vTb_Domicilio = new Tb_Domicilio(vRdr);
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Domicilio;
        }

        /// <summary>
        /// Inserta un Objeto de tipo Tb_Domicilio
        /// </summary>
        /// <param name="Tb_Domicilio">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizados</returns>
        public Tb_Domicilio Insert(Tb_Domicilio vTb_Domicilio)
        {
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_INSERTAR_DOMICILIO"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vTb_Domicilio.Id_Persona);
                vCmd.Parameters.AddWithValue("@ID_PAIS", vTb_Domicilio.Id_Pais);
                vCmd.Parameters.AddWithValue("@ID_TIPO_VIA", vTb_Domicilio.Id_Tipo_Via);
                vCmd.Parameters.AddWithValue("@NOMBRE_VIA", vTb_Domicilio.Nombre_Via);
                vCmd.Parameters.AddWithValue("@NRO_VIA", vTb_Domicilio.Nro_Via);
                vCmd.Parameters.AddWithValue("@NRO_KM", vTb_Domicilio.Nro_Km);
                vCmd.Parameters.AddWithValue("@MANZANA", vTb_Domicilio.Manzana);
                vCmd.Parameters.AddWithValue("@LOTE", vTb_Domicilio.Lote);
                vCmd.Parameters.AddWithValue("@NRO_INTERIOR", vTb_Domicilio.Nro_Interior);
                vCmd.Parameters.AddWithValue("@NRO_DEPARTAMENTO", vTb_Domicilio.Nro_Departamento);
                vCmd.Parameters.AddWithValue("@ID_TIPO_ZONA", vTb_Domicilio.Id_Tipo_Zona);
                vCmd.Parameters.AddWithValue("@NOMBRE_ZONA", vTb_Domicilio.Nombre_Zona);
                vCmd.Parameters.AddWithValue("@REFERENCIA", vTb_Domicilio.Referencia);
                vCmd.Parameters.AddWithValue("@DOMICILIO_COMPLETO", vTb_Domicilio.Domicilio_Completo);
                vCmd.Parameters.AddWithValue("@ID_UBIGEO", vTb_Domicilio.Id_Ubigeo);
                vCmd.Parameters.AddWithValue("@FLG_DOMICILIO_FISCAL", vTb_Domicilio.Flg_Domicilio_Fiscal);
                vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Domicilio.Flg_Activo);
                vCmd.Parameters.AddWithValue("@USU_INGRESO", vTb_Domicilio.Usu_Ingreso);
                vCmd.Parameters.AddWithValue("@FEC_INGRESO", vTb_Domicilio.Fec_Ingreso);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Domicilio.Usu_Modifica);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Domicilio.Fec_Modifica);
                vCmd.Parameters.AddWithValue("@SECCION", vTb_Domicilio.Seccion);
                vTb_Domicilio.Id_Domicilio = Convert.ToInt32(vCmd.ExecuteScalar());
                vCmd.Dispose(); AdoNet.Dispose();
            }
            if (vTb_Domicilio.Id_Domicilio > 0) return vTb_Domicilio; else return null;
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Domicilio
        /// </summary>
        /// <param name="Tb_Domicilio">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Domicilio Update(Tb_Domicilio vTb_Domicilio)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ACTUALIZAR_DOMICILIO"))
            {
                vCmd.Parameters.AddWithValue("@ID_DOMICILIO", vTb_Domicilio.Id_Domicilio);
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vTb_Domicilio.Id_Persona);
                vCmd.Parameters.AddWithValue("@ID_PAIS", vTb_Domicilio.Id_Pais);
                vCmd.Parameters.AddWithValue("@ID_TIPO_VIA", vTb_Domicilio.Id_Tipo_Via);
                vCmd.Parameters.AddWithValue("@NOMBRE_VIA", vTb_Domicilio.Nombre_Via);
                vCmd.Parameters.AddWithValue("@NRO_VIA", vTb_Domicilio.Nro_Via);
                vCmd.Parameters.AddWithValue("@NRO_KM", vTb_Domicilio.Nro_Km);
                vCmd.Parameters.AddWithValue("@MANZANA", vTb_Domicilio.Manzana);
                vCmd.Parameters.AddWithValue("@LOTE", vTb_Domicilio.Lote);
                vCmd.Parameters.AddWithValue("@NRO_INTERIOR", vTb_Domicilio.Nro_Interior);
                vCmd.Parameters.AddWithValue("@NRO_DEPARTAMENTO", vTb_Domicilio.Nro_Departamento);
                vCmd.Parameters.AddWithValue("@ID_TIPO_ZONA", vTb_Domicilio.Id_Tipo_Zona);
                vCmd.Parameters.AddWithValue("@NOMBRE_ZONA", vTb_Domicilio.Nombre_Zona);
                vCmd.Parameters.AddWithValue("@REFERENCIA", vTb_Domicilio.Referencia);
                vCmd.Parameters.AddWithValue("@DOMICILIO_COMPLETO", vTb_Domicilio.Domicilio_Completo);
                vCmd.Parameters.AddWithValue("@ID_UBIGEO", vTb_Domicilio.Id_Ubigeo);
                vCmd.Parameters.AddWithValue("@FLG_DOMICILIO_FISCAL", vTb_Domicilio.Flg_Domicilio_Fiscal);
                vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Domicilio.Flg_Activo);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Domicilio.Usu_Modifica);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Domicilio.Fec_Modifica);
                vCmd.Parameters.AddWithValue("@SECCION", vTb_Domicilio.Seccion);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            if (vResp > 0) return vTb_Domicilio; else return null;
        }

        /// <summary>
        /// Elimina un registo de tipo Tb_Domicilio en base a su clave primaria
        /// </summary>
        /// <param name="ID_DOMICILIO">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Domicilio, string vUsuario, DateTime vFecha)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ELIMINAR_DOMICILIO"))
            {
                vCmd.Parameters.AddWithValue("@ID_DOMICILIO", vId_Domicilio);
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
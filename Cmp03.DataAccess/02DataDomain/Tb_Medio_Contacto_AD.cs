/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Medio_Contacto_AD.cs
Objetivo          : Clase referida a los métodos de Acceso a datos de la clase Tb_Medio_Contacto
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
    public partial class Tb_Medio_Contacto_AD : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Medio_Contacto
        /// </summary>
        /// <returns>Listado de Tb_Medio_Contacto</returns>
        public List<Tb_Medio_Contacto> List()
        {
            List<Tb_Medio_Contacto> vLista = new List<Tb_Medio_Contacto>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_MEDIO_CONTACTO"))
            {
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Medio_Contacto(vRdr));
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
        /// Método que recupera un registro de tipo Tb_Medio_Contacto basado en su clave primaria
        /// </summary>
        /// <param name="ID_MEDIO_CONTACTO">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Medio_Contacto GetRegistry(int vId_Medio_Contacto)
        {
            Tb_Medio_Contacto vTb_Medio_Contacto = null;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_OBTENER_MEDIO_CONTACTO"))
            {
                vCmd.Parameters.AddWithValue("@ID_MEDIO_CONTACTO", vId_Medio_Contacto);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        vRdr.Read();
                        vTb_Medio_Contacto = new Tb_Medio_Contacto(vRdr);
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Medio_Contacto;
        }

        /// <summary>
        /// Inserta un Objeto de tipo Tb_Medio_Contacto
        /// </summary>
        /// <param name="Tb_Medio_Contacto">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizados</returns>
        public Tb_Medio_Contacto Insert(Tb_Medio_Contacto vTb_Medio_Contacto)
        {
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_INSERTAR_MEDIO_CONTACTO"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vTb_Medio_Contacto.Id_Persona);
                vCmd.Parameters.AddWithValue("@ID_TIPO_MEDIO_CONTACTO", vTb_Medio_Contacto.Id_Tipo_Medio_Contacto);
                vCmd.Parameters.AddWithValue("@NOMBRE_MEDIO_CONTACTO", vTb_Medio_Contacto.Nombre_Medio_Contacto);
                vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Medio_Contacto.Flg_Activo);
                vCmd.Parameters.AddWithValue("@USU_INGRESO", vTb_Medio_Contacto.Usu_Ingreso);
                vCmd.Parameters.AddWithValue("@FEC_INGRESO", vTb_Medio_Contacto.Fec_Ingreso);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Medio_Contacto.Usu_Modifica);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Medio_Contacto.Fec_Modifica);
                vTb_Medio_Contacto.Id_Medio_Contacto = Convert.ToInt32(vCmd.ExecuteScalar());
                vCmd.Dispose(); AdoNet.Dispose();
            }
            if (vTb_Medio_Contacto.Id_Medio_Contacto > 0) return vTb_Medio_Contacto; else return null;
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Medio_Contacto
        /// </summary>
        /// <param name="Tb_Medio_Contacto">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Medio_Contacto Update(Tb_Medio_Contacto vTb_Medio_Contacto)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ACTUALIZAR_MEDIO_CONTACTO"))
            {
                vCmd.Parameters.AddWithValue("@ID_MEDIO_CONTACTO", vTb_Medio_Contacto.Id_Medio_Contacto);
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vTb_Medio_Contacto.Id_Persona);
                vCmd.Parameters.AddWithValue("@ID_TIPO_MEDIO_CONTACTO", vTb_Medio_Contacto.Id_Tipo_Medio_Contacto);
                vCmd.Parameters.AddWithValue("@NOMBRE_MEDIO_CONTACTO", vTb_Medio_Contacto.Nombre_Medio_Contacto);
                vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Medio_Contacto.Flg_Activo);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Medio_Contacto.Usu_Modifica);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Medio_Contacto.Fec_Modifica);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            if (vResp > 0) return vTb_Medio_Contacto; else return null;
        }

        /// <summary>
        /// Elimina un registo de tipo Tb_Medio_Contacto en base a su clave primaria
        /// </summary>
        /// <param name="ID_MEDIO_CONTACTO">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Medio_Contacto, string vUsuario, DateTime vFecha)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ELIMINAR_MEDIO_CONTACTO"))
            {
                vCmd.Parameters.AddWithValue("@ID_MEDIO_CONTACTO", vId_Medio_Contacto);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vUsuario);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vFecha);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vResp;
        }

        #endregion

        #region Métodos Extendidos

        public List<Tb_Medio_Contacto> List(int vId)
        {
            List<Tb_Medio_Contacto> vLista = new List<Tb_Medio_Contacto>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_MEDIO_CONTACTO"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vId);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Medio_Contacto(vRdr));
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
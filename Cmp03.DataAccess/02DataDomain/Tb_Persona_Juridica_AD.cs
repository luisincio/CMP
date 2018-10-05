/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Persona_Juridica_AD.cs
Objetivo          : Clase referida a los métodos de Acceso a datos de la clase Tb_Persona_Juridica
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
    public partial class Tb_Persona_Juridica_AD : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Persona_Juridica
        /// </summary>
        /// <returns>Listado de Tb_Persona_Juridica</returns>
        public List<Tb_Persona_Juridica> List(int vId_Consejo)
        {
            List<Tb_Persona_Juridica> vLista = new List<Tb_Persona_Juridica>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_PERSONA_JURIDICA"))
            {
                vCmd.Parameters.AddWithValue("@ID_CONSEJO", vId_Consejo);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Persona_Juridica(vRdr));
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
        /// Método que recupera un registro de tipo Tb_Persona_Juridica basado en su clave primaria
        /// </summary>
        /// <param name="ID_PERSONA">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Persona_Juridica GetRegistry(int vId_Persona)
        {
            Tb_Persona_Juridica vTb_Persona_Juridica = null;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_OBTENER_PERSONA_JURIDICA"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vId_Persona);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        vRdr.Read();
                        vTb_Persona_Juridica = new Tb_Persona_Juridica(vRdr);
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Persona_Juridica;
        }

        /// <summary>
        /// Inserta un Objeto de tipo Tb_Persona_Juridica
        /// </summary>
        /// <param name="Tb_Persona_Juridica">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizados</returns>
        public Tb_Persona_Juridica Insert(Tb_Persona_Juridica vTb_Persona_Juridica)
        {
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_INSERTAR_PERSONA_JURIDICA"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vTb_Persona_Juridica.Id_Persona);
                vCmd.Parameters.AddWithValue("@ID_ORIGEN", vTb_Persona_Juridica.Id_Origen_Juridico);
                vCmd.Parameters.AddWithValue("@ID_GRUPO", vTb_Persona_Juridica.Id_Grupo_Juridico);
                vCmd.Parameters.AddWithValue("@ID_CONSEJO", vTb_Persona_Juridica.Id_Consejo_Juridico);
                vCmd.Parameters.AddWithValue("@RAZON_SOCIAL", vTb_Persona_Juridica.Razon_Social);
                vCmd.Parameters.AddWithValue("@DIRECCION", vTb_Persona_Juridica.Direccion);
                vCmd.Parameters.AddWithValue("@ID_UBIGEO", vTb_Persona_Juridica.Id_Ubigeo);
                vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Persona_Juridica.Flg_Activo);
                vCmd.Parameters.AddWithValue("@USU_INGRESO", vTb_Persona_Juridica.Usu_Ingreso);
                vCmd.Parameters.AddWithValue("@FEC_INGRESO", vTb_Persona_Juridica.Fec_Ingreso);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Persona_Juridica.Usu_Modifica);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Persona_Juridica.Fec_Modifica);
                vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Persona_Juridica;
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Persona_Juridica
        /// </summary>
        /// <param name="Tb_Persona_Juridica">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Persona_Juridica Update(Tb_Persona_Juridica vTb_Persona_Juridica)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ACTUALIZAR_PERSONA_JURIDICA"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vTb_Persona_Juridica.Id_Persona);
                vCmd.Parameters.AddWithValue("@ID_ORIGEN", vTb_Persona_Juridica.Id_Origen_Juridico);
                vCmd.Parameters.AddWithValue("@ID_GRUPO", vTb_Persona_Juridica.Id_Grupo_Juridico);
                vCmd.Parameters.AddWithValue("@ID_CONSEJO", vTb_Persona_Juridica.Id_Consejo_Juridico);
                vCmd.Parameters.AddWithValue("@RAZON_SOCIAL", vTb_Persona_Juridica.Razon_Social);
                vCmd.Parameters.AddWithValue("@DIRECCION", vTb_Persona_Juridica.Direccion);
                vCmd.Parameters.AddWithValue("@ID_UBIGEO", vTb_Persona_Juridica.Id_Ubigeo);
                vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Persona_Juridica.Flg_Activo);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Persona_Juridica.Usu_Modifica);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Persona_Juridica.Fec_Modifica);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            if (vResp > 0) return vTb_Persona_Juridica; else return null;
        }

        /// <summary>
        /// Elimina un registo de tipo Tb_Persona_Juridica en base a su clave primaria
        /// </summary>
        /// <param name="ID_PERSONA">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Persona, string vUsuario, DateTime vFecha)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ELIMINAR_PERSONA_JURIDICA"))
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

        /// <summary>
        /// Método que recupera un registro de tipo Tb_Persona_Juridica basado en su clave primaria
        /// </summary>
        /// <param name="ID_PERSONA">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Persona_Juridica GetRegistry(string vRazonSocial = "", string vRuc = "")
        {
            Tb_Persona_Juridica vTb_Persona_Juridica = null;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_OBTENER_PERSONA_JURIDICA_RUC"))
            {
                vCmd.Parameters.AddWithValue("@RUC", vRuc);
                vCmd.Parameters.AddWithValue("@RAZON_SOCIAL", vRazonSocial);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        vRdr.Read();
                        vTb_Persona_Juridica = new Tb_Persona_Juridica(vRdr);
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Persona_Juridica;
        }

        #endregion
    }
}
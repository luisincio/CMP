/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Persona_Imagen_AD.cs
Objetivo          : Clase referida a los métodos de Acceso a datos de la clase Tb_Persona_Imagen
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
    public partial class Tb_Persona_Imagen_AD : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Persona_Imagen
        /// </summary>
        /// <returns>Listado de Tb_Persona_Imagen</returns>
        public List<Tb_Persona_Imagen> List()
        {
            List<Tb_Persona_Imagen> vLista = new List<Tb_Persona_Imagen>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_PERSONA_IMAGEN"))
            {
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Persona_Imagen(vRdr));
                        }
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        /// <summary>
        /// Método que recupera un registro de tipo Tb_Persona_Imagen basado en su clave primaria
        /// </summary>
        /// <param name="ID_PERSONA">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Persona_Imagen GetRegistry(int vId_Persona)
        {
            Tb_Persona_Imagen vTb_Persona_Imagen = null;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_OBTENER_PERSONA_IMAGEN"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vId_Persona);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        vRdr.Read();
                        vTb_Persona_Imagen = new Tb_Persona_Imagen(vRdr);
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Persona_Imagen;
        }

        /// <summary>
        /// Inserta un Objeto de tipo Tb_Persona_Imagen
        /// </summary>
        /// <param name="Tb_Persona_Imagen">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizados</returns>
        public Tb_Persona_Imagen Insert(Tb_Persona_Imagen vTb_Persona_Imagen)
        {
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_INSERTAR_PERSONA_IMAGEN"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vTb_Persona_Imagen.Id_Persona);
                vCmd.Parameters.AddWithValue("@ID_TIPO_IMAGEN", vTb_Persona_Imagen.Id_Tipo_Imagen);
                vCmd.Parameters.AddWithValue("@FOTO", vTb_Persona_Imagen.Foto);
                vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Persona_Imagen;
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Persona_Imagen
        /// </summary>
        /// <param name="Tb_Persona_Imagen">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Persona_Imagen Update(Tb_Persona_Imagen vTb_Persona_Imagen)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ACTUALIZAR_PERSONA_IMAGEN"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vTb_Persona_Imagen.Id_Persona);
                vCmd.Parameters.AddWithValue("@ID_TIPO_IMAGEN", vTb_Persona_Imagen.Id_Tipo_Imagen);
                vCmd.Parameters.AddWithValue("@FOTO", vTb_Persona_Imagen.Foto);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            if (vResp > 0) return vTb_Persona_Imagen; else return null;
        }

        /// <summary>
        /// Elimina un registo de tipo Tb_Persona_Imagen en base a su clave primaria
        /// </summary>
        /// <param name="ID_PERSONA">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Persona, string vUsuario, DateTime vFecha)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ELIMINAR_PERSONA_IMAGEN"))
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

        public Tb_Persona_Imagen GetRegistry(int vId_Persona, int vId_Tipo)
        {
            Tb_Persona_Imagen vTb_Persona_Imagen = null;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_OBTENER_PERSONA_IMAGEN"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vId_Persona);
                vCmd.Parameters.AddWithValue("@ID_TIPO_IMAGEN", vId_Tipo);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        vRdr.Read();
                        vTb_Persona_Imagen = new Tb_Persona_Imagen(vRdr);
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Persona_Imagen;
        }

        public int Delete(int vId_Persona, int vId_Tipo)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ELIMINAR_PERSONA_IMAGEN"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vId_Persona);
                vCmd.Parameters.AddWithValue("@ID_TIPO_IMAGEN", vId_Tipo);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vResp;
        }

        #endregion
    }
}
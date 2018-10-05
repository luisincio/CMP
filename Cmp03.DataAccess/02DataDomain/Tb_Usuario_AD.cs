/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Usuario_AD.cs
Objetivo          : Clase referida a los métodos de Acceso a datos de la clase Tb_Usuario
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
using Cmp01.Utilities;
#endregion

namespace Cmp03.DataAccess
{
    public partial class Tb_Usuario_AD : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Usuario
        /// </summary>
        /// <returns>Listado de Tb_Usuario</returns>
        public List<Tb_Usuario> List()
        {
            List<Tb_Usuario> vLista = new List<Tb_Usuario>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_USUARIO"))
            {
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Usuario(vRdr));
                        }
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        /// <summary>
        /// Método que recupera un registro de tipo Tb_Usuario basado en su clave primaria
        /// </summary>
        /// <param name="ID_USUARIO">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Usuario GetRegistry(int vId_Usuario)
        {
            Tb_Usuario vTb_Usuario = null;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_OBTENER_USUARIO"))
            {
                vCmd.Parameters.AddWithValue("@ID_USUARIO", vId_Usuario);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        vRdr.Read();
                        vTb_Usuario = new Tb_Usuario(vRdr);
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Usuario;
        }

        public Tb_Usuario GetRegistry_Perfil(int vId_Usuario)
        {
            Tb_Usuario vTb_Usuario = null;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_OBTENER_PERFILUSUARIO"))
            {
                vCmd.Parameters.AddWithValue("@ID_USUARIO", vId_Usuario);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        vRdr.Read();
                        vTb_Usuario = new Tb_Usuario(vRdr);
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Usuario;
        }
        /// <summary>
        /// Inserta un Objeto de tipo Tb_Usuario
        /// </summary>
        /// <param name="Tb_Usuario">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizados</returns>
        public Tb_Usuario Insert(Tb_Usuario vTb_Usuario)
        {
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_INSERTAR_USUARIO"))
            {
                vCmd.Parameters.AddWithValue("@ID_USUARIO", vTb_Usuario.Id_Usuario);
                vCmd.Parameters.AddWithValue("@USUARIO", vTb_Usuario.Usuario.ToUpper());
                vCmd.Parameters.AddWithValue("@CONTRASEÑA", vTb_Usuario.Contraseña);
                vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Usuario.Flg_Activo);
                vCmd.Parameters.AddWithValue("@USU_INGRESO", vTb_Usuario.Usu_Ingreso);
                vCmd.Parameters.AddWithValue("@FEC_INGRESO", vTb_Usuario.Fec_Ingreso);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Usuario.Usu_Modifica);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Usuario.Fec_Modifica);
                vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Usuario;
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Usuario
        /// </summary>
        /// <param name="Tb_Usuario">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Usuario Update(Tb_Usuario vTb_Usuario)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ACTUALIZAR_USUARIO"))
            {
                vCmd.Parameters.AddWithValue("@ID_USUARIO", vTb_Usuario.Id_Usuario);
                vCmd.Parameters.AddWithValue("@USUARIO", vTb_Usuario.Usuario.ToUpper());
                vCmd.Parameters.AddWithValue("@CONTRASEÑA", vTb_Usuario.Contraseña);
                vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Usuario.Flg_Activo);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Usuario.Usu_Modifica);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Usuario.Fec_Modifica);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            if (vResp > 0) return vTb_Usuario; else return null;
        }

        /// <summary>
        /// Elimina un registo de tipo Tb_Usuario en base a su clave primaria
        /// </summary>
        /// <param name="ID_USUARIO">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Usuario, string vUsuario, DateTime vFecha)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ELIMINAR_USUARIO"))
            {
                vCmd.Parameters.AddWithValue("@ID_USUARIO", vId_Usuario);
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
        /// Método que lista los registros de Tb_Usuario
        /// </summary>
        /// <returns>Listado de Tb_Usuario</returns>
        public List<Tb_Usuario> List(string vValor)
        {
            List<Tb_Usuario> vLista = new List<Tb_Usuario>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_USUARIO"))
            {
                vCmd.Parameters.AddWithValue("@VALOR", vValor);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Usuario(vRdr));
                        }
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        public Tb_Usuario GetRegistry(string vUsuario, string vClave)
        {
            Tb_Usuario vTb_Usuario = null;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_OBTENER_USUARIO_CLAVE"))
            {
                vCmd.Parameters.AddWithValue("@USUARIO", vUsuario);
                vCmd.Parameters.AddWithValue("@CONTRASEÑA", vClave);
                vCmd.Parameters.AddWithValue("@APLICACION", Variables.Modulo);
                
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        vRdr.Read();
                        vTb_Usuario = new Tb_Usuario(vRdr);
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Usuario;
        }
        #endregion
    }
}
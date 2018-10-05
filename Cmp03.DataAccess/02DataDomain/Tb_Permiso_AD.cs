/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Permiso_AD.cs
Objetivo          : Clase referida a los métodos de Acceso a datos de la clase Tb_Permiso
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
    public partial class Tb_Permiso_AD: Base
    {      
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Permiso
        /// </summary>
        /// <returns>Listado de Tb_Permiso</returns>
        public List<Tb_Permiso> List()
        {
            List<Tb_Permiso> vLista = new List<Tb_Permiso>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_PERMISO"))
            {
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Permiso(vRdr));
                        }
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        /// <summary>
        /// Método que recupera un registro de tipo Tb_Permiso basado en su clave primaria
        /// </summary>
        /// <param name="ID_PERMISO">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Permiso GetRegistry(int vId_Permiso)
        {
            Tb_Permiso vTb_Permiso = null;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_OBTENER_PERMISO"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERMISO", vId_Permiso);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        vRdr.Read();
                        vTb_Permiso = new Tb_Permiso(vRdr);
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Permiso;
        }
        
        /// <summary>
        /// Inserta un Objeto de tipo Tb_Permiso
        /// </summary>
        /// <param name="Tb_Permiso">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizados</returns>
        public Tb_Permiso Insert(Tb_Permiso vTb_Permiso)
        {
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_INSERTAR_PERMISO"))
            {
                vCmd.Parameters.AddWithValue("@ETIQUETA", vTb_Permiso.Etiqueta); 
			vCmd.Parameters.AddWithValue("@ACCION", vTb_Permiso.Accion); 
			vCmd.Parameters.AddWithValue("@CONTROLADORA", vTb_Permiso.Controladora); 
			vCmd.Parameters.AddWithValue("@DESCRIPCION", vTb_Permiso.Descripcion); 
			vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Permiso.Flg_Activo); 
			vCmd.Parameters.AddWithValue("@USU_INGRESO", vTb_Permiso.Usu_Ingreso); 
			vCmd.Parameters.AddWithValue("@FEC_INGRESO", vTb_Permiso.Fec_Ingreso); 
			vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Permiso.Usu_Modifica); 
			vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Permiso.Fec_Modifica);
                vTb_Permiso.Id_Permiso = Convert.ToInt32(vCmd.ExecuteScalar());
                vCmd.Dispose(); AdoNet.Dispose();
            }
            if (vTb_Permiso.Id_Permiso > 0) return vTb_Permiso; else return null;
        }
        
        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Permiso
        /// </summary>
        /// <param name="Tb_Permiso">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Permiso Update(Tb_Permiso vTb_Permiso)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ACTUALIZAR_PERMISO"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERMISO", vTb_Permiso.Id_Permiso); 
			vCmd.Parameters.AddWithValue("@ETIQUETA", vTb_Permiso.Etiqueta); 
			vCmd.Parameters.AddWithValue("@ACCION", vTb_Permiso.Accion); 
			vCmd.Parameters.AddWithValue("@CONTROLADORA", vTb_Permiso.Controladora); 
			vCmd.Parameters.AddWithValue("@DESCRIPCION", vTb_Permiso.Descripcion); 
			vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Permiso.Flg_Activo); 
			vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Permiso.Usu_Modifica); 
			vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Permiso.Fec_Modifica);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            if (vResp > 0) return vTb_Permiso; else return null;
        }
        
        /// <summary>
        /// Elimina un registo de tipo Tb_Permiso en base a su clave primaria
        /// </summary>
        /// <param name="ID_PERMISO">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Permiso, string vUsuario, DateTime vFecha)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ELIMINAR_PERMISO"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERMISO", vId_Permiso);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vUsuario);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vFecha);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vResp;
        }
        
        #endregion
    
        #region Métodos Extendidos
        public List<Tb_Permiso> List(string vValor, int vId_Perfil = 0)
        {
            List<Tb_Permiso> vLista = new List<Tb_Permiso>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_PERMISO"))
            {
                vCmd.Parameters.AddWithValue("@VALOR", vValor);
                vCmd.Parameters.AddWithValue("@ID_PERFIL", vId_Perfil);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Permiso(vRdr));
                        }
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        public List<Tb_Permiso> List(int vId_Usuario)
        {
            List<Tb_Permiso> vLista = new List<Tb_Permiso>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_PERMISOS_PERFIL"))
            {
                vCmd.Parameters.AddWithValue("@ID_USUARIO", vId_Usuario);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Permiso(vRdr));
                        }
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }
        #endregion
    }
}
/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Perfil_AD.cs
Objetivo          : Clase referida a los métodos de Acceso a datos de la clase Tb_Perfil
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
    public partial class Tb_Perfil_AD: Base
    {      
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Perfil
        /// </summary>
        /// <returns>Listado de Tb_Perfil</returns>
        public List<Tb_Perfil> List()
        {
            List<Tb_Perfil> vLista = new List<Tb_Perfil>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_PERFIL"))
            {
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Perfil(vRdr));
                        }
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }
        

        /// <summary>
        /// Método que recupera un registro de tipo Tb_Perfil basado en su clave primaria
        /// </summary>
        /// <param name="ID_PERFIL">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Perfil GetRegistry(int vId_Perfil)
        {
            Tb_Perfil vTb_Perfil = null;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_OBTENER_PERFIL"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERFIL", vId_Perfil);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        vRdr.Read();
                        vTb_Perfil = new Tb_Perfil(vRdr);
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Perfil;
        }
        
        /// <summary>
        /// Inserta un Objeto de tipo Tb_Perfil
        /// </summary>
        /// <param name="Tb_Perfil">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizados</returns>
        public Tb_Perfil Insert(Tb_Perfil vTb_Perfil)
        {
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_INSERTAR_PERFIL"))
            {
                vCmd.Parameters.AddWithValue("@PERFIL", vTb_Perfil.Perfil); 
			vCmd.Parameters.AddWithValue("@DESCRIPCION", vTb_Perfil.Descripcion); 
			vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Perfil.Flg_Activo); 
			vCmd.Parameters.AddWithValue("@USU_INGRESO", vTb_Perfil.Usu_Ingreso); 
			vCmd.Parameters.AddWithValue("@FEC_INGRESO", vTb_Perfil.Fec_Ingreso); 
			vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Perfil.Usu_Modifica); 
			vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Perfil.Fec_Modifica);
                vTb_Perfil.Id_Perfil = Convert.ToInt32(vCmd.ExecuteScalar());
                vCmd.Dispose(); AdoNet.Dispose();
            }
            if (vTb_Perfil.Id_Perfil > 0) return vTb_Perfil; else return null;
        }
        
        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Perfil
        /// </summary>
        /// <param name="Tb_Perfil">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Perfil Update(Tb_Perfil vTb_Perfil)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ACTUALIZAR_PERFIL"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERFIL", vTb_Perfil.Id_Perfil); 
			vCmd.Parameters.AddWithValue("@PERFIL", vTb_Perfil.Perfil); 
			vCmd.Parameters.AddWithValue("@DESCRIPCION", vTb_Perfil.Descripcion); 
			vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Perfil.Flg_Activo); 
			vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Perfil.Usu_Modifica); 
			vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Perfil.Fec_Modifica);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            if (vResp > 0) return vTb_Perfil; else return null;
        }
        
        /// <summary>
        /// Elimina un registo de tipo Tb_Perfil en base a su clave primaria
        /// </summary>
        /// <param name="ID_PERFIL">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Perfil, string vUsuario, DateTime vFecha)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ELIMINAR_PERFIL"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERFIL", vId_Perfil);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vUsuario);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vFecha);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vResp;
        }
        
        #endregion
    
        #region Métodos Extendidos
        public List<Tb_Perfil> List(string vValor)
        {
            List<Tb_Perfil> vLista = new List<Tb_Perfil>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_PERFIL"))
            {
                vCmd.Parameters.AddWithValue("@VALOR", vValor);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Perfil(vRdr));
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
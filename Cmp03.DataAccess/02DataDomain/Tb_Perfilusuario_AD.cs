/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Perfilusuario_AD.cs
Objetivo          : Clase referida a los métodos de Acceso a datos de la clase Tb_Perfilusuario
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
    public partial class Tb_Perfilusuario_AD: Base
    {      
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Perfilusuario
        /// </summary>
        /// <returns>Listado de Tb_Perfilusuario</returns>
        public List<Tb_Perfilusuario> List()
        {
            List<Tb_Perfilusuario> vLista = new List<Tb_Perfilusuario>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_PERFILUSUARIO"))
            {
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Perfilusuario(vRdr));
                        }
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        /// <summary>
        /// Método que recupera un registro de tipo Tb_Perfilusuario basado en su clave primaria
        /// </summary>
        /// <param name="ID_PERFIL">Clave primaria del registro a eliminar</param>/// <param name="ID_USUARIO">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Perfilusuario GetRegistry(int vId_Usuario, int vId_Perfil)
        {
            Tb_Perfilusuario vTb_Perfilusuario = null;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_OBTENER_PERFILUSUARIO"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERFIL", vId_Perfil); 
			vCmd.Parameters.AddWithValue("@ID_USUARIO", vId_Usuario);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        vRdr.Read();
                        vTb_Perfilusuario = new Tb_Perfilusuario(vRdr);
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Perfilusuario;
        }
        
        /// <summary>
        /// Inserta un Objeto de tipo Tb_Perfilusuario
        /// </summary>
        /// <param name="Tb_Perfilusuario">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizados</returns>
        public Tb_Perfilusuario Insert(Tb_Perfilusuario vTb_Perfilusuario)
        {
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_INSERTAR_PERFILUSUARIO"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERFIL", vTb_Perfilusuario.Id_Perfil); 
                vCmd.Parameters.AddWithValue("@ID_USUARIO", vTb_Perfilusuario.Id_Usuario); 
			vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Perfilusuario.Flg_Activo); 
			vCmd.Parameters.AddWithValue("@USU_INGRESO", vTb_Perfilusuario.Usu_Ingreso); 
			vCmd.Parameters.AddWithValue("@FEC_INGRESO", vTb_Perfilusuario.Fec_Ingreso); 
			vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Perfilusuario.Usu_Modifica); 
			vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Perfilusuario.Fec_Modifica);
            vCmd.ExecuteNonQuery();
            vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Perfilusuario;
        }
        
        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Perfilusuario
        /// </summary>
        /// <param name="Tb_Perfilusuario">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Perfilusuario Update(Tb_Perfilusuario vTb_Perfilusuario)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ACTUALIZAR_PERFILUSUARIO"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERFIL", vTb_Perfilusuario.Id_Perfil); 
			vCmd.Parameters.AddWithValue("@ID_USUARIO", vTb_Perfilusuario.Id_Usuario); 
			vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Perfilusuario.Flg_Activo); 
			vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Perfilusuario.Usu_Modifica); 
			vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Perfilusuario.Fec_Modifica);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            if (vResp > 0) return vTb_Perfilusuario; else return null;
        }
        
        /// <summary>
        /// Elimina un registo de tipo Tb_Perfilusuario en base a su clave primaria
        /// </summary>
        /// <param name="ID_PERFIL">Clave primaria del registro a eliminar</param>/// <param name="ID_USUARIO">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Perfil, int vId_Usuario, string vUsuario, DateTime vFecha)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ELIMINAR_PERFILUSUARIO"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERFIL", vId_Perfil); 
			vCmd.Parameters.AddWithValue("@ID_USUARIO", vId_Usuario);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vUsuario);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vFecha);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vResp;
        }

        public Tb_Perfilusuario GetRegistry(int vId)
        {
            throw new NotImplementedException();
        }

        public int Delete(int vId, string vUsuario, DateTime vFecha)
        {
            throw new NotImplementedException();
        }

        #endregion
    
        #region Métodos Extendidos

        #endregion



    }
}
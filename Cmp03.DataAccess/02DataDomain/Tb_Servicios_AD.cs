/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Servicios_AD.cs
Objetivo          : Clase referida a los métodos de Acceso a datos de la clase Tb_Servicios
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
    public partial class Tb_Servicios_AD: Base
    {      
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Servicios
        /// </summary>
        /// <returns>Listado de Tb_Servicios</returns>
        public List<Tb_Servicios> List()
        {
            List<Tb_Servicios> vLista = new List<Tb_Servicios>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_SERVICIOS"))
            {
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Servicios(vRdr));
                        }
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        /// <summary>
        /// Método que recupera un registro de tipo Tb_Servicios basado en su clave primaria
        /// </summary>
        /// <param name="ID_SERVICIO">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Servicios GetRegistry(int vId_Servicio)
        {
            Tb_Servicios vTb_Servicios = null;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_OBTENER_SERVICIOS"))
            {
                vCmd.Parameters.AddWithValue("@ID_SERVICIO", vId_Servicio);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        vRdr.Read();
                        vTb_Servicios = new Tb_Servicios(vRdr);
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Servicios;
        }
        
        /// <summary>
        /// Inserta un Objeto de tipo Tb_Servicios
        /// </summary>
        /// <param name="Tb_Servicios">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizados</returns>
        public Tb_Servicios Insert(Tb_Servicios vTb_Servicios)
        {
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_INSERTAR_SERVICIOS"))
            {
                vCmd.Parameters.AddWithValue("@CODIGO_SERVICIO", vTb_Servicios.Codigo_Servicio); 
			vCmd.Parameters.AddWithValue("@DESCRIPCION", vTb_Servicios.Descripcion); 
			vCmd.Parameters.AddWithValue("@PRECIO", vTb_Servicios.Precio); 
			vCmd.Parameters.AddWithValue("@DESCUENTO", vTb_Servicios.Descuento); 
			vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Servicios.Flg_Activo); 
			vCmd.Parameters.AddWithValue("@USU_INGRESO", vTb_Servicios.Usu_Ingreso); 
			vCmd.Parameters.AddWithValue("@FEC_INGRESO", vTb_Servicios.Fec_Ingreso); 
			vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Servicios.Usu_Modifica); 
			vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Servicios.Fec_Modifica);
                vTb_Servicios.Id_Servicio = Convert.ToInt32(vCmd.ExecuteScalar());
                vCmd.Dispose(); AdoNet.Dispose();
            }
            if (vTb_Servicios.Id_Servicio > 0) return vTb_Servicios; else return null;
        }
        
        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Servicios
        /// </summary>
        /// <param name="Tb_Servicios">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Servicios Update(Tb_Servicios vTb_Servicios)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ACTUALIZAR_SERVICIOS"))
            {
                vCmd.Parameters.AddWithValue("@ID_SERVICIO", vTb_Servicios.Id_Servicio); 
			vCmd.Parameters.AddWithValue("@CODIGO_SERVICIO", vTb_Servicios.Codigo_Servicio); 
			vCmd.Parameters.AddWithValue("@DESCRIPCION", vTb_Servicios.Descripcion); 
			vCmd.Parameters.AddWithValue("@PRECIO", vTb_Servicios.Precio); 
			vCmd.Parameters.AddWithValue("@DESCUENTO", vTb_Servicios.Descuento); 
			vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Servicios.Flg_Activo); 
			vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Servicios.Usu_Modifica); 
			vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Servicios.Fec_Modifica);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            if (vResp > 0) return vTb_Servicios; else return null;
        }
        
        /// <summary>
        /// Elimina un registo de tipo Tb_Servicios en base a su clave primaria
        /// </summary>
        /// <param name="ID_SERVICIO">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Servicio, string vUsuario, DateTime vFecha)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ELIMINAR_SERVICIOS"))
            {
                vCmd.Parameters.AddWithValue("@ID_SERVICIO", vId_Servicio);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vUsuario);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vFecha);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vResp;
        }
        
        #endregion
    
        #region Métodos Extendidos

        public List<Tb_Servicios> List(string vDescripcion)
        {
            List<Tb_Servicios> vLista = new List<Tb_Servicios>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_SERVICIOS"))
            {
                vCmd.Parameters.AddWithValue("@DESCRIPCION", vDescripcion);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Servicios(vRdr));
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
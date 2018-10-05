/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Parametro_AD.cs
Objetivo          : Clase referida a los métodos de Acceso a datos de la clase Tb_Parametro
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
    public partial class Tb_Parametro_AD: Base
    {      
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Parametro
        /// </summary>
        /// <returns>Listado de Tb_Parametro</returns>
        public List<Tb_Parametro> List()
        {
            List<Tb_Parametro> vLista = new List<Tb_Parametro>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_PARAMETRO"))
            {
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Parametro(vRdr));
                        }
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        /// <summary>
        /// Método que recupera un registro de tipo Tb_Parametro basado en su clave primaria
        /// </summary>
        /// <param name="ID_PARAMETRO">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Parametro GetRegistry(int vId_Parametro)
        {
            Tb_Parametro vTb_Parametro = null;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_OBTENER_PARAMETRO"))
            {
                vCmd.Parameters.AddWithValue("@ID_PARAMETRO", vId_Parametro);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        vRdr.Read();
                        vTb_Parametro = new Tb_Parametro(vRdr);
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Parametro;
        }
        
        /// <summary>
        /// Inserta un Objeto de tipo Tb_Parametro
        /// </summary>
        /// <param name="Tb_Parametro">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizados</returns>
        public Tb_Parametro Insert(Tb_Parametro vTb_Parametro)
        {
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_INSERTAR_PARAMETRO"))
            {
                vCmd.Parameters.AddWithValue("@ID_SUCURSAL", 0); 
			vCmd.Parameters.AddWithValue("@DESCRIPCION", vTb_Parametro.Descripcion); 
			vCmd.Parameters.AddWithValue("@VALOR_TEXTO", vTb_Parametro.Valor_Texto); 
			vCmd.Parameters.AddWithValue("@VALOR_NUMERICO", vTb_Parametro.Valor_Numerico); 
			vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Parametro.Flg_Activo); 
			vCmd.Parameters.AddWithValue("@USU_INGRESO", vTb_Parametro.Usu_Ingreso); 
			vCmd.Parameters.AddWithValue("@FEC_INGRESO", vTb_Parametro.Fec_Ingreso); 
			vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Parametro.Usu_Modifica); 
			vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Parametro.Fec_Modifica);
                vTb_Parametro.Id_Parametro = Convert.ToInt32(vCmd.ExecuteScalar());
                vCmd.Dispose(); AdoNet.Dispose();
            }
            if (vTb_Parametro.Id_Parametro > 0) return vTb_Parametro; else return null;
        }
        
        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Parametro
        /// </summary>
        /// <param name="Tb_Parametro">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Parametro Update(Tb_Parametro vTb_Parametro)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ACTUALIZAR_PARAMETRO"))
            {
                vCmd.Parameters.AddWithValue("@ID_PARAMETRO", vTb_Parametro.Id_Parametro); 
			vCmd.Parameters.AddWithValue("@ID_SUCURSAL", vTb_Parametro.Id_Sucursal); 
			vCmd.Parameters.AddWithValue("@DESCRIPCION", vTb_Parametro.Descripcion); 
			vCmd.Parameters.AddWithValue("@VALOR_TEXTO", vTb_Parametro.Valor_Texto); 
			vCmd.Parameters.AddWithValue("@VALOR_NUMERICO", vTb_Parametro.Valor_Numerico); 
			vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Parametro.Flg_Activo); 
			vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Parametro.Usu_Modifica); 
			vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Parametro.Fec_Modifica);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            if (vResp > 0) return vTb_Parametro; else return null;
        }
        
        /// <summary>
        /// Elimina un registo de tipo Tb_Parametro en base a su clave primaria
        /// </summary>
        /// <param name="ID_PARAMETRO">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Parametro, string vUsuario, DateTime vFecha)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ELIMINAR_PARAMETRO"))
            {
                vCmd.Parameters.AddWithValue("@ID_PARAMETRO", vId_Parametro);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vUsuario);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vFecha);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vResp;
        }
        
        #endregion
    
        #region Métodos Extendidos
        public List<Tb_Parametro> List(string vValor)
        {
            List<Tb_Parametro> vLista = new List<Tb_Parametro>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_PARAMETRO"))
            {
                vCmd.Parameters.AddWithValue("@VALOR", vValor);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Parametro(vRdr));
                        }
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        public List<Tb_Maestras> List_Cuotas()
        {
            List<Tb_Maestras> vLista = new List<Tb_Maestras>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_PARAMETRO_CUOTAS"))
            {
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Maestras(vRdr));
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
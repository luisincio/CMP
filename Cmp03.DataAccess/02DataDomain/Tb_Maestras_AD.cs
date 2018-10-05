/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Maestras_AD.cs
Objetivo          : Clase referida a los métodos de Acceso a datos de la clase Tb_Maestras
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
    public partial class Tb_Maestras_AD : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Maestras
        /// </summary>
        /// <returns>Listado de Tb_Maestras</returns>
        public List<Tb_Maestras> List(int vTabla)
        {
            List<Tb_Maestras> vLista = new List<Tb_Maestras>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_MAESTRASITEM"))
            {
                vCmd.Parameters.AddWithValue("@ID_GENERAL", vTabla);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Maestras(vRdr));
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
        /// Método que recupera un registro de tipo Tb_Maestras basado en su clave primaria
        /// </summary>
        /// <param name="ID_MAESTRAS">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Maestras GetRegistry(int vId_Maestras)
        {
            Tb_Maestras vTb_Maestras = null;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_OBTENER_MAESTRAS"))
            {
                vCmd.Parameters.AddWithValue("@ID_MAESTRAS", vId_Maestras);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        vRdr.Read();
                        vTb_Maestras = new Tb_Maestras(vRdr);
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Maestras;
        }

        /// <summary>
        /// Método que recupera un registro de tipo Tb_Maestras basado en su clave primaria
        /// </summary>
        /// <param name="ID_MAESTRAS">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Maestras GetConsejoRegistry(int vId_Consejo)
        {
            Tb_Maestras vTb_Maestras = null;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_OBTENER_CONSEJOREGIONAL"))
            {
                vCmd.Parameters.AddWithValue("@ID_CONSEJO", vId_Consejo);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        vRdr.Read();
                        vTb_Maestras = new Tb_Maestras(vRdr);
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Maestras;
        }

        /// <summary>
        /// Método que recupera un registro de tipo Tb_Maestras basado en su clave primaria
        /// </summary>
        /// <param name="ID_MAESTRAS">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public List<Tb_Maestras> ListConsejo(string usuario)
        {
            List<Tb_Maestras> vLista = new List<Tb_Maestras>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_CONSEJOREGIONAL"))
            {
                vCmd.Parameters.AddWithValue("@USUARIO", usuario);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Maestras(vRdr));
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
        /// Inserta un Objeto de tipo Tb_Maestras
        /// </summary>
        /// <param name="Tb_Maestras">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizados</returns>
        public Tb_Maestras Insert(Tb_Maestras vTb_Maestras)
        {
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_INSERTAR_MAESTRAS"))
            {
                vCmd.Parameters.AddWithValue("@ID_GENERAL", vTb_Maestras.Id_General);
                vCmd.Parameters.AddWithValue("@ID_DETALLE", vTb_Maestras.Id_Detalle);
                vCmd.Parameters.AddWithValue("@DESCRIPCION", vTb_Maestras.Descripcion);
                vCmd.Parameters.AddWithValue("@VALOR1", vTb_Maestras.Valor1);
                vCmd.Parameters.AddWithValue("@VALOR2", vTb_Maestras.Valor2);
                vCmd.Parameters.AddWithValue("@VALOR3", vTb_Maestras.Valor3);
                vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Maestras.Flg_Activo);
                vCmd.Parameters.AddWithValue("@USU_INGRESO", vTb_Maestras.Usu_Ingreso);
                vCmd.Parameters.AddWithValue("@FEC_INGRESO", vTb_Maestras.Fec_Ingreso);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Maestras.Usu_Modifica);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Maestras.Fec_Modifica);
                vTb_Maestras.Id_Maestras = Convert.ToInt32(vCmd.ExecuteScalar());
                vCmd.Dispose(); AdoNet.Dispose();
            }
            if (vTb_Maestras.Id_Maestras > 0) return vTb_Maestras; else return null;
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Maestras
        /// </summary>
        /// <param name="Tb_Maestras">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Maestras Update(Tb_Maestras vTb_Maestras)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ACTUALIZAR_MAESTRAS"))
            {
                vCmd.Parameters.AddWithValue("@ID_MAESTRAS", vTb_Maestras.Id_Maestras);
                vCmd.Parameters.AddWithValue("@ID_GENERAL", vTb_Maestras.Id_General);
                vCmd.Parameters.AddWithValue("@ID_DETALLE", vTb_Maestras.Id_Detalle);
                vCmd.Parameters.AddWithValue("@DESCRIPCION", vTb_Maestras.Descripcion);
                vCmd.Parameters.AddWithValue("@VALOR1", vTb_Maestras.Valor1);
                vCmd.Parameters.AddWithValue("@VALOR2", vTb_Maestras.Valor2);
                vCmd.Parameters.AddWithValue("@VALOR3", vTb_Maestras.Valor3);
                vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Maestras.Flg_Activo);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Maestras.Usu_Modifica);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Maestras.Fec_Modifica);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            if (vResp > 0) return vTb_Maestras; else return null;
        }

        /// <summary>
        /// Elimina un registo de tipo Tb_Maestras en base a su clave primaria
        /// </summary>
        /// <param name="ID_MAESTRAS">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Maestras, string vUsuario, DateTime vFecha)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ELIMINAR_MAESTRAS"))
            {
                vCmd.Parameters.AddWithValue("@ID_MAESTRAS", vId_Maestras);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vUsuario);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vFecha);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vResp;
        }

        #endregion

        #region Métodos Extendidos
        public List<Tb_Maestras> List()
        {
            throw new NotImplementedException();
        }

        public List<Tb_Maestras> Lista(string vValor, int vPadre)
        {
            List<Tb_Maestras> vLista = new List<Tb_Maestras>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_MAESTRA"))
            {
                vCmd.Parameters.AddWithValue("@VALOR", vValor);
                vCmd.Parameters.AddWithValue("@PADRE", vPadre);
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

        public List<Tb_Maestras> ListPeriodo()
        {
            List<Tb_Maestras> vLista = new List<Tb_Maestras>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_PERIODO"))
            {
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Maestras() { Id_Maestras = Convert.ToInt32(vRdr["ID_PERIODO"]), Descripcion = vRdr["PERIODO"].ToString() });
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
/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Correlativos_AD.cs
Objetivo          : Clase referida a los métodos de Acceso a datos de la clase Tb_Correlativos
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
    public partial class Tb_Correlativos_AD : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Correlativos
        /// </summary>
        /// <returns>Listado de Tb_Correlativos</returns>
        public List<Tb_Correlativos> List(int vId_Sucursal, int vId_TipoDocumento, int vSerie, int vId_Persona)
        {
            List<Tb_Correlativos> vLista = new List<Tb_Correlativos>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_CORRELATIVOS"))
            {
                vCmd.Parameters.AddWithValue("@ID_SUCURSAL", vId_Sucursal);
                vCmd.Parameters.AddWithValue("@ID_TIDODOCUMENTO", vId_TipoDocumento);
                vCmd.Parameters.AddWithValue("@SERIE", vSerie);
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vId_Persona);
                
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Correlativos(vRdr));
                        }
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        /// <summary>
        /// Método que recupera un registro de tipo Tb_Correlativos basado en su clave primaria
        /// </summary>
        /// <param name="ID_SUCURSAL">Clave primaria del registro a eliminar</param>/// <param name="ID_TIDODOCUMENTO">Clave primaria del registro a eliminar</param>/// <param name="SERIE">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Correlativos GetRegistry(int vId_Sucursal, int vId_Tidodocumento, int vSerie)
        {
            Tb_Correlativos vTb_Correlativos = null;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_OBTENER_CORRELATIVOS"))
            {
                vCmd.Parameters.AddWithValue("@ID_SUCURSAL", vId_Sucursal);
                vCmd.Parameters.AddWithValue("@ID_TIDODOCUMENTO", vId_Tidodocumento);
                vCmd.Parameters.AddWithValue("@SERIE", vSerie);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        vRdr.Read();
                        vTb_Correlativos = new Tb_Correlativos(vRdr);
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Correlativos;
        }

        /// <summary>
        /// Inserta un Objeto de tipo Tb_Correlativos
        /// </summary>
        /// <param name="Tb_Correlativos">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizados</returns>
        public Tb_Correlativos Insert(Tb_Correlativos vTb_Correlativos)
        {
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_INSERTAR_CORRELATIVOS"))
            {
                vCmd.Parameters.AddWithValue("@ID_SUCURSAL", vTb_Correlativos.Id_Sucursal);
                vCmd.Parameters.AddWithValue("@ID_TIDODOCUMENTO", vTb_Correlativos.Id_Tidodocumento);
                vCmd.Parameters.AddWithValue("@SERIE", vTb_Correlativos.Serie);
                vCmd.Parameters.AddWithValue("@VALOR_ACTUAL", vTb_Correlativos.Valor_Actual);
                vCmd.Parameters.AddWithValue("@INICIO", vTb_Correlativos.Inicio);
                vCmd.Parameters.AddWithValue("@FIN", vTb_Correlativos.Fin);
                vCmd.Parameters.AddWithValue("@USU_INGRESO", vTb_Correlativos.Usu_Ingreso);
                vCmd.Parameters.AddWithValue("@FEC_INGRESO", vTb_Correlativos.Fec_Ingreso);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Correlativos.Usu_Modifica);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Correlativos.Fec_Modifica);
                vCmd.Parameters.AddWithValue("@ID_DOCUMENTO_GP", vTb_Correlativos.Id_Documento_GP);
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vTb_Correlativos.Id_Persona);
                vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            vTb_Correlativos.Opcional = "OK";
            return vTb_Correlativos;
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Correlativos
        /// </summary>
        /// <param name="Tb_Correlativos">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Correlativos Update(Tb_Correlativos vTb_Correlativos)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ACTUALIZAR_CORRELATIVOS"))
            {
                vCmd.Parameters.AddWithValue("@ID_SUCURSAL", vTb_Correlativos.Id_Sucursal);
                vCmd.Parameters.AddWithValue("@ID_TIDODOCUMENTO", vTb_Correlativos.Id_Tidodocumento);
                vCmd.Parameters.AddWithValue("@SERIE", vTb_Correlativos.Serie);
                vCmd.Parameters.AddWithValue("@VALOR_ACTUAL", vTb_Correlativos.Valor_Actual);
                vCmd.Parameters.AddWithValue("@INICIO", vTb_Correlativos.Inicio);
                vCmd.Parameters.AddWithValue("@FIN", vTb_Correlativos.Fin);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Correlativos.Usu_Modifica);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Correlativos.Fec_Modifica);
                vCmd.Parameters.AddWithValue("@ID_DOCUMENTO_GP", vTb_Correlativos.Id_Documento_GP);
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vTb_Correlativos.Id_Persona);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            vTb_Correlativos.Opcional = "OK";
            if (vResp > 0) return vTb_Correlativos; else return null;
        }

        /// <summary>
        /// Elimina un registo de tipo Tb_Correlativos en base a su clave primaria
        /// </summary>
        /// <param name="ID_SUCURSAL">Clave primaria del registro a eliminar</param>/// <param name="ID_TIDODOCUMENTO">Clave primaria del registro a eliminar</param>/// <param name="SERIE">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Sucursal, int vId_Tidodocumento, int vSerie, string vUsuario, DateTime vFecha)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ELIMINAR_CORRELATIVOS"))
            {
                vCmd.Parameters.AddWithValue("@ID_SUCURSAL", vId_Sucursal);
                vCmd.Parameters.AddWithValue("@ID_TIDODOCUMENTO", vId_Tidodocumento);
                vCmd.Parameters.AddWithValue("@SERIE", vSerie);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vUsuario);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vFecha);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vResp;
        }

        public Tb_Correlativos GetRegistry(int vId)
        {
            throw new NotImplementedException();
        }

        public int Delete(int vId, string vUsuario, DateTime vFecha)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Métodos Extendidos

        public string GetNumero(int vId_Sucursal, int vId_Tidodocumento, int vSerie)
        {
            string vNumero = "";
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_OBTENER_CORRELATIVO_ULTIMO"))
            {
                vCmd.Parameters.AddWithValue("@ID_SUCURSAL", vId_Sucursal);
                vCmd.Parameters.AddWithValue("@ID_TIDODOCUMENTO", vId_Tidodocumento);
                vCmd.Parameters.AddWithValue("@SERIE", vSerie);
                vNumero = vCmd.ExecuteScalar().ToString();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vNumero;
        }

        public string GetNumeroEspecialidad(int vId_TipoEspecialidad)
        {
            string vNumero = "";
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_OBTENER_PARAMETRO_ESPECIALIDAD"))
            {
                vCmd.Parameters.AddWithValue("@ID_TIPOESPECIALIDAD", vId_TipoEspecialidad);
                vNumero = vCmd.ExecuteScalar().ToString();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vNumero;
        }

        public List<Tb_Maestras> List_PeriodoCobro()
        {
            List<Tb_Maestras> vLista = new List<Tb_Maestras>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_FECHACOBRANZA"))
            {
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Maestras() { Descripcion = Convert.ToDateTime(vRdr[1]).ToShortDateString(), Valor1 = vRdr[0].ToString() });
                        }
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }

            //vLista.Insert(0, new Tb_Maestras() { Descripcion = null, Valor1 = "TODOS" });
            return vLista;
        }
        #endregion
    }
}
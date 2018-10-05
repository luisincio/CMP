/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Temporal_Planilla_AD.cs
Objetivo          : Clase referida a los métodos de Acceso a datos de la clase Tb_Temporal_Planilla
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
    public partial class Tb_Temporal_Planilla_AD : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Temporal_Planilla
        /// </summary>
        /// <returns>Listado de Tb_Temporal_Planilla</returns>
        public List<Tb_Temporal_Planilla> List(string vNro_Recibo, int vId_Consejo, int vId_EntidadPagadora, int vPagina, int vRegistros)
        {
            List<Tb_Temporal_Planilla> vLista = new List<Tb_Temporal_Planilla>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_TEMPORAL_PLANILLA"))
            {
                vCmd.Parameters.AddWithValue("@NRO_RECIBO", vNro_Recibo);
                vCmd.Parameters.AddWithValue("@ID_CONSEJO", vId_Consejo);
                vCmd.Parameters.AddWithValue("@ID_ENTIDADPAGADORA", vId_EntidadPagadora);
                vCmd.Parameters.AddWithValue("@PAGINA", vPagina);
                vCmd.Parameters.AddWithValue("@REGISTROS", vRegistros);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Temporal_Planilla(vRdr));
                        }
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        /// <summary>
        /// Método que recupera un registro de tipo Tb_Temporal_Planilla basado en su clave primaria
        /// </summary>
        /// <returns>Objeto recuperado</returns>
        public Tb_Temporal_Planilla GetRegistry(string vId_Seguro, string vDni, string vPeriodo)
        {
            Tb_Temporal_Planilla vTb_Temporal_Planilla = null;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_OBTENER_TEMPORAL_PLANILLA"))
            {
                vCmd.Parameters.AddWithValue("@ID_SEGURO", vId_Seguro);
                vCmd.Parameters.AddWithValue("@DNI", vDni);
                vCmd.Parameters.AddWithValue("@PERIODO", vPeriodo);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        vRdr.Read();
                        vTb_Temporal_Planilla = new Tb_Temporal_Planilla(vRdr);
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Temporal_Planilla;
        }

        /// <summary>
        /// Inserta un Objeto de tipo Tb_Temporal_Planilla
        /// </summary>
        /// <param name="Tb_Temporal_Planilla">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizados</returns>
        public Tb_Temporal_Planilla Insert(Tb_Temporal_Planilla vTb_Temporal_Planilla)
        {
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_INSERTAR_TEMPORAL_PLANILLA"))
            {
                vCmd.Parameters.AddWithValue("@ID_SEGURO", vTb_Temporal_Planilla.Id_Seguro);
                vCmd.Parameters.AddWithValue("@NRO_RECIBO", vTb_Temporal_Planilla.Nro_Recibo);
                vCmd.Parameters.AddWithValue("@ID_CONSEJO", vTb_Temporal_Planilla.Id_Consejo);
                vCmd.Parameters.AddWithValue("@ID_ENTIDADPAGADORA", vTb_Temporal_Planilla.Id_EntidadPagadora);
                vCmd.Parameters.AddWithValue("@ID_COLEGIADO", vTb_Temporal_Planilla.Id_Colegiado);
                vCmd.Parameters.AddWithValue("@DNI", vTb_Temporal_Planilla.Dni);
                vCmd.Parameters.AddWithValue("@NOMBRE_COMPLETO", vTb_Temporal_Planilla.Nombre_Completo);
                vCmd.Parameters.AddWithValue("@MOVIMIENTO", vTb_Temporal_Planilla.Movimiento);
                vCmd.Parameters.AddWithValue("@IMPORTE", vTb_Temporal_Planilla.Importe);
                vCmd.Parameters.AddWithValue("@PERIODO", vTb_Temporal_Planilla.Periodo);
                vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Temporal_Planilla.Flg_Activo);
                vCmd.Parameters.AddWithValue("@USU_INGRESO", vTb_Temporal_Planilla.Usu_Ingreso);
                vCmd.Parameters.AddWithValue("@FEC_INGRESO", vTb_Temporal_Planilla.Fec_Ingreso);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Temporal_Planilla.Usu_Modifica);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Temporal_Planilla.Fec_Modifica);
                vCmd.Parameters.AddWithValue("@TIPO", vTb_Temporal_Planilla.Tipo);
                vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Temporal_Planilla;
        }

        /// <summary>
        /// Elimina un registo de tipo Tb_Temporal_Planilla en base a su clave primaria
        /// </summary>

        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(string vId_Seguro, int vId_Consejo, int vId_Entidad, string vDni, string vPeriodo)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ELIMINAR_TEMPORAL_PLANILLA"))
            {
                vCmd.Parameters.AddWithValue("@ID_SEGURO", vId_Seguro);
                vCmd.Parameters.AddWithValue("@ID_CONSEJO", vId_Consejo);
                vCmd.Parameters.AddWithValue("@ID_ENTIDADPAGADORA", vId_Entidad);
                vCmd.Parameters.AddWithValue("@DNI", vDni);
                vCmd.Parameters.AddWithValue("@PERIODO", vPeriodo);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vResp;
        }

        public Tb_Temporal_Planilla Update(Tb_Temporal_Planilla vTb_Temporal_Planilla)
        {
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ACTUALIZAR_TEMPORAL_PLANILLA"))
            {
                vCmd.Parameters.AddWithValue("@ID_SEGURO", vTb_Temporal_Planilla.Id_Seguro);
                vCmd.Parameters.AddWithValue("@NRO_RECIBO", vTb_Temporal_Planilla.Nro_Recibo);
                vCmd.Parameters.AddWithValue("@ID_CONSEJO", vTb_Temporal_Planilla.Id_Consejo);
                vCmd.Parameters.AddWithValue("@ID_ENTIDADPAGADORA", vTb_Temporal_Planilla.Id_EntidadPagadora);
                vCmd.Parameters.AddWithValue("@ID_COLEGIADO", vTb_Temporal_Planilla.Id_Colegiado);
                vCmd.Parameters.AddWithValue("@DNI", vTb_Temporal_Planilla.Dni);
                vCmd.Parameters.AddWithValue("@NOMBRE_COMPLETO", vTb_Temporal_Planilla.Nombre_Completo);
                vCmd.Parameters.AddWithValue("@MOVIMIENTO", vTb_Temporal_Planilla.Movimiento);
                vCmd.Parameters.AddWithValue("@IMPORTE", vTb_Temporal_Planilla.Importe);
                vCmd.Parameters.AddWithValue("@PERIODO", vTb_Temporal_Planilla.Periodo);
                vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Temporal_Planilla.Flg_Activo);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Temporal_Planilla.Usu_Modifica);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Temporal_Planilla.Fec_Modifica);
                vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Temporal_Planilla;
        }

        #endregion

        #region Métodos Extendidos

        #endregion
    }
}
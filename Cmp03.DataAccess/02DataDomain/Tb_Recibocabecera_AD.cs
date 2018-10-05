/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Comprobantecabecera_AD.cs
Objetivo          : Clase referida a los métodos de Acceso a datos de la clase Tb_Comprobantecabecera
Autor             : CMP-SISTEMAS (FRR)
Fecha Creación    : 05/07/2017
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
    public partial class Tb_Recibocabecera_AD : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Comprobantecabecera
        /// </summary>
        /// <returns>Listado de Tb_Comprobantecabecera</returns>
        public List<Tb_Comprobantecabecera> List()
        {
            List<Tb_Comprobantecabecera> vLista = new List<Tb_Comprobantecabecera>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_RECIBOCABECERA"))
            {
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Comprobantecabecera(vRdr));
                        }
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        /// <summary>
        /// Método que recupera un registro de tipo Tb_Comprobantecabecera basado en su clave primaria
        /// </summary>
        /// <param name="ID_COMPROBANTE">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Comprobantecabecera GetRegistry(int vId_Comprobante)
        {
            Tb_Comprobantecabecera vTb_Comprobantecabecera = null;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_OBTENER_RECIBOCABECERA"))
            {
                vCmd.Parameters.AddWithValue("@ID_COMPROBANTE", vId_Comprobante);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        vRdr.Read();
                        vTb_Comprobantecabecera = new Tb_Comprobantecabecera(vRdr);
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Comprobantecabecera;
        }

        /// <summary>
        /// Inserta un Objeto de tipo Tb_Comprobantecabecera
        /// </summary>
        /// <param name="Tb_Comprobantecabecera">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizados</returns>
        public Tb_Comprobantecabecera Insert(Tb_Comprobantecabecera vTb_Comprobantecabecera)
        {
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_INSERTAR_RECIBOCABECERA"))
            {
                vCmd.Parameters.AddWithValue("@ID_TIPO_DOCUMENTOSUNAT", vTb_Comprobantecabecera.Tipo_Documentosunat);
                vCmd.Parameters.AddWithValue("@SERIE", vTb_Comprobantecabecera.Serie);
                vCmd.Parameters.AddWithValue("@NRO_DOCUMENTO", vTb_Comprobantecabecera.Nro_Documento);
                vCmd.Parameters.AddWithValue("@NRODOCUMENTO_GP", vTb_Comprobantecabecera.Nrodocumento_Gp);
                vCmd.Parameters.AddWithValue("@ID_CLIENTEPAGADOR", vTb_Comprobantecabecera.Id_Clientepagador);
                vCmd.Parameters.AddWithValue("@RAZONSOCIAL", vTb_Comprobantecabecera.Razonsocial);
                vCmd.Parameters.AddWithValue("@DIRECCIÓN", vTb_Comprobantecabecera.Direccion);
                vCmd.Parameters.AddWithValue("@ID_MONEDA", vTb_Comprobantecabecera.Id_Moneda);
                vCmd.Parameters.AddWithValue("@ID_TIPO_PAGO", vTb_Comprobantecabecera.Id_Tipo_Pago);
                vCmd.Parameters.AddWithValue("@ID_SITIO_DESTINO", vTb_Comprobantecabecera.Id_Sitio_Destino);
                vCmd.Parameters.AddWithValue("@ID_SITIO_ORIGEN", vTb_Comprobantecabecera.Id_Sitio_Origen);
                vCmd.Parameters.AddWithValue("@FECHA_RECIBO", vTb_Comprobantecabecera.Fecha);
                vCmd.Parameters.AddWithValue("@NRO_CHEQUE", vTb_Comprobantecabecera.Nro_Cheque);
                vCmd.Parameters.AddWithValue("@FECHA_VENCIMIENTO", vTb_Comprobantecabecera.Fecha_Vencimiento);
                vCmd.Parameters.AddWithValue("@CTA_CONTABLE", vTb_Comprobantecabecera.Cta_Contable);
                vCmd.Parameters.AddWithValue("@OBSERVACION", vTb_Comprobantecabecera.Observacion);
                vCmd.Parameters.AddWithValue("@MONTO", vTb_Comprobantecabecera.Monto);
                vCmd.Parameters.AddWithValue("@IGV", vTb_Comprobantecabecera.Igv);
                vCmd.Parameters.AddWithValue("@DESCUENTO", vTb_Comprobantecabecera.Descuento);
                vCmd.Parameters.AddWithValue("@TOTAL", vTb_Comprobantecabecera.Total);
                vCmd.Parameters.AddWithValue("@EQUIPO", vTb_Comprobantecabecera.Equipo);
                vCmd.Parameters.AddWithValue("@ID_ESTADO_RECIBO", vTb_Comprobantecabecera.Id_EstadoComprobante);
                vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Comprobantecabecera.Flg_Activo);
                vCmd.Parameters.AddWithValue("@USU_INGRESO", vTb_Comprobantecabecera.Usu_Ingreso);
                vCmd.Parameters.AddWithValue("@FEC_INGRESO", vTb_Comprobantecabecera.Fec_Ingreso);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Comprobantecabecera.Usu_Modifica);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Comprobantecabecera.Fec_Modifica);
                vCmd.Parameters.AddWithValue("@ID_CONDICIONPAGO", vTb_Comprobantecabecera.Id_CondicionPago);
                vTb_Comprobantecabecera.Id_Comprobante = Convert.ToInt32(vCmd.ExecuteScalar());
                vCmd.Dispose(); AdoNet.Dispose();
            }
            if (vTb_Comprobantecabecera.Id_Comprobante > 0) return vTb_Comprobantecabecera; else return null;
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Comprobantecabecera
        /// </summary>
        /// <param name="Tb_Comprobantecabecera">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Comprobantecabecera Update(Tb_Comprobantecabecera vTb_Comprobantecabecera)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ACTUALIZAR_RECIBOCABECERA"))
            {
                vCmd.Parameters.AddWithValue("@ID_COMPROBANTE", vTb_Comprobantecabecera.Id_Comprobante);
                vCmd.Parameters.AddWithValue("@ID_TIPO_DOCUMENTOSUNAT", vTb_Comprobantecabecera.Tipo_Documentosunat);
                vCmd.Parameters.AddWithValue("@SERIE", vTb_Comprobantecabecera.Serie);
                vCmd.Parameters.AddWithValue("@NRO_DOCUMENTO", vTb_Comprobantecabecera.Nro_Documento);
                vCmd.Parameters.AddWithValue("@NRODOCUMENTO_GP", vTb_Comprobantecabecera.Nrodocumento_Gp);
                vCmd.Parameters.AddWithValue("@ID_CLIENTEPAGADOR", vTb_Comprobantecabecera.Id_Clientepagador);
                vCmd.Parameters.AddWithValue("@RAZONSOCIAL", vTb_Comprobantecabecera.Razonsocial);
                vCmd.Parameters.AddWithValue("@DIRECCIÓN", vTb_Comprobantecabecera.Direccion);
                vCmd.Parameters.AddWithValue("@ID_MONEDA", vTb_Comprobantecabecera.Id_Moneda);
                vCmd.Parameters.AddWithValue("@ID_TIPO_PAGO", vTb_Comprobantecabecera.Id_Tipo_Pago);
                vCmd.Parameters.AddWithValue("@ID_SITIO_DESTINO", vTb_Comprobantecabecera.Id_Sitio_Destino);
                vCmd.Parameters.AddWithValue("@ID_SITIO_ORIGEN", vTb_Comprobantecabecera.Id_Sitio_Origen);
                vCmd.Parameters.AddWithValue("@FECHA_RECIBO", vTb_Comprobantecabecera.Fecha);
                vCmd.Parameters.AddWithValue("@NRO_CHEQUE", vTb_Comprobantecabecera.Nro_Cheque);
                vCmd.Parameters.AddWithValue("@FECHA_VENCIMIENTO", vTb_Comprobantecabecera.Fecha_Vencimiento);
                vCmd.Parameters.AddWithValue("@CTA_CONTABLE", vTb_Comprobantecabecera.Cta_Contable);
                vCmd.Parameters.AddWithValue("@OBSERVACION", vTb_Comprobantecabecera.Observacion);
                vCmd.Parameters.AddWithValue("@MONTO", vTb_Comprobantecabecera.Monto);
                vCmd.Parameters.AddWithValue("@IGV", vTb_Comprobantecabecera.Igv);
                vCmd.Parameters.AddWithValue("@DESCUENTO", vTb_Comprobantecabecera.Descuento);
                vCmd.Parameters.AddWithValue("@TOTAL", vTb_Comprobantecabecera.Total);
                vCmd.Parameters.AddWithValue("@EQUIPO", vTb_Comprobantecabecera.Equipo);
                vCmd.Parameters.AddWithValue("@ID_ESTADO_RECIBO", vTb_Comprobantecabecera.Id_EstadoComprobante);
                vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Comprobantecabecera.Flg_Activo);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Comprobantecabecera.Usu_Modifica);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Comprobantecabecera.Fec_Modifica);
                vCmd.Parameters.AddWithValue("@ID_CONDICIONPAGO", vTb_Comprobantecabecera.Id_CondicionPago);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            if (vResp > 0) return vTb_Comprobantecabecera; else return null;
        }

        /// <summary>
        /// Elimina un registo de tipo Tb_Comprobantecabecera en base a su clave primaria
        /// </summary>
        /// <param name="ID_COMPROBANTE">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Comprobante, string vUsuario, DateTime vFecha)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ELIMINAR_RECIBOCABECERA"))
            {
                vCmd.Parameters.AddWithValue("@ID_COMPROBANTE", vId_Comprobante);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vUsuario);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vFecha);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vResp;
        }

        public int Actualizar_Montos(int vId_Comprobante)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ACTUALIZAR_RECIBOCABECERA_MONTOS"))
            {
                vCmd.Parameters.AddWithValue("@ID_COMPROBANTE", vId_Comprobante);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vResp;
        }

        public Tb_Comprobantecabecera GetRegistry_Nro(string nNroRecibo)
        {
            Tb_Comprobantecabecera vTb_Comprobantecabecera = null;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_OBTENER_RECIBOCABECERA_NRO"))
            {
                vCmd.Parameters.AddWithValue("@NRODOCUMENTO_GP", nNroRecibo);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        vRdr.Read();
                        vTb_Comprobantecabecera = new Tb_Comprobantecabecera(vRdr);
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Comprobantecabecera;
        }

        #endregion

        #region Métodos Extendidos

        #endregion
    }
}
/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Recepcion_AD.cs
Objetivo          : Clase referida a los métodos de Acceso a datos de la clase de GP
Autor             : CMP-SISTEMAS (FRR)
Fecha Creación    : 09/06/2018
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
    public partial class Factura_AD : Base
    {
        #region Métodos Públicos Generales

        public int Grabar(Factura Factura,int Id_Comprobante)
        {
            int vRst = 0;
            using (var txscope = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew))
            {
                try
                {
                    using (SqlConnection objConn = new SqlConnection(Cmp01.Utilities.Variables.CnnGP))
                    {
                        objConn.Open();

                        SqlCommand vCmd2 = new SqlCommand("DIN_SP_INSERTAR_CABECERA_WS", objConn);
                        vCmd2.CommandTimeout = 0;
                        vCmd2.CommandType = CommandType.StoredProcedure;
                        vCmd2.Parameters.AddWithValue("@TipoDocumento", Factura.Cabecera.TipoDocumento);
                        vCmd2.Parameters.AddWithValue("@IdDocumento", Factura.Cabecera.IdDocumento);
                        vCmd2.Parameters.AddWithValue("@NumeroDocumento", Factura.Cabecera.NumeroDocumento);
                        vCmd2.Parameters.AddWithValue("@IdCliente", Factura.Cabecera.IdCliente);
                        vCmd2.Parameters.AddWithValue("@IdCondicionPago", Factura.Cabecera.IdCondicionPago);
                        //vCmd2.Parameters.AddWithValue("@FechaEmision", Factura.Cabecera.FechaEmision);
                        //vCmd2.Parameters.AddWithValue("@FechaEnvio", Factura.Cabecera.FechaEnvio);
                        vCmd2.Parameters.AddWithValue("@vFechaEmision", Factura.Cabecera.FechaEmision.Day.ToString() + '/' + Factura.Cabecera.FechaEmision.Month.ToString("00") + "/" + Factura.Cabecera.FechaEmision.Year.ToString() + " " + Factura.Cabecera.FechaEmision.Hour.ToString("00") + ":" + Factura.Cabecera.FechaEmision.Minute.ToString("00") + ":" + Factura.Cabecera.FechaEmision.Second.ToString("00"));
                        vCmd2.Parameters.AddWithValue("@vFechaEnvio", Factura.Cabecera.FechaEnvio.Day.ToString() + '/' + Factura.Cabecera.FechaEnvio.Month.ToString("00") + "/" + Factura.Cabecera.FechaEnvio.Year.ToString() + " " + Factura.Cabecera.FechaEnvio.Hour.ToString("00") + ":" + Factura.Cabecera.FechaEnvio.Minute.ToString("00") + ":" + Factura.Cabecera.FechaEnvio.Second.ToString("00"));
                        //OMARCITOFULL: MODIFICADO
                        vCmd2.Parameters.AddWithValue("@IdSitio", Factura.Cabecera.IdSitio);
                        //vCmd2.Parameters.AddWithValue("@IdSitio", Factura.Cabecera.IdSitio);
                        vCmd2.Parameters.AddWithValue("@IdMoneda", Factura.Cabecera.IdMoneda);
                        vCmd2.Parameters.AddWithValue("@IdVendedor", Factura.Cabecera.IdVendedor);
                        vCmd2.Parameters.AddWithValue("@IdTerritorio", "");
                        vCmd2.Parameters.AddWithValue("@NumOCCliente", Factura.Cabecera.NumOCCliente);
                        vCmd2.Parameters.AddWithValue("@NroGuia", Factura.Cabecera.NroGuia);
                        vCmd2.Parameters.AddWithValue("@USER2ENT", Factura.Cabecera.Usuario);
                        vCmd2.Parameters.AddWithValue("@IdLote", Factura.Cabecera.IdLote);
                        vCmd2.Parameters.AddWithValue("@Reference", Factura.Cabecera.Reference);
                        vCmd2.Parameters.AddWithValue("@Consejo", Factura.Cabecera.IdSitio);
                        vRst = Convert.ToInt32(vCmd2.ExecuteScalar());

                        if (vRst == 0)
                        {
                            foreach (var vOc_Detalle in Factura.Detalle)
                            {
                                SqlCommand vCmd1 = new SqlCommand("DIN_SP_INSERTAR_DETALLE_WS", objConn);
                                vCmd1.CommandTimeout = 0;
                                
                                vCmd1.CommandType = CommandType.StoredProcedure;
                                vCmd1.Parameters.AddWithValue("@TipoDocumento", vOc_Detalle.TipoDocumento);
                                vCmd1.Parameters.AddWithValue("@NumeroDocumento", vOc_Detalle.NumeroDocumento);
                                vCmd1.Parameters.AddWithValue("@IdCliente", vOc_Detalle.IdCliente);
                                //vCmd1.Parameters.AddWithValue("@Fecha", vOc_Detalle.Fecha );
                                vCmd1.Parameters.AddWithValue("@Fechax", vOc_Detalle.Fecha.Day.ToString() + '/' + vOc_Detalle.Fecha.Month.ToString("00") + "/" + vOc_Detalle.Fecha.Year.ToString() + " " + vOc_Detalle.Fecha.Hour.ToString("00") + ":" + vOc_Detalle.Fecha.Minute.ToString("00") + ":" + vOc_Detalle.Fecha.Second.ToString("00"));
                                //OMARCITOFULL: MODIFICADO
                                vCmd1.Parameters.AddWithValue("@IdSitio", vOc_Detalle.IdSitio.Substring(vOc_Detalle.IdSitio.Length - 2, 2));
                                //vCmd1.Parameters.AddWithValue("@IdSitio", vOc_Detalle.IdSitio);
                                vCmd1.Parameters.AddWithValue("@LNITMSEQ", vOc_Detalle.Secuencia);
                                vCmd1.Parameters.AddWithValue("@NumArticulo", vOc_Detalle.NumArticulo);
                                vCmd1.Parameters.AddWithValue("@PrecioUnitario", vOc_Detalle.PrecioUnitario);
                                vCmd1.Parameters.AddWithValue("@Cantidad", vOc_Detalle.Cantidad);
                                vCmd1.Parameters.AddWithValue("@DesArticulo", vOc_Detalle.DesArticulo);
                                vCmd1.Parameters.AddWithValue("@UnidadMedida", vOc_Detalle.UnidadMedida);
                                vCmd1.Parameters.AddWithValue("@NumeroTelefono", vOc_Detalle.NumeroTelefono);
                                vCmd1.Parameters.AddWithValue("@SerLotProducto", vOc_Detalle.SerLotProducto);
                                vCmd1.Parameters.AddWithValue("@Moneda", vOc_Detalle.Moneda);
                                vCmd1.Parameters.AddWithValue("@Descuento", vOc_Detalle.Descuento);

                                vRst = vRst + Convert.ToInt32(vCmd1.ExecuteScalar());
                                if (vRst > 0) break;
                                
                            }
                            if (vRst == 0)
                            {
                                using (SqlConnection objConnOP = new SqlConnection(Cmp01.Utilities.Variables.CnnString))
                                {
                                    //objConnOP.Open();
                                    SqlCommand vCmd9 = new SqlCommand(objConnOP.Database+".DBO.[DIN_SP_COMPROBANTEDETALLE_INSERT_ESTADOCUENTA]", objConn);
                                    vCmd9.CommandTimeout = 0;
                                    vCmd9.CommandType = CommandType.StoredProcedure;
                                    vCmd9.Parameters.AddWithValue("@ID_COMPROBANTE", Id_Comprobante);
                                    vRst = vRst + Convert.ToInt32(vCmd9.ExecuteScalar());
                                    objConnOP.Close();
                                }
                            }
                            if (vRst == 0)
                            {
                                SqlCommand vCmd4 = new SqlCommand("DIN_SP_INSERTAR_CABECERA_WS", objConn);
                                vCmd4.CommandTimeout = 0;
                                vCmd4.CommandType = CommandType.StoredProcedure;
                                vCmd4.Parameters.AddWithValue("@TipoDocumento", Factura.Cabecera.TipoDocumento);
                                vCmd4.Parameters.AddWithValue("@IdDocumento", Factura.Cabecera.IdDocumento);
                                vCmd4.Parameters.AddWithValue("@NumeroDocumento", Factura.Cabecera.NumeroDocumento);
                                vCmd4.Parameters.AddWithValue("@IdCliente", Factura.Cabecera.IdCliente);
                                vCmd4.Parameters.AddWithValue("@IdCondicionPago", Factura.Cabecera.IdCondicionPago);
                                //vCmd2.Parameters.AddWithValue("@FechaEmision", Factura.Cabecera.FechaEmision);
                                //vCmd2.Parameters.AddWithValue("@FechaEnvio", Factura.Cabecera.FechaEnvio);
                                vCmd4.Parameters.AddWithValue("@vFechaEmision", Factura.Cabecera.FechaEmision.Day.ToString() + '/' + Factura.Cabecera.FechaEmision.Month.ToString("00") + "/" + Factura.Cabecera.FechaEmision.Year.ToString() + " " + Factura.Cabecera.FechaEmision.Hour.ToString("00") + ":" + Factura.Cabecera.FechaEmision.Minute.ToString("00") + ":" + Factura.Cabecera.FechaEmision.Second.ToString("00"));
                                vCmd4.Parameters.AddWithValue("@vFechaEnvio", Factura.Cabecera.FechaEnvio.Day.ToString() + '/' + Factura.Cabecera.FechaEnvio.Month.ToString("00") + "/" + Factura.Cabecera.FechaEnvio.Year.ToString() + " " + Factura.Cabecera.FechaEnvio.Hour.ToString("00") + ":" + Factura.Cabecera.FechaEnvio.Minute.ToString("00") + ":" + Factura.Cabecera.FechaEnvio.Second.ToString("00"));
                                //OMARCITOFULL: MODIFICADO
                                vCmd4.Parameters.AddWithValue("@IdSitio", Factura.Cabecera.IdSitio.Substring(Factura.Cabecera.IdSitio.Length - 2, 2));
                                //vCmd2.Parameters.AddWithValue("@IdSitio", Factura.Cabecera.IdSitio);
                                vCmd4.Parameters.AddWithValue("@IdMoneda", Factura.Cabecera.IdMoneda);
                                vCmd4.Parameters.AddWithValue("@IdVendedor", Factura.Cabecera.IdVendedor);
                                vCmd4.Parameters.AddWithValue("@IdTerritorio", "");
                                vCmd4.Parameters.AddWithValue("@NumOCCliente", Factura.Cabecera.NumOCCliente);
                                vCmd4.Parameters.AddWithValue("@NroGuia", Factura.Cabecera.NroGuia);
                                vCmd4.Parameters.AddWithValue("@USER2ENT", Factura.Cabecera.Usuario);
                                vCmd4.Parameters.AddWithValue("@IdLote", Factura.Cabecera.IdLote);
                                vCmd4.Parameters.AddWithValue("@Reference", Factura.Cabecera.Reference);
                                vCmd4.Parameters.AddWithValue("@Consejo", Factura.Cabecera.IdSitio);
                                vRst = Convert.ToInt32(vCmd4.ExecuteScalar());
                            }

                            if (vRst == 0)
                            {
                                //if (Factura.Cobranza.TipoPAgo != EnumTipoPago.OTROS.ToString())
                                if (Factura.Cabecera.IdCondicionPago == Variables.Contado && (Factura.Cabecera.TipoDocumento==(int)EnumTipoDocSunat.FACTURA || Factura.Cabecera.TipoDocumento == (int)EnumTipoDocSunat.BOLETA))
                                {
                                    SqlCommand vCmd3 = new SqlCommand("DIN_SP_INSERTAR_COBRANZA", objConn);
                                    vCmd3.CommandTimeout = 0;
                                    vCmd3.CommandType = CommandType.StoredProcedure;
                                    vCmd3.Parameters.AddWithValue("@TipoDocumento", Factura.Cobranza.TipoDocumento);
                                    vCmd3.Parameters.AddWithValue("@IdDocumento", Factura.Cobranza.IdDocumento);
                                    vCmd3.Parameters.AddWithValue("@NumeroDocumento", Factura.Cobranza.NumeroDocumento);
                                    //OMARCITOFULL: MODIFICADO
                                    //vCmd3.Parameters.AddWithValue("@idSitio", Factura.Cobranza.IdSitio.Substring(Factura.Cobranza.IdSitio.Length - 2, 2));
                                    vCmd3.Parameters.AddWithValue("@idSitio", Factura.Cobranza.IdSitio);
                                    vCmd3.Parameters.AddWithValue("@TipoPAgo", Factura.Cobranza.TipoPAgo);
                                    vCmd3.Parameters.AddWithValue("@IdCliente", Factura.Cobranza.IdCliente);
                                    //vCmd3.Parameters.AddWithValue("@FechaEmision", Factura.Cobranza.FechaEmision);
                                    vCmd3.Parameters.AddWithValue("@FechaEmisionX", Factura.Cobranza.FechaEmision.Day.ToString() + '/' + Factura.Cobranza.FechaEmision.Month.ToString("00") + "/" + Factura.Cobranza.FechaEmision.Year.ToString() + " " + Factura.Cobranza.FechaEmision.Hour.ToString("00") + ":" + Factura.Cobranza.FechaEmision.Minute.ToString("00") + ":" + Factura.Cobranza.FechaEmision.Second.ToString("00"));
                                    vCmd3.Parameters.AddWithValue("@DocAmount", Factura.Cobranza.Monto);
                                    vCmd3.Parameters.AddWithValue("@NroOperacion", Factura.Cobranza.NroOperacion);
                                    vCmd3.Parameters.AddWithValue("@IdChequera", Factura.Cobranza.Chequera);
                                    vRst = Convert.ToInt32(vCmd3.ExecuteScalar());
                                }
                                if (vRst == 0)
                                {
                                    txscope.Complete();
                                    objConn.Close();
                                    return 1;
                                }
                            }
                        }
                        txscope.Dispose();
                        return vRst;
                    }
                }
                catch (Exception Err)
                {
                    txscope.Dispose();
                    vRst = 999999;
                    return vRst;
                }
            }
        }


        public string InsertOtrasCobranzas(OtraCobranza vOtrosCobranza)
        {
            string vRst = "";
            using (var txscope = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew))
            {
                try
                {
                    using (SqlConnection vCnn = new SqlConnection(Cmp01.Utilities.Variables.CnnGP))
                    {
                        vCnn.Open();
                        SqlCommand vCmd2 = new SqlCommand("usp_SS_RMCashReceiptInsert", vCnn);
                        vCmd2.CommandType = CommandType.StoredProcedure;
                        vCmd2.Parameters.AddWithValue("@IdLote", vOtrosCobranza.IdLote);
                        vCmd2.Parameters.AddWithValue("@Fecha", vOtrosCobranza.Fecha);
                        vCmd2.Parameters.AddWithValue("@IdCliente", vOtrosCobranza.IdCliente);
                        vCmd2.Parameters.AddWithValue("@Monto", vOtrosCobranza.Monto);
                        vCmd2.Parameters.AddWithValue("@IdMoneda", vOtrosCobranza.IdMoneda);
                        vCmd2.Parameters.AddWithValue("@Tipo", vOtrosCobranza.Tipo);
                        vCmd2.Parameters.AddWithValue("@IdChequera", vOtrosCobranza.IdChequera);
                        vCmd2.Parameters.AddWithValue("@NumChequeTarjeta", vOtrosCobranza.NumChequeTarjeta);
                        vCmd2.Parameters.AddWithValue("@IdTarjetaCredito", vOtrosCobranza.IdTarjetaCredito);
                        vCmd2.Parameters.AddWithValue("@TipoPagoSunat", vOtrosCobranza.TipoPagoSunat);
                        vCmd2.Parameters.AddWithValue("@Comentario", vOtrosCobranza.Comentario);
                        vCmd2.Parameters.AddWithValue("@NumeroFacturaVenta", vOtrosCobranza.NumeroFacturaVenta);
                        vCmd2.Parameters.AddWithValue("@MontoAplicacion", vOtrosCobranza.MontoAplicacion);

                        vRst = vCmd2.ExecuteScalar().ToString();
                        if (vRst.IndexOf("|") + 1 - vRst.Length == 0)
                        {
                            txscope.Complete();
                            vCnn.Close();
                            return vRst;
                        }
                        txscope.Dispose();
                        return "0";
                    }
                }
                catch (Exception ex)
                {
                    txscope.Dispose();
                    return "0";
                }
            }
        }


        #endregion
    }
}
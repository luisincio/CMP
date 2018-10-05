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
#endregion

namespace Cmp03.DataAccess
{
    public partial class Recepcion_AD : Base
    {
        #region Métodos Públicos Generales

        public List<Tb_Maestras> List_TipoDocumento()
        {
            List<Tb_Maestras> vLista = new List<Tb_Maestras>();
            using (SqlCommand vCmd = AdoGP.GetCommand("DBO.DIN_SP_TIPO_RECEPCION"))
            {
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Maestras() { Id_Maestras = Convert.ToInt32(vRdr["ID"]), Descripcion = vRdr["TIPO"].ToString() });
                        }
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        public List<Tb_Maestras> List_SunatDocumento()
        {
            List<Tb_Maestras> vLista = new List<Tb_Maestras>();
            using (SqlCommand vCmd = AdoGP.GetCommand("DBO.DIN_SP_SEL_LISTA_TIPO_DOC_SUNAT"))
            {
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Maestras() { Valor1 = vRdr["IDSUNAT"].ToString(), Descripcion = vRdr["DESCRIPCION"].ToString() });
                        }
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        public string Get_Nro_Documento()
        {
            string vResp = "";
            using (SqlCommand vCmd = AdoGP.GetCommand("DBO.DIN_SP_OBTENER_CORRELATIVO_RECEPCIONES"))
            {
                vResp = vCmd.ExecuteScalar().ToString();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vResp;
        }

        public List<Tb_Maestras> List_Ordenes(string vFiltro = "")
        {
            List<Tb_Maestras> vLista = new List<Tb_Maestras>();
            using (SqlCommand vCmd = AdoGP.GetCommand("DBO.DIN_SP_SEL_LISTA_ORDENESCOMPRA_PROVEEDOR_PENDIENTE"))
            {
                vCmd.Parameters.AddWithValue("@VENDORID", vFiltro);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    vLista.Add(new Tb_Maestras() { Descripcion = "SELECCIONE", Valor1 = "" });
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Maestras() { Descripcion = "N° " + vRdr["OrdenComra"].ToString() + Convert.ToChar(9) + "\t\t\t | Fecha: " + Convert.ToDateTime(vRdr["FechaOrden"]).ToString("dd/MM/yyyy") + ((char)9) + " | Total: " + Convert.ToDecimal(vRdr["ImporteOrden"]).ToString("#.00"), Valor1 = vRdr["OrdenComra"].ToString() });
                        }
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        public List<Oc_Transaccion> List_OrdenesDetalle(string vOrden)
        {
            List<Oc_Transaccion> vLista = new List<Oc_Transaccion>();
            using (SqlCommand vCmd = AdoGP.GetCommand("DBO.DIN_SP_LISTA_DETALLE_ORDENES_POR_RECIBIR"))
            {
                vCmd.Parameters.AddWithValue("@PONUMBER", vOrden);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Oc_Transaccion()
                            {
                                Ponumber = vRdr["PONUMBER"].ToString(),
                                Ord = vRdr["ORD"].ToString(),
                                Itemnmbr = vRdr["ITEMNMBR"].ToString(),
                                Itemdesc = vRdr["ITEMDESC"].ToString(),
                                Uofm = vRdr["UOFM"].ToString(),
                                Locncode = vRdr["LOCNCODE"].ToString(),
                                Cantidadpedida = Convert.ToDecimal(vRdr["CANTIDADPEDIDA"]),
                                Cantfacturada = Convert.ToDecimal(vRdr["CANTFACTURADA"]),
                                Cantenviada = Convert.ToDecimal(vRdr["CANTENVIADA"]),
                                Costounitario = Convert.ToDecimal(vRdr["COSTOUNITARIO"]),
                                Costototal = Convert.ToDecimal(vRdr["COSTOTOTAL"]),
                                Procentaje = Convert.ToDecimal(vRdr["PROCENTAJE"]),
                                Impuestoarticulo = vRdr["IMPUESTOARTICULO"].ToString(),
                                Impuestoproveedor = vRdr["IMPUESTOPROVEEDOR"].ToString(),
                                Idmoneda = vRdr["IDMONEDA"].ToString()
                            });
                        }
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        public List<Tb_Maestras> List_Detracciones()
        {
            List<Tb_Maestras> vLista = new List<Tb_Maestras>();
            using (SqlCommand vCmd = AdoGP.GetCommand("DBO.DIN_SP_SEL_LISTA_DETRACCIONES"))
            {
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Maestras() { Id_Maestras = Convert.ToInt32(vRdr["idInt"]), Descripcion = vRdr["DesTabla4"].ToString(), Valor1 = vRdr["CodTabla4"].ToString(), Valor2 = vRdr["Porcentaje"].ToString() });
                        }
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        public List<Tb_Maestras> List_CondicionPago()
        {
            List<Tb_Maestras> vLista = new List<Tb_Maestras>();
            using (SqlCommand vCmd = AdoGP.GetCommand("DBO.DIN_SP_SEL_LISTA_CONDICION_PAGO"))
            {
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Maestras() { Descripcion = vRdr["IdCondicion"].ToString().Trim(), Valor1 = vRdr["IdCondicion"].ToString().Trim() });
                        }
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        public int Grabar(Recepcion Recepcion)
        {
            int vRst = 0;
            using (var txscope = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew))
            {
                try
                {
                    using (SqlConnection vCnn = new SqlConnection(Cmp01.Utilities.Variables.CnnGP))
                    {
                        vCnn.Open();
                        foreach (var vOc_Detalle in Recepcion.Detalle)
                        {
                            SqlCommand vCmd1 = new SqlCommand("DIN_SP_CREAR_RECEPCION_DETALLE", vCnn);
                            vCmd1.CommandType = CommandType.StoredProcedure;
                            vCmd1.Parameters.AddWithValue("@TipoRecepcion", vOc_Detalle.TipoRecepcion);
                            vCmd1.Parameters.AddWithValue("@NroRecepcion", vOc_Detalle.NroRecepcion);
                            vCmd1.Parameters.AddWithValue("@IdProveedor", vOc_Detalle.IdProveedor);
                            vCmd1.Parameters.AddWithValue("@OrdenCompra", vOc_Detalle.OrdenCompra);
                            vCmd1.Parameters.AddWithValue("@LineaItemRecepcion", vOc_Detalle.LineaItemRecepcion);
                            vCmd1.Parameters.AddWithValue("@LineaItemorden", vOc_Detalle.LineaItemorden);
                            vCmd1.Parameters.AddWithValue("@IdProducto", vOc_Detalle.IdProducto);
                            vCmd1.Parameters.AddWithValue("@DesCripcionItem", vOc_Detalle.DesCripcionItem);
                            vCmd1.Parameters.AddWithValue("@unidadMedida", vOc_Detalle.UnidadMedida);
                            vCmd1.Parameters.AddWithValue("@CodigoAlmacen", vOc_Detalle.CodigoAlmacen);
                            vCmd1.Parameters.AddWithValue("@CantidadEnvio", vOc_Detalle.CantidadEnvio);
                            vCmd1.Parameters.AddWithValue("@CantidadFactura", vOc_Detalle.CantidadFactura);
                            vCmd1.Parameters.AddWithValue("@Costo", vOc_Detalle.Costo);
                            vCmd1.Parameters.AddWithValue("@SubTotal", vOc_Detalle.SubTotal);
                            vCmd1.Parameters.AddWithValue("@idMoneda", vOc_Detalle.IdMoneda);
                            vRst = vRst + Convert.ToInt32(vCmd1.ExecuteScalar());
                            if (vRst > 0) break;
                        }

                        if (vRst == 0)
                        {
                            SqlCommand vCmd2 = new SqlCommand("DIN_SP_CREAR_RECEPCION_CABECERA", vCnn);
                            vCmd2.CommandType = CommandType.StoredProcedure;
                            vCmd2.Parameters.AddWithValue("@TipoRecepcion", Recepcion.Cabecera.TipoRecepcion);
                            vCmd2.Parameters.AddWithValue("@NroRecepcion", Recepcion.Cabecera.NroRecepcion);
                            vCmd2.Parameters.AddWithValue("@TipoDocSunat", Recepcion.Cabecera.TipoDocSunat);
                            vCmd2.Parameters.AddWithValue("@NroDocumento", Recepcion.Cabecera.NroDocumento);
                            vCmd2.Parameters.AddWithValue("@FechaRecepcion", Recepcion.Cabecera.FechaRecepcion);
                            vCmd2.Parameters.AddWithValue("@Lote", Recepcion.Cabecera.Lote);
                            vCmd2.Parameters.AddWithValue("@IdProveedor", Recepcion.Cabecera.IdProveedor);
                            vCmd2.Parameters.AddWithValue("@NombreProveedor", Recepcion.Cabecera.NombreProveedor);
                            vCmd2.Parameters.AddWithValue("@IdCondicion", Recepcion.Cabecera.IdCondicion);
                            vCmd2.Parameters.AddWithValue("@idMoneda", Recepcion.Cabecera.IdMoneda);
                            vCmd2.Parameters.AddWithValue("@NoafectaKArdex", Recepcion.Cabecera.NoafectaKArdex);
                            vCmd2.Parameters.AddWithValue("@NoafectaRegCompra", Recepcion.Cabecera.NoafectaRegCompra);
                            vCmd2.Parameters.AddWithValue("@REtencion", Recepcion.Cabecera.Retencion);

                            vCmd2.Parameters.AddWithValue("@TipoCambio", Recepcion.Cabecera.TipoCambio);
                            vCmd2.Parameters.AddWithValue("@Consejo", Recepcion.Cabecera.IdConsejo);
                            
                            vRst = Convert.ToInt32(vCmd2.ExecuteScalar());
                            if (vRst == 0)
                            {
                                txscope.Complete();
                                vCnn.Close();
                                return 1;
                            }
                        }
                        txscope.Dispose();
                        return vRst;
                    }
                }
                catch (Exception)
                {
                    txscope.Dispose();
                    return vRst;
                }
            }
        }



        //public Oc_Cabecera Insert_Cabecera(Oc_Cabecera vOc_Cabecera)
        //{
        //    int vRst = 0;
        //    using (SqlCommand vCmd = AdoGP.GetCommand("DBO.DIN_SP_CREAR_OC_CABECERA"))
        //    {
        //        vCmd.Parameters.AddWithValue("@POTYPE", vOc_Cabecera.Potype);
        //        vCmd.Parameters.AddWithValue("@PONUMBER", vOc_Cabecera.Ponumber);
        //        vCmd.Parameters.AddWithValue("@BUYERID", vOc_Cabecera.Buyerid);
        //        vCmd.Parameters.AddWithValue("@USERID", vOc_Cabecera.Userid);
        //        vCmd.Parameters.AddWithValue("@DOCDATE", vOc_Cabecera.Docdate);
        //        vCmd.Parameters.AddWithValue("@VENDORID", vOc_Cabecera.Vendorid);
        //        vCmd.Parameters.AddWithValue("@CURNCYID", vOc_Cabecera.Curncyid);
        //        vRst = Convert.ToInt32(vCmd.ExecuteScalar());
        //        vCmd.Dispose();
        //    }
        //    if (vRst > 0) return vOc_Cabecera; else return null;
        //}

        //public Oc_Detalle Insert_Detalle(Oc_Detalle vOc_Detalle)
        //{
        //    int vRst = 0;
        //    using (SqlCommand vCmd = AdoGP.GetCommand("DBO.DIN_SP_CREAR_OC_DETALLE"))
        //    {
        //        vCmd.Parameters.AddWithValue("@POTYPE", vOc_Detalle.Potype);
        //        vCmd.Parameters.AddWithValue("@PONUMBER", vOc_Detalle.Ponumber);
        //        vCmd.Parameters.AddWithValue("@DOCDATE", vOc_Detalle.Docdate);
        //        vCmd.Parameters.AddWithValue("@VENDORID", vOc_Detalle.Vendorid);
        //        vCmd.Parameters.AddWithValue("@LOCNCODE", vOc_Detalle.Locncode);
        //        vCmd.Parameters.AddWithValue("@LineNumber", vOc_Detalle.Linenumber);
        //        vCmd.Parameters.AddWithValue("@ITEMNMBR", vOc_Detalle.Itemnmbr);
        //        vCmd.Parameters.AddWithValue("@QUANTITY", vOc_Detalle.Quantity);
        //        vCmd.Parameters.AddWithValue("@UNITCOST", vOc_Detalle.Unitcost);
        //        vCmd.Parameters.AddWithValue("@UOFM", vOc_Detalle.Uofm);
        //        vCmd.Parameters.AddWithValue("@CURNCYID", vOc_Detalle.Curncyid);
        //        vCmd.Parameters.AddWithValue("@Total", vOc_Detalle.Total);
        //        vRst = Convert.ToInt32(vCmd.ExecuteScalar());
        //        vCmd.Dispose();
        //    }
        //    if (vRst > 0) return vOc_Detalle; else return null;
        //}


        //public int Grabar(OrdenCompra Orden)
        //{
        //    int vRst = 0;
        //    using (var txscope = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew))
        //    {
        //        try
        //        {
        //            using (SqlConnection objConn = new SqlConnection(Cmp01.Utilities.Variables.CnnGP))
        //            {
        //                objConn.Open();
        //                foreach (var vOc_Detalle in Orden.Detalle)
        //                {
        //                    SqlCommand vCmd1 = new SqlCommand("DIN_SP_CREAR_OC_DETALLE", objConn);
        //                    vCmd1.CommandType = CommandType.StoredProcedure;
        //                    vCmd1.Parameters.AddWithValue("@POTYPE", vOc_Detalle.Potype);
        //                    vCmd1.Parameters.AddWithValue("@PONUMBER", vOc_Detalle.Ponumber);
        //                    vCmd1.Parameters.AddWithValue("@DOCDATE", vOc_Detalle.Docdate);
        //                    vCmd1.Parameters.AddWithValue("@VENDORID", vOc_Detalle.Vendorid);
        //                    vCmd1.Parameters.AddWithValue("@LOCNCODE", vOc_Detalle.Locncode);
        //                    vCmd1.Parameters.AddWithValue("@LineNumber", vOc_Detalle.Linenumber);
        //                    vCmd1.Parameters.AddWithValue("@ITEMNMBR", vOc_Detalle.Itemnmbr);
        //                    vCmd1.Parameters.AddWithValue("@QUANTITY", vOc_Detalle.Quantity);
        //                    vCmd1.Parameters.AddWithValue("@UNITCOST", vOc_Detalle.Unitcost);
        //                    vCmd1.Parameters.AddWithValue("@UOFM", vOc_Detalle.Uofm);
        //                    vCmd1.Parameters.AddWithValue("@CURNCYID", vOc_Detalle.Curncyid);
        //                    vCmd1.Parameters.AddWithValue("@Total", vOc_Detalle.Total);
        //                    vRst = vRst + Convert.ToInt32(vCmd1.ExecuteScalar());
        //                }

        //                if (vRst == 0)
        //                {
        //                    SqlCommand vCmd2 = new SqlCommand("DIN_SP_CREAR_OC_CABECERA", objConn);
        //                    vCmd2.CommandType = CommandType.StoredProcedure;
        //                    vCmd2.Parameters.AddWithValue("@POTYPE", Orden.Cabecera.Potype);
        //                    vCmd2.Parameters.AddWithValue("@PONUMBER", Orden.Cabecera.Ponumber);
        //                    vCmd2.Parameters.AddWithValue("@BUYERID", Orden.Cabecera.Buyerid);
        //                    vCmd2.Parameters.AddWithValue("@USERID", Orden.Cabecera.Userid);
        //                    vCmd2.Parameters.AddWithValue("@DOCDATE", Orden.Cabecera.Docdate);
        //                    vCmd2.Parameters.AddWithValue("@VENDORID", Orden.Cabecera.Vendorid);
        //                    vCmd2.Parameters.AddWithValue("@CURNCYID", Orden.Cabecera.Curncyid);
        //                    vRst = Convert.ToInt32(vCmd2.ExecuteScalar());
        //                    if (vRst == 0)
        //                    {
        //                        txscope.Complete();
        //                        objConn.Close();
        //                        return 1;
        //                    }
        //                }
        //                txscope.Dispose();
        //                return 0;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            txscope.Dispose();
        //            return 0;
        //        }
        //    }
        //}


        #endregion
    }
}
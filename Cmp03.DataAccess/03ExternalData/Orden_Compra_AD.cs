/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Orden_Compra_AD.cs
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
    public partial class Orden_Compra_AD : Base
    {
        #region Métodos Públicos Generales

        public List<Tb_Maestras> List_TipoDocumento()
        {
            List<Tb_Maestras> vLista = new List<Tb_Maestras>();
            using (SqlCommand vCmd = AdoGP.GetCommand("DBO.DIN_SP_SEL_TIPO_ORDENCOMPRA"))
            {
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Maestras() { Id_Maestras = Convert.ToInt32(vRdr["ID"]), Descripcion = vRdr["DESCRIPCION"].ToString() });
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
            using (SqlCommand vCmd = AdoGP.GetCommand("DBO.DIN_SP_OBTENER_CORRELATIVO_OC"))
            {
                vResp = vCmd.ExecuteScalar().ToString();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vResp;
        }

        public List<Tb_Maestras> List_Proveedor(string vFiltro = "")
        {
            List<Tb_Maestras> vLista = new List<Tb_Maestras>();
            using (SqlCommand vCmd = AdoGP.GetCommand("DBO.DIN_SP_SEL_LISTA_PROVEEDOR"))
            {
                vCmd.Parameters.AddWithValue("@FILTRO", vFiltro);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        int vCount = 0;
                        while (vRdr.Read())
                        {
                            vCount = vCount + 1;
                            vLista.Add(new Tb_Maestras() { Id_Maestras = vCount, Descripcion = vRdr["RazonSocial"].ToString(), Valor1 = vRdr["idProveedor"].ToString(),Valor2= vRdr["Direccion"].ToString() });
                        }
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        public List<Tb_Maestras> List_Moneda()
        {
            List<Tb_Maestras> vLista = new List<Tb_Maestras>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_MONEDA_GP"))
            {
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Maestras() { Descripcion = vRdr["DESCRIPCION"].ToString(), Valor1 = vRdr["ID"].ToString() });
                        }
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        public List<Tb_Maestras> List_PlanImpuesto()
        {
            List<Tb_Maestras> vLista = new List<Tb_Maestras>();
            using (SqlCommand vCmd = AdoGP.GetCommand("DBO.DIN_SP_LISTA_PLAN_IMPUESTO"))
            {
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Maestras() { Descripcion = vRdr["DesPlanImpuesto"].ToString(), Valor1 = vRdr["IdPlanImpuesto"].ToString() });
                        }
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        public List<Tb_Maestras> List_Responsable()
        {
            List<Tb_Maestras> vLista = new List<Tb_Maestras>();
            using (SqlCommand vCmd = AdoGP.GetCommand("DBO.DIN_SP_LISTA_COMPRADORES"))
            {
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Maestras() { Descripcion = vRdr["NombreComprador"].ToString(), Valor1 = vRdr["IdComprado"].ToString() });
                        }
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        public List<Tb_Maestras> List_Servicios(string vFiltro, string vImp, string vTipo)
        {
            List<Tb_Maestras> vLista = new List<Tb_Maestras>();
            using (SqlCommand vCmd = AdoGP.GetCommand("DBO.DIN_SP_SEL_LISTAR_ARTICULOS"))
            {
                vCmd.Parameters.AddWithValue("@FILTRO", vFiltro);
                vCmd.Parameters.AddWithValue("@PLANIMPUESTO", vImp.Trim());
                vCmd.Parameters.AddWithValue("@Tipo", vTipo);
                
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Maestras() { Descripcion = vRdr["DesArticulo"].ToString(), Valor1 = vRdr["IdArticulo"].ToString(), Valor2 = vRdr["UnidadMedida"].ToString(), Valor3 = vRdr["Procentaje"].ToString() });
                        }
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        public int Insert_Cabecera(Oc_Cabecera vOc_Cabecera)
        {
            int vRst = 0;
            using (SqlCommand vCmd = AdoGP.GetCommand("DBO.DIN_SP_CREAR_OC_CABECERA"))
            {
                vCmd.Parameters.AddWithValue("@POTYPE", vOc_Cabecera.Potype);
                vCmd.Parameters.AddWithValue("@PONUMBER", vOc_Cabecera.Ponumber);
                vCmd.Parameters.AddWithValue("@BUYERID", vOc_Cabecera.Buyerid);
                vCmd.Parameters.AddWithValue("@USERID", vOc_Cabecera.Userid);
                vCmd.Parameters.AddWithValue("@DOCDATE", vOc_Cabecera.Docdate);
                vCmd.Parameters.AddWithValue("@VENDORID", vOc_Cabecera.Vendorid);
                vCmd.Parameters.AddWithValue("@CURNCYID", vOc_Cabecera.Curncyid);
                vCmd.Parameters.AddWithValue("@Consejo", vOc_Cabecera.IdConsejo);
                vRst = Convert.ToInt32(vCmd.ExecuteScalar());
                vCmd.Dispose();
            }
            return vRst;
        }

        public int Insert_Detalle(Oc_Detalle vOc_Detalle)
        {
            int vRst = 0;
            using (SqlCommand vCmd = AdoGP.GetCommand("DBO.DIN_SP_CREAR_OC_DETALLE"))
            {
                vCmd.Parameters.AddWithValue("@POTYPE", vOc_Detalle.Potype);
                vCmd.Parameters.AddWithValue("@PONUMBER", vOc_Detalle.Ponumber.Trim());
                vCmd.Parameters.AddWithValue("@DOCDATE", vOc_Detalle.Docdate);
                vCmd.Parameters.AddWithValue("@VENDORID", vOc_Detalle.Vendorid.Trim());
                vCmd.Parameters.AddWithValue("@LOCNCODE", vOc_Detalle.Locncode);
                vCmd.Parameters.AddWithValue("@LineNumber", vOc_Detalle.Linenumber);
                vCmd.Parameters.AddWithValue("@ITEMNMBR", vOc_Detalle.Itemnmbr.Trim());
                vCmd.Parameters.AddWithValue("@QUANTITY", vOc_Detalle.Quantity);
                vCmd.Parameters.AddWithValue("@UNITCOST", vOc_Detalle.Unitcost);
                vCmd.Parameters.AddWithValue("@UOFM", vOc_Detalle.Uofm.Trim());
                vCmd.Parameters.AddWithValue("@CURNCYID", vOc_Detalle.Curncyid.Trim());
                vCmd.Parameters.AddWithValue("@Total", vOc_Detalle.Total);
                vRst = Convert.ToInt32(vCmd.ExecuteScalar());
                vCmd.Dispose();
            }
            return vRst;
        }


        public int Grabar(OrdenCompra Orden)
        {
            int vRst = 0;
            using (var txscope = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew))
            {
                try
                {
                    using (SqlConnection objConn = new SqlConnection(Cmp01.Utilities.Variables.CnnGP))
                    {
                        objConn.Open();
                        foreach (var vOc_Detalle in Orden.Detalle)
                        {
                            SqlCommand vCmd1 = new SqlCommand("DIN_SP_CREAR_OC_DETALLE", objConn);
                            vCmd1.CommandType = CommandType.StoredProcedure;
                            vCmd1.Parameters.AddWithValue("@POTYPE", vOc_Detalle.Potype);
                            vCmd1.Parameters.AddWithValue("@PONUMBER", vOc_Detalle.Ponumber);
                            vCmd1.Parameters.AddWithValue("@DOCDATE", vOc_Detalle.Docdate);
                            vCmd1.Parameters.AddWithValue("@VENDORID", vOc_Detalle.Vendorid);
                            vCmd1.Parameters.AddWithValue("@LOCNCODE", vOc_Detalle.Locncode);
                            vCmd1.Parameters.AddWithValue("@LineNumber", vOc_Detalle.Linenumber);
                            vCmd1.Parameters.AddWithValue("@ITEMNMBR", vOc_Detalle.Itemnmbr);
                            vCmd1.Parameters.AddWithValue("@QUANTITY", vOc_Detalle.Quantity);
                            vCmd1.Parameters.AddWithValue("@UNITCOST", vOc_Detalle.Unitcost);
                            vCmd1.Parameters.AddWithValue("@UOFM", vOc_Detalle.Uofm);
                            vCmd1.Parameters.AddWithValue("@CURNCYID", vOc_Detalle.Curncyid);
                            vCmd1.Parameters.AddWithValue("@Total", vOc_Detalle.Total);
                            vRst = vRst + Convert.ToInt32(vCmd1.ExecuteScalar());
                        }

                        if (vRst == 0)
                        {
                            SqlCommand vCmd2 = new SqlCommand("DIN_SP_CREAR_OC_CABECERA", objConn);
                            vCmd2.CommandType = CommandType.StoredProcedure;
                            vCmd2.Parameters.AddWithValue("@POTYPE", Orden.Cabecera.Potype);
                            vCmd2.Parameters.AddWithValue("@PONUMBER", Orden.Cabecera.Ponumber);
                            vCmd2.Parameters.AddWithValue("@BUYERID", Orden.Cabecera.Buyerid);
                            vCmd2.Parameters.AddWithValue("@USERID", Orden.Cabecera.Userid);
                            vCmd2.Parameters.AddWithValue("@DOCDATE", Orden.Cabecera.Docdate);
                            vCmd2.Parameters.AddWithValue("@VENDORID", Orden.Cabecera.Vendorid);
                            vCmd2.Parameters.AddWithValue("@CURNCYID", Orden.Cabecera.Curncyid);
                            vRst = Convert.ToInt32(vCmd2.ExecuteScalar());
                            if (vRst == 0)
                            {
                                txscope.Complete();
                                objConn.Close();
                                return 1;
                            }
                        }
                        txscope.Dispose();
                        return 0;
                    }
                }
                catch (Exception)
                {
                    txscope.Dispose();
                    return 0;
                }
            }  
        }


        #endregion
    }
}
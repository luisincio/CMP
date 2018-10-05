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
    public partial class Cuentas_Pagar_AD : Base
    {
        #region Métodos Públicos Generales

        public List<Tb_Maestras> List_TipoDocumento()
        {
            List<Tb_Maestras> vLista = new List<Tb_Maestras>();
            using (SqlCommand vCmd = AdoGP.GetCommand("DBO.DIN_SP_SEL_LISTA_TIPO_DOCUMENTO"))
            {
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Maestras() { Id_Maestras = Convert.ToInt32(vRdr["idTipo"]), Descripcion = vRdr["desTipo"].ToString() });
                        }
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        public List<Tb_Maestras> List_ConceptoGastos(int TIPO)
        {
            List<Tb_Maestras> vLista = new List<Tb_Maestras>();
            using (SqlCommand vCmd = AdoGP.GetCommand("DBO.DIN_SP_LISTA_CONCEPTO_GASTOS"))
            {
                vCmd.CommandTimeout=0;
                vCmd.Parameters.AddWithValue("@TIPO", TIPO);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Maestras() { Id_Maestras = Convert.ToInt32(vRdr["ACTINDX"]), Descripcion = vRdr["ACTDESCR"].ToString() });
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
            using (SqlCommand vCmd = AdoGP.GetCommand("DBO.DIN_SP_OBTENER_CORRELATIVO_CXP"))
            {
                vResp = vCmd.ExecuteScalar().ToString();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vResp;
        }

        public List<Tb_Maestras> List_Direccion(string vProveedor)
        {
            List<Tb_Maestras> vLista = new List<Tb_Maestras>();
            using (SqlCommand vCmd = AdoGP.GetCommand("DBO.DIN_SP_LISTA_DIRECCION_PROVEEDOR"))
            {
                vCmd.Parameters.AddWithValue("@idProveedor", vProveedor);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Maestras() { Descripcion = vRdr["ADDRESS1"].ToString(), Valor1 = vRdr["ADRSCODE"].ToString() });
                        }
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        public int Grabar(Transacciones Transacciones)
        {
            int vRst = 0;
            using (var txscope = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew))
            {
                try
                {
                    using (SqlConnection vCnn = new SqlConnection(Cmp01.Utilities.Variables.CnnGP))
                    {
                        vCnn.Open();

                        SqlCommand vCmd2 = new SqlCommand("DIN_SP_CREAR_CUENTA_POR_PAGAR", vCnn);
                        vCmd2.CommandType = CommandType.StoredProcedure;
                        vCmd2.Parameters.AddWithValue("@LOTE", Transacciones.Lote);
                        vCmd2.Parameters.AddWithValue("@TIPODOC", Transacciones.Tipodoc);
                        vCmd2.Parameters.AddWithValue("@NROCOMP", Transacciones.Nrocomp);
                        vCmd2.Parameters.AddWithValue("@IDPROVEEDOR", Transacciones.Idproveedor);
                        vCmd2.Parameters.AddWithValue("@IDDOCSUNAT", Transacciones.Iddocsunat);
                        vCmd2.Parameters.AddWithValue("@NRODOCUMENTO", Transacciones.Nrodocumento);
                        vCmd2.Parameters.AddWithValue("@IDIMPUESTO", Transacciones.Idimpuesto);
                        vCmd2.Parameters.AddWithValue("@CODICION", Transacciones.Codicion);
                        vCmd2.Parameters.AddWithValue("@MONTOCOMPRA", Transacciones.Montocompra);
                        vCmd2.Parameters.AddWithValue("@MONTIMPUESTO", Transacciones.Montimpuesto);
                        vCmd2.Parameters.AddWithValue("@MONTOMISCELANEO", Transacciones.Montomiscelaneo);
                        vCmd2.Parameters.AddWithValue("@MONTOFLETE", Transacciones.MontoDescuento);
                        vCmd2.Parameters.AddWithValue("@MONTODESCUENTO", Transacciones.MontoDescuento);
                        vCmd2.Parameters.AddWithValue("@FECHA", Transacciones.Fecha);
                        vCmd2.Parameters.AddWithValue("@OBSERVACION", Transacciones.Observacion);
                        vCmd2.Parameters.AddWithValue("@ORDENCOMPRA", Transacciones.Ordencompra);
                        vCmd2.Parameters.AddWithValue("@MONEDA", Transacciones.Moneda);
                        vCmd2.Parameters.AddWithValue("@TC", Transacciones.Tc);
                        vCmd2.Parameters.AddWithValue("@AFECTAREGCOMPRA", Transacciones.Afectaregcompra);
                        vCmd2.Parameters.AddWithValue("@AFECTARETENCION", Transacciones.Afectaretencion);
                        vCmd2.Parameters.AddWithValue("@IDDETRACCCION", Transacciones.Iddetracccion);
                        vCmd2.Parameters.AddWithValue("@PORDETRACCION", Transacciones.Pordetraccion);
                        vCmd2.Parameters.AddWithValue("@MONTODETRACCION", Transacciones.Montodetraccion);
                        vCmd2.Parameters.AddWithValue("@TipDocRef", Transacciones.Tipdocref);
                        vCmd2.Parameters.AddWithValue("@NroDocRef", Transacciones.Nrodocref);
                        vCmd2.Parameters.AddWithValue("@FechaDocRef", Transacciones.Fechadocref);
                        vCmd2.Parameters.AddWithValue("@Consejo", Transacciones.IdConsejo);
                        vCmd2.Parameters.AddWithValue("@cuenta", Transacciones.IdConceptoGasto);

                        vRst = Convert.ToInt32(vCmd2.ExecuteScalar());
                        if (vRst == 0)
                        {
                            txscope.Complete();
                            vCnn.Close();
                            return 1;
                        }
                        txscope.Dispose();
                        return vRst;
                    }
                }
                catch (Exception ex)
                {
                    txscope.Dispose();
                    return vRst;
                }
            }
        }


        public List<Tb_Maestras> List_TipoPago()
        {
            List<Tb_Maestras> vLista = new List<Tb_Maestras>();
            using (SqlCommand vCmd = AdoGP.GetCommand("DBO.UP_Obtener_Tipos_cobros"))
            {
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Maestras() { Valor1 = vRdr["Codigo"].ToString(), Descripcion = vRdr["Descripcion"].ToString() });
                        }
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        public List<Tb_Comprobantecabecera> List_FacturaPendientes(string vCliente)
        {
            List<Tb_Comprobantecabecera> vLista = new List<Tb_Comprobantecabecera>();
            using (SqlCommand vCmd = AdoGP.GetCommand("DBO.UP_Obtener_Facturas_Pendientes_x_Cobrar"))
            {
                vCmd.Parameters.AddWithValue("@CUSTNMBR", vCliente);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Comprobantecabecera()
                            {
                                Nro_Documento = vRdr["Numero"].ToString(),
                                Fecha = Convert.ToDateTime( vRdr["Fecha"]),
                                Total = Convert.ToDecimal( vRdr["Saldo"]),
                                Opcional = vRdr["Numero"].ToString() + " - " + Convert.ToDateTime(vRdr["Fecha"]).ToShortDateString() + " - " + Convert.ToDecimal(vRdr["Saldo"]).ToString("0.00")
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
        #endregion
    }
}
/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Transacciones_AD.cs
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
    public partial class Transacciones_AD : Base
    {
        #region Métodos Públicos Generales

        public string Get_Nro_Documento()
        {
            string vResp = "";
            using (SqlCommand vCmd = AdoGP.GetCommand("DBO.DIN_SP_OBTENER_NRO_DIARIO"))
            {
                vResp = vCmd.ExecuteScalar().ToString();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vResp;
        }

        public List<Tb_Maestras> List_DocumentoOrigen()
        {
            List<Tb_Maestras> vLista = new List<Tb_Maestras>();
            using (SqlCommand vCmd = AdoGP.GetCommand("DBO.DIN_SP_LISTA_DOCUMENTO_ORIGEN"))
            {
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Maestras() { Valor1 = vRdr["Id"].ToString(), Descripcion = vRdr["Descripcion"].ToString() });
                        }
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        public List<Tb_Maestras> List_CuentaContable(string vFiltro)
        {
            List<Tb_Maestras> vLista = new List<Tb_Maestras>();
            using (SqlCommand vCmd = AdoGP.GetCommand("DBO.DIN_SP_LISTA_CUENTAS_CONTABLE"))
            {
                vCmd.Parameters.AddWithValue("@FILTRO", vFiltro);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Maestras() { Id_Maestras = Convert.ToInt32(vRdr["IdCuenta"]), Valor1 = vRdr["Id"].ToString(), Descripcion = vRdr["Descripcion"].ToString() });
                        }
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }


        public int Grabar(EntradaTransaccion vTransaccion)
        {
            int vRst = 0;
            using (var txscope = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew))
            {
                try
                {
                    using (SqlConnection vCnn = new SqlConnection(Cmp01.Utilities.Variables.CnnGP))
                    {
                        vCnn.Open();
                        int vCount = 0;
                        foreach (var vOc_Detalle in vTransaccion.Detalle)
                        {
                            vCount += 1;
                            SqlCommand vCmd1 = new SqlCommand("DIN_SP_INS_DETALLE_DIARIOS", vCnn);
                            vCmd1.CommandType = CommandType.StoredProcedure;
                            vCmd1.Parameters.AddWithValue("@LOTE", vTransaccion.Cabecera.Lote.ToUpper());
                            vCmd1.Parameters.AddWithValue("@DIARIO", vTransaccion.Cabecera.EntradaDiario);
                            vCmd1.Parameters.AddWithValue("@LINEA", vCount);
                            vCmd1.Parameters.AddWithValue("@CUENTA", vOc_Detalle.IdCuenta);
                            vCmd1.Parameters.AddWithValue("@CREDITO", vOc_Detalle.Credito);
                            vCmd1.Parameters.AddWithValue("@DEBITO", vOc_Detalle.Debito);
                            vRst = vRst + Convert.ToInt32(vCmd1.ExecuteScalar());
                            if (vRst > 0) break;
                        }

                        if (vRst == 0)
                        {
                            SqlCommand vCmd2 = new SqlCommand("DIN_SP_INS_CABECERA_DIARIOS", vCnn);
                            vCmd2.CommandType = CommandType.StoredProcedure;
                            vCmd2.Parameters.AddWithValue("@LOTE", vTransaccion.Cabecera.Lote.ToUpper());
                            vCmd2.Parameters.AddWithValue("@DIARIO", vTransaccion.Cabecera.EntradaDiario);
                            vCmd2.Parameters.AddWithValue("@REFERENCIA", vTransaccion.Cabecera.Referencia.ToUpper());
                            //vCmd2.Parameters.AddWithValue("@FECHA", vTransaccion.Cabecera.FechaTransaccion.Day.ToString("00") + "/" + vTransaccion.Cabecera.FechaTransaccion.Month.ToString("00") + "/" + vTransaccion.Cabecera.FechaTransaccion.Year.ToString());
                            //vCmd2.Parameters.AddWithValue("@FECHA", "01/01/2018");
                            vCmd2.Parameters.AddWithValue("@FECHA", vTransaccion.Cabecera.FechaTransaccion);
                            vCmd2.Parameters.AddWithValue("@MONEDA", vTransaccion.Cabecera.Moneda.Trim());
                            vCmd2.Parameters.AddWithValue("@ORIGEN", vTransaccion.Cabecera.DocumentoOrigen.ToUpper());
                            vCmd2.Parameters.AddWithValue("@IDCONSEJO", vTransaccion.Cabecera.IdConsejo);

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

        #endregion
    }
}
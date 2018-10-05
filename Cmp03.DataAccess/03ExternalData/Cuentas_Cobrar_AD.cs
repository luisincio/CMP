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
    public partial class Cuentas_Cobrar_AD : Base
    {
        #region Métodos Públicos Generales
        
        public int Grabar(TransaccionesCobros Transacciones)
        {
            int vRst = 0;
            using (var txscope = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew))
            {
                try
                {
                    using (SqlConnection vCnn = new SqlConnection(Cmp01.Utilities.Variables.CnnGP))
                    {
                        vCnn.Open();

                        SqlCommand vCmd2 = new SqlCommand("usp_SS_RM_CreateRMTransactionInsert", vCnn);
                        vCmd2.CommandType = CommandType.StoredProcedure;
                        vCmd2.Parameters.AddWithValue("@TipodeDocumento", Transacciones.TipodeDocumento);
                        vCmd2.Parameters.AddWithValue("@NumerodeDocumento", Transacciones.NumerodeDocumento);
                        vCmd2.Parameters.AddWithValue("@Descripcion", Transacciones.Descripcion);
                        vCmd2.Parameters.AddWithValue("@IddeLote", Transacciones.Lote);
                        //vCmd2.Parameters.AddWithValue("@FechaDocumento", Transacciones.FechaDocumento);
                        //vCmd2.Parameters.AddWithValue("@FechaContabilizacion", Transacciones.FechaContabilizacion);
                        vCmd2.Parameters.AddWithValue("@FechaDocumento", Transacciones.FechaDocumento.Day.ToString() + '/' + Transacciones.FechaDocumento.Month.ToString("00") + "/" + Transacciones.FechaDocumento.Year.ToString() + " " + Transacciones.FechaDocumento.Hour.ToString("00") + ":" + Transacciones.FechaDocumento.Minute.ToString("00") + ":" + Transacciones.FechaDocumento.Second.ToString("00"));
                        vCmd2.Parameters.AddWithValue("FechaContabilizacion", Transacciones.FechaDocumento.Day.ToString() + '/' + Transacciones.FechaDocumento.Month.ToString("00") + "/" + Transacciones.FechaDocumento.Year.ToString() + " " + Transacciones.FechaDocumento.Hour.ToString("00") + ":" + Transacciones.FechaDocumento.Minute.ToString("00") + ":" + Transacciones.FechaDocumento.Second.ToString("00"));
                        vCmd2.Parameters.AddWithValue("@IdCliente", Transacciones.IdCliente);
                        vCmd2.Parameters.AddWithValue("@IddeDireccion", Transacciones.IdDireccion);
                        vCmd2.Parameters.AddWithValue("@IddeTerritorio", Transacciones.IdTerritorio);
                        vCmd2.Parameters.AddWithValue("@IddeMoneda", Transacciones.Moneda);
                        vCmd2.Parameters.AddWithValue("@TipodeCambio", Transacciones.TipodeCambio);
                        vCmd2.Parameters.AddWithValue("@CondiciondePago", Transacciones.Condicion);
                        vCmd2.Parameters.AddWithValue("@MetododeEnvio", Transacciones.MetododeEnvio);
                        vCmd2.Parameters.AddWithValue("@IdPlandeImpuestos", Transacciones.IdPlanImpuestos);
                        vCmd2.Parameters.AddWithValue("@IdPlandeImpuestosVentas", Transacciones.IdPlanImpuestosVentas);
                        vCmd2.Parameters.AddWithValue("@IdPlandeImpuestosFlete", Transacciones.IdPlanImpuestosFlete);
                        vCmd2.Parameters.AddWithValue("@IdPlandeImpuestosMiscelaneo", Transacciones.IdPlanImpuestosMiscelaneo);
                        vCmd2.Parameters.AddWithValue("@NumOrdenCompra", Transacciones.NumOrdenCompra);
                        vCmd2.Parameters.AddWithValue("@Costo", Transacciones.Costo);
                        vCmd2.Parameters.AddWithValue("@Ventas", Transacciones.Ventas);
                        vCmd2.Parameters.AddWithValue("@DtoComercial", Transacciones.DtoComercial);
                        vCmd2.Parameters.AddWithValue("@Flete", Transacciones.Flete);
                        vCmd2.Parameters.AddWithValue("@Miscelaneo", Transacciones.Miscelaneo);
                        vCmd2.Parameters.AddWithValue("@CuentaContable", Transacciones.CuentaContable);
                        vCmd2.Parameters.AddWithValue("@TipoDocSunat", Transacciones.TipoDocSunat);

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


        public int GrabarNotasCaja(NotaCreditoDebitoCaja Transacciones)
        {
            int vRst = 0;
            using (var txscope = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew))
            {
                try
                {
                    using (SqlConnection vCnn = new SqlConnection(Cmp01.Utilities.Variables.CnnGP))
                    {
                        vCnn.Open();

                        SqlCommand vCmd2 = new SqlCommand("usp_SS_RM_CreateRMTransactionInsert", vCnn);
                        vCmd2.CommandType = CommandType.StoredProcedure;
                        vCmd2.Parameters.AddWithValue("@TipodeDocumento", Transacciones.TipodeDocumento);
                        vCmd2.Parameters.AddWithValue("@NumerodeDocumento", Transacciones.NumerodeDocumento);
                        vCmd2.Parameters.AddWithValue("@Descripcion", Transacciones.Descripcion);
                        vCmd2.Parameters.AddWithValue("@IddeLote", Transacciones.IddeLote);
                        vCmd2.Parameters.AddWithValue("@FechaDocumento", Transacciones.FechaDocumento.Day.ToString() + '/' + Transacciones.FechaDocumento.Month.ToString("00") + "/" + Transacciones.FechaDocumento.Year.ToString() + " " + Transacciones.FechaDocumento.Hour.ToString("00") + ":" + Transacciones.FechaDocumento.Minute.ToString("00") + ":" + Transacciones.FechaDocumento.Second.ToString("00"));
                        vCmd2.Parameters.AddWithValue("@FechaContabilizacion", Transacciones.FechaDocumento.Day.ToString() + '/' + Transacciones.FechaDocumento.Month.ToString("00") + "/" + Transacciones.FechaDocumento.Year.ToString() + " " + Transacciones.FechaDocumento.Hour.ToString("00") + ":" + Transacciones.FechaDocumento.Minute.ToString("00") + ":" + Transacciones.FechaDocumento.Second.ToString("00"));
                        vCmd2.Parameters.AddWithValue("@IdCliente", Transacciones.IdCliente);
                        vCmd2.Parameters.AddWithValue("@IddeMoneda", Transacciones.IddeMoneda);
                        vCmd2.Parameters.AddWithValue("@NumOrdenCompra", Transacciones.NumOrdenCompra);
                        vCmd2.Parameters.AddWithValue("@Ventas", Transacciones.Ventas);
                        vCmd2.Parameters.AddWithValue("@DtoComercial", Transacciones.DtoComercial);
                        vCmd2.Parameters.AddWithValue("@NumeroDocaAplicar", Transacciones.NumeroDocaAplicar);
                        vCmd2.Parameters.AddWithValue("@MontoAplicacion", Transacciones.MontoAplicacion);

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


        #endregion
    }
}
/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Orden_Compra_LN.cs
Objetivo          : Clase referida a los métodos de Lógica de Negocio de la clase GP
Autor             : CMP-SISTEMAS (FRR)
Fecha Creación    : 09/06/2018 
----------------------------------------------------------------------------------------*/
#region Espacios de Nombres
using Cmp03.DataAccess;
using Cmp02.Entities;
using Cmp01.Utilities;
using System;
using System.Collections.Generic;
using System.Transactions;
#endregion

namespace Cmp04.BusinessLogic
{
    public class Cuentas_Cobrar_LN : Base
    {
        #region Métodos Públicos Generales


        public List<Tb_Maestras> List_TipoDocumento()
        {
            try
            {
                return new Cuentas_Pagar_AD().List_TipoDocumento();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public List<Tb_Maestras> List_ConceptoGastos(int tipo)
        {
            try
            {
                return new Cuentas_Pagar_AD().List_ConceptoGastos(tipo);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }


        public string Get_Nro_Documento()
        {
            try
            {
                return new Cuentas_Pagar_AD().Get_Nro_Documento();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public List<Tb_Maestras> List_Direccion(string vProveedor)
        {
            try
            {
                return new Cuentas_Pagar_AD().List_Direccion(vProveedor);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public int GrabarCaja(NotaCreditoDebitoCaja Transacciones)
        {
            try
            {
                //Transacciones.TipoDocSunat = "NOTA CRÈDITO";
                //Transacciones.IdTerritorio = "";
                //Transacciones.IdPlanImpuestosVentas = "";
                //Transacciones.IdPlanImpuestosFlete = "";
                //Transacciones.IdPlanImpuestosMiscelaneo = "";
                //Transacciones.CuentaContable = "";
                //string vNumeroGp = new Numeracion_AD().GetVaue(),
                return new Cuentas_Cobrar_AD().GrabarNotasCaja(Transacciones);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }



        public int Grabar(TransaccionesCobros Transacciones)
        {
            try
            {
                Transacciones.TipoDocSunat = "NOTA CRÈDITO";
                Transacciones.IdTerritorio = "";
                Transacciones.IdPlanImpuestosVentas = "";
                Transacciones.IdPlanImpuestosFlete = "";
                Transacciones.IdPlanImpuestosMiscelaneo = "";
                Transacciones.CuentaContable = "";
                
                return new Cuentas_Cobrar_AD().Grabar(Transacciones);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }




        public List<Tb_Maestras> List_TipoPago()
        {
            try
            {
                return new Cuentas_Pagar_AD().List_TipoPago();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public List<Tb_Comprobantecabecera> List_FacturaPendientes(string vCliente)
        {
            try
            {
                return new Cuentas_Pagar_AD().List_FacturaPendientes(vCliente);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        #endregion
    }
}

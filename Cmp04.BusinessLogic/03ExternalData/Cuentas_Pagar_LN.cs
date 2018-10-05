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
    public class Cuentas_Pagar_LN : Base
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

        public List<Tb_Maestras> List_ConceptoGastos(int vTipo)
        {
            try
            {
                return new Cuentas_Pagar_AD().List_ConceptoGastos(vTipo);
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



        public int Grabar(Transacciones Transacciones)
        {
            try
            {
                return new Cuentas_Pagar_AD().Grabar(Transacciones);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        #endregion


        public string OtrasCobranzas(OtraCobranza vOtrosCobranza)
        {
            try
            {
                var Temp = new Tb_Comprobantecabecera_AD().GetRegistry(vOtrosCobranza.NumeroFacturaVenta);
                if (Temp != null)
                {
                    vOtrosCobranza.IdMoneda = new Tb_Maestras_AD().GetRegistry(Temp.Id_Moneda).Valor1;
                    vOtrosCobranza.IdTarjetaCredito = "";
                    vOtrosCobranza.Monto = Temp.Total;
                    vOtrosCobranza.IdRecibo = new Factura_AD().InsertOtrasCobranzas(vOtrosCobranza);
                }
                else
                {
                    vOtrosCobranza.IdRecibo = "|El Nro. de comprobante no es válido";
                }
                return vOtrosCobranza.IdRecibo;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }


    }
}

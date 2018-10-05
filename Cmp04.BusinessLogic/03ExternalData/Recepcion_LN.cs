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
    public class Recepcion_LN : Base
    {
        #region Métodos Públicos Generales


        public List<Tb_Maestras> List_TipoDocumento()
        {
            try
            {
                return new Recepcion_AD().List_TipoDocumento();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public List<Tb_Maestras> List_SunatDocumento()
        {
            try
            {
                return new Recepcion_AD().List_SunatDocumento();
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
                return new Recepcion_AD().Get_Nro_Documento();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public List<Tb_Maestras> List_Ordenes(string vFiltro = "")
        {
            try
            {
                return new Recepcion_AD().List_Ordenes(vFiltro);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public List<Oc_Transaccion> List_OrdenesDetalle(string vOrden)
        {
            try
            {
                return new Recepcion_AD().List_OrdenesDetalle(vOrden);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public List<Tb_Maestras> List_Detracciones()
        {
            try
            {
                return new Recepcion_AD().List_Detracciones();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public List<Tb_Maestras> List_CondicionPago()
        {
            try
            {
                return new Recepcion_AD().List_CondicionPago();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public List<Tb_Maestras> List_Chequera(string vConsejo,string usuario,int tipo)
        {
            try
            {
                return new Chequera_AD().List_Chequera(vConsejo,usuario, tipo);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public int Grabar(Recepcion vRecepcion)
        {
            try
            {
                return new Recepcion_AD().Grabar(vRecepcion);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
            

        }





        //public List<Tb_Maestras> List_Proveedor(string vFiltro = "")
        //{
        //    try
        //    {
        //        return new Orden_Compra_AD().List_Proveedor(vFiltro);
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(ex.Message, ex);
        //        throw;
        //    }
        //}

        //public List<Tb_Maestras> List_Moneda()
        //{
        //    try
        //    {
        //        return new Orden_Compra_AD().List_Moneda();
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(ex.Message, ex);
        //        throw;
        //    }
        //}

        //public List<Tb_Maestras> List_PlanImpuesto()
        //{
        //    try
        //    {
        //        return new Orden_Compra_AD().List_PlanImpuesto();
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(ex.Message, ex);
        //        throw;
        //    }
        //}

        //public List<Tb_Maestras> List_Responsable()
        //{
        //    try
        //    {
        //        return new Orden_Compra_AD().List_Responsable();
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(ex.Message, ex);
        //        throw;
        //    }
        //}

        //public List<Tb_Maestras> List_Servicios(string vFiltro, string vImp)
        //{
        //    try
        //    {
        //        return new Orden_Compra_AD().List_Servicios(vFiltro, vImp);
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(ex.Message, ex);
        //        throw;
        //    }
        //}

        //public int Grabar(OrdenCompra vOrdenCompra)
        //{
        //    int vRst = 0;
        //    using (var Full = new TransactionScope(TransactionScopeOption.RequiresNew))
        //    {
        //        try
        //        {
        //            Orden_Compra_AD vObjTrans = new Orden_Compra_AD();

        //            foreach (var item in vOrdenCompra.Detalle)
        //            {
        //                vRst = (vObjTrans.Insert_Detalle(item) == null) ? 0 : 1;
        //            }

        //            if (vRst == 0)
        //            {
        //                vObjTrans.Insert_Cabecera(vOrdenCompra.Cabecera);
        //                Full.Complete();
        //                return 1;
        //            }

        //            Full.Dispose();
        //            return 0;
        //        }
        //        catch (Exception ex)
        //        {
        //            Log.Error(ex.Message, ex);
        //            Full.Dispose();
        //            return 0;
        //        }
        //    }

        //}

        #endregion
    }
}

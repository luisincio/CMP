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
    public class Orden_Compra_LN : Base
    {
        #region Métodos Públicos Generales


        public List<Tb_Maestras> List_TipoDocumento()
        {
            try
            {
                return new Orden_Compra_AD().List_TipoDocumento();
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
                return new Orden_Compra_AD().Get_Nro_Documento();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public List<Tb_Maestras> List_Proveedor(string vFiltro = "")
        {
            try
            {
                return new Orden_Compra_AD().List_Proveedor(vFiltro);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public List<Tb_Maestras> List_Moneda()
        {
            try
            {
                return new Orden_Compra_AD().List_Moneda();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public List<Tb_Maestras> List_PlanImpuesto()
        {
            try
            {
                return new Orden_Compra_AD().List_PlanImpuesto();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public List<Tb_Maestras> List_Responsable()
        {
            try
            {
                return new Orden_Compra_AD().List_Responsable();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public List<Tb_Maestras> List_Servicios(string vFiltro, string vImp, string vTipo)
        {
            try
            {
                return new Orden_Compra_AD().List_Servicios(vFiltro, vImp, vTipo);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public int Grabar(OrdenCompra vOrdenCompra)
        {
            int vRst = 0;
            using (var Full = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                try
                {
                    Orden_Compra_AD vObjTrans = new Orden_Compra_AD();

                    foreach (var item in vOrdenCompra.Detalle)
                    {
                        vRst = vRst + vObjTrans.Insert_Detalle(item);
                        if (vRst > 0) break;
                    }

                    if (vRst == 0)
                    {
                        vRst = vObjTrans.Insert_Cabecera(vOrdenCompra.Cabecera);
                        if (vRst == 0)
                        {
                            Full.Complete();
                            return 1;
                        }
                    }
                    Full.Dispose();
                    return vRst;
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message, ex);
                    Full.Dispose();
                    return 0;
                }
            }

        }

        #endregion
    }
}

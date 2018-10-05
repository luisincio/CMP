/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Cliente_LN.cs
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
    public partial class Proveedor_LN : Base
    {
        #region Métodos Públicos Generales

        public List<Tb_Maestras> List_TipoPersona()
        {
            try
            {
                return new Proveedor_AD().List_TipoPersona();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public List<Tb_Maestras> List_TipoDocProveedor()
        {
            try
            {
                return new Proveedor_AD().List_TipoDocProveedor();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public List<Proveedores> List(string vFiltro)
        {
            try
            {
                return new Proveedor_AD().List(vFiltro);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public int Grabar(Proveedores vProveedor)
        {
            try
            {
                return new Proveedor_AD().Grabar(vProveedor);
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
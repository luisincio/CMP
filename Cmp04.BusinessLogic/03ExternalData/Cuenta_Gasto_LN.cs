/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Cuenta_Gasto_LN.cs
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
    public partial class Cuenta_Gasto_LN : Base
    {
        #region Métodos Públicos Generales

        public List<CuentaGasto> List_Cuentas()
        {
            try
            {
                return new Cuenta_Gasto_AD().List_Cuentas();
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
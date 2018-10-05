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
    public class Pagos_Manuales_LN : Base
    {
        #region Métodos Públicos Generales

        public string Get_Nro_Documento()
        {
            try
            {
                return new Pagos_Manuales_AD().Get_Nro_Documento();
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
                return new Pagos_Manuales_AD().List_SunatDocumento();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public List<Tb_Maestras> List_Chequera()
        {
            try
            {
                return new Pagos_Manuales_AD().List_Chequera();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public int Grabar(Pagos_Manuales vPagos_Manuales)
        {
            try
            {
                return new Pagos_Manuales_AD().Grabar(vPagos_Manuales);
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

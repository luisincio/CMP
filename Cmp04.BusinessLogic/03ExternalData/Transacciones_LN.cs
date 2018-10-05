﻿/*----------------------------------------------------------------------------------------
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
    public class Transacciones_LN : Base
    {
        #region Métodos Públicos Generales


        public string Get_Nro_Documento()
        {
            try
            {
                return new Transacciones_AD().Get_Nro_Documento();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public List<Tb_Maestras> List_DocumentoOrigen()
        {
            try
            {
                return new Transacciones_AD().List_DocumentoOrigen();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public List<Tb_Maestras> List_CuentaContable(string vFiltro)
        {
            try
            {
                return new Transacciones_AD().List_CuentaContable(vFiltro);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public int Grabar(EntradaTransaccion vTransaccion)
        {
            try
            {
                return new Transacciones_AD().Grabar(vTransaccion);
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

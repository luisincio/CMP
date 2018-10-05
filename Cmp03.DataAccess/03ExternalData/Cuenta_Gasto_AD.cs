/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Cuenta_Gasto_AD.cs
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
    public partial class Cuenta_Gasto_AD : Base
    {
        #region Métodos Públicos Generales

        public List<CuentaGasto> List_Cuentas()
        {
            List<CuentaGasto> vLista = new List<CuentaGasto>();
            using (SqlCommand vCmd = AdoGP.GetCommand("DBO.DIN_SP_LISTA_CUENTA_GASTO"))
            {
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new CuentaGasto() { Indice = Convert.ToInt32(vRdr["Indice"]), Cuenta = vRdr["Cuenta"].ToString(), Descripcion = vRdr["Descripcion"].ToString() });
                        }
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        #endregion
    }
}
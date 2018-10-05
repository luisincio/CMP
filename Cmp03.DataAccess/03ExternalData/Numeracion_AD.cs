/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Numeracion_AD.cs
Objetivo          : Clase referida a los métodos de Acceso a datos de la clase de GP
Autor             : CMP-SISTEMAS (FRR)
Fecha Creación    : 14/08/2018
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
    public partial class Numeracion_AD : Base
    {
        #region Métodos Públicos Generales

        public string GetVaue(int vTipoDocumento, string vSerie)
        {
            string vRst = "";
            using (SqlConnection vCnn = new SqlConnection(Cmp01.Utilities.Variables.CnnGP))
            {
                vCnn.Open();
                SqlCommand vCmd2 = new SqlCommand("usp_SS_taGetSopNumber", vCnn);
                vCmd2.CommandType = CommandType.StoredProcedure;
                vCmd2.Parameters.AddWithValue("@TipoDocumento", vTipoDocumento);
                vCmd2.Parameters.AddWithValue("@IDDocumento", vSerie);
                vRst = vCmd2.ExecuteScalar().ToString();
                vCnn.Close();
                vCnn.Dispose();
            }
            return vRst;
        }

        #endregion
    }
}




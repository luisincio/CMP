/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Chequera_AD.cs
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
    public partial class Chequera_AD : Base
    {
        #region Métodos Públicos Generales

        public List<Tb_Maestras> List_Chequera(string vConsejo,string usuario,int vTipo)
        {
            List<Tb_Maestras> vLista = new List<Tb_Maestras>();
            using (SqlCommand vCmd = AdoGP.GetCommand("DBO.CMP_SP_LISTAR_CHEQUERA"))
            {
                vCmd.Parameters.AddWithValue("@CONSEJO", vConsejo);
                vCmd.Parameters.AddWithValue("@USUARIO", usuario);
                vCmd.Parameters.AddWithValue("@TIPO", vTipo);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Maestras() { Valor1 = vRdr["Id"].ToString(), Descripcion = vRdr["Descripcion"].ToString() });
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



